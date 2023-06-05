using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Ti4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static bool IsPrime(BigInteger n)
        {
            int k = 50;
            if (n <= 1 || n == 4)
                return false;
            if (n <= 3)
                return true;

            BigInteger d = n - 1;
            while (d % 2 == 0)
                d /= 2;

            Random rand = new Random();
            for (int i = 0; i < k; i++)
            {
                BigInteger a = rand.Next(2, (int)n - 1);
                BigInteger x = BigInteger.ModPow(a, d, n);

                if (x == 1 || x == n - 1)
                    continue;

                for (int j = 0; j < (int)Math.Log((int)n,2); j++)
                {
                    x = BigInteger.ModPow(x, 2, n);
                    if (x == n - 1)
                        break;
                    if (j == (int)Math.Log((int)n, 2) - 1)
                        return false;
                }
            }
            return true;
        }

        static BigInteger FastExponentiation(BigInteger baseNum, BigInteger exponent, BigInteger modulus)
        {
            BigInteger result = 1;

            while (exponent > 0)
            {
                if (exponent % 2 == 1)
                {
                    result = (result * baseNum) % modulus;
                }
                baseNum = (baseNum * baseNum) % modulus;
                exponent >>= 1;
            }
            return result;
        }

        private bool IsCorrect(BigInteger p, BigInteger q, BigInteger h, BigInteger x, BigInteger k)
        {
            if (!IsPrime(p))
            {
                MessageBox.Show("Ошибка: p не является простым числом.");
                return false;
            }
            if (!IsPrime(q))
            {
                MessageBox.Show("Ошибка: q не является простым числом.");
                return false;
            }
            if ((p - 1) % q != 0)
            {
                MessageBox.Show("Ошибка: q не является делителем p - 1.");
                return false;
            }
            if (h < 1 || h > p - 1)
            {
                MessageBox.Show("Ошибка: параметр h должен попадать в промежуток (1, p-1)");
                return false;
            }
            if (FastExponentiation(h, (p - 1) / q, p) <= 1)
            {
                MessageBox.Show($"Ошибка: g = h^((p-1)/q) mod p <= 1");
                return false;
            }
            if (x < 0 || x > q)
            {
                MessageBox.Show($"Ошибка: параметр x должен попадать в промежуток (0, q)");
                return false;
            }
            if (k < 0 || k > q)
            {
                MessageBox.Show($"Ошибка: параметр k должен попадать в промежуток (0, q)");
                return false;
            }
            return true;
        }

        public static BigInteger ModInverse(BigInteger a, BigInteger q)
        {
            return FastExponentiation(a, q - 2, q);
        }

        public static BigInteger ComputeHash(byte[] M, BigInteger p, BigInteger q)
        {
            BigInteger n = p * q;
            BigInteger H = 100;

            foreach (byte Mi in M)
            {
                H = FastExponentiation(H + Mi, 2, n); // Hi = (Hi-1 + Mi)^2 mod n
            }

            return H;
        }



        private static DS CountDigitalSignature(byte[] inputFileBytes, BigInteger p, BigInteger q, BigInteger k, BigInteger g, BigInteger x, BigInteger hash)
        {
            BigInteger r, s;
            r = FastExponentiation(g, k, p) % q; // r = (g^k mod p) mod q
            BigInteger kInv = FastExponentiation(k, q - 2, q); // k^-1 mod q
            s = (kInv * (hash + x * r)) % q; // s = k^-1(h(M) + x*r) mod q
            if (r == 0)
                throw new Exception("Вычисленное значение r = 0. Используйте другое значение параметра k");
            if (s == 0)
                throw new Exception("Вычисленное значение s = 0. Используйте другое значение параметра k");
            return new DS(r, s);
        }

        private class DS
        {
            public BigInteger R { get; set; }
            public BigInteger S { get; set; }

            public DS()
            {
                R = 0;
                S = 0;
            }

            public DS(BigInteger r, BigInteger s)
            {
                R = r;
                S = s;
            }

            public DS(string line)
            {
                if (line == null || line == "")
                    throw new Exception("Файл пуст");
                string[] parts = line.Trim('(', ')').Split(',');
                try
                {
                    R = BigInteger.Parse(parts[0].Trim());
                    S = BigInteger.Parse(parts[1].Trim());
                }
                catch
                {
                    throw new Exception("В файле некорректная строка с ЭЦП");
                }
            }

            public override string ToString()
            {
                return "(" + R.ToString() + ", " + S.ToString() + ")";
            }
        }


        private byte[] GetBytesFromRichTextBox(RichTextBox rtb)
        {
            string text = rtb.Text;
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            return bytes;
        }

        byte[] lastOpenedFileBytes;

        private byte[] GetBytesFromFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bytes = br.ReadBytes((int)fs.Length);
                return bytes;
            }

        }


        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FillRichTextBox(string filePath, RichTextBox rtb)
        {
            StreamReader sr = new StreamReader(filePath);
            using (sr);
            string text = File.ReadAllText(filePath);

            rtb.Text = text;
        }

        private byte[] ReadFileWithoutFirstLine(string fileName, ref DS signature)
        {
            byte[] fileBytes;

            using (var stream = new StreamReader(fileName))
            {
                string line = stream.ReadLine();
                signature = new DS(line);
                fileBytes = Encoding.UTF8.GetBytes(stream.ReadToEnd());
            }

            return fileBytes;
        }


        private void проверитьПодписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            DS signature = new DS();
            byte[] openedFileBytes;
            try
            {
                openedFileBytes = ReadFileWithoutFirstLine(filename, ref signature);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (!BigInteger.TryParse(pTB.Text, out BigInteger p))
            {
                MessageBox.Show("Ошибка: p должно быть целым числом");
                return;
            }
            if (!BigInteger.TryParse(qTB.Text, out BigInteger q))
            {
                MessageBox.Show("Ошибка: q должно быть целым числом");
                return;
            }
            if (!BigInteger.TryParse(hTB.Text, out BigInteger h))
            {
                MessageBox.Show("Ошибка: h должно быть целым числом");
                return;
            }
            if (!BigInteger.TryParse(xTB.Text, out BigInteger x))
            {
                MessageBox.Show("Ошибка: x должно быть целым числом");
                return;
            }
            if (!BigInteger.TryParse(kTB.Text, out BigInteger k))
            {
                MessageBox.Show("Ошибка: k должно быть целым числом");
                return;
            }

            BigInteger g = FastExponentiation(h, (p - 1) / q, p);
            BigInteger y = FastExponentiation(g, x, p);

            BigInteger r = signature.R;
            BigInteger s = signature.S;
            BigInteger w = FastExponentiation(s, q - 2, q); //w = s^−1 mod q
            BigInteger hash = ComputeHash(openedFileBytes, p, q);
            BigInteger u1 = hash * w % q; //u1 = h(M) * w mod q
            BigInteger u2 = r * w % q; //u2 = r * w mod q
            BigInteger v = FastExponentiation(g, u1, p) * FastExponentiation(y, u2, p) % p % q;
            if (v == r)
            {
                MessageBox.Show($"Подпись верна\nhash = {hash}\nw = {w}\nu1 = {u1}\nu2 = {u2}\nv = {v} = r", "Проверка ЭЦП", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Подпись неверна\nhash = {hash}\nw = {w}\nu1 = {u1}\nu2 = {u2}\nv = {v} != r", "Проверка ЭЦП", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            lastOpenedFileBytes = File.ReadAllBytes(filename);
            FillRichTextBox(filename, plaintextRTB);
        }

        private void сохранитьПодписанныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog.FileName;
            File.WriteAllText(filename, dsTB.Text + "\n" + plaintextRTB.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //if (plaintextRTB.Text == "")
            //return;
            if (!BigInteger.TryParse(pTB.Text, out BigInteger p))
            {
                MessageBox.Show("Ошибка: p должно быть целым числом");
                return;
            }
            if (!BigInteger.TryParse(qTB.Text, out BigInteger q))
            {
                MessageBox.Show("Ошибка: q должно быть целым числом");
                return;
            }
            if (!BigInteger.TryParse(hTB.Text, out BigInteger h))
            {
                MessageBox.Show("Ошибка: h должно быть целым числом");
                return;
            }
            if (!BigInteger.TryParse(xTB.Text, out BigInteger x))
            {
                MessageBox.Show("Ошибка: x должно быть целым числом");
                return;
            }
            if (!BigInteger.TryParse(kTB.Text, out BigInteger k))
            {
                MessageBox.Show("Ошибка: k должно быть целым числом");
                return;
            }
            if (!IsCorrect(p, q, h, x, k))
                return;
            BigInteger g = FastExponentiation(h, (p - 1) / q, p);
            //byte[] inputFileBytes = GetBytesFromRichTextBox(plaintextRTB);
            byte[] inputFileBytes = lastOpenedFileBytes;
            BigInteger hash = ComputeHash(inputFileBytes, p, q);
            DS signature;
            try
            {
                signature = CountDigitalSignature(inputFileBytes, p, q, k, g, x, hash);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            hashTB.Text = hash.ToString();
            dsTB.Text = signature.ToString();
            проверитьПодписьToolStripMenuItem.Enabled = true;
        }


    }
}
