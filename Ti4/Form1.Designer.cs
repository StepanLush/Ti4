namespace Ti4
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pTB = new System.Windows.Forms.TextBox();
            this.qTB = new System.Windows.Forms.TextBox();
            this.hTB = new System.Windows.Forms.TextBox();
            this.xTB = new System.Windows.Forms.TextBox();
            this.kTB = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.plaintextRTB = new System.Windows.Forms.RichTextBox();
            this.StripMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьПодписанныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проверитьПодписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.hashTB = new System.Windows.Forms.TextBox();
            this.dsTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.StripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "p";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "q";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "h(1, p-1)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "x(0, q)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "k(0,q)";
            // 
            // pTB
            // 
            this.pTB.Location = new System.Drawing.Point(22, 85);
            this.pTB.Name = "pTB";
            this.pTB.Size = new System.Drawing.Size(100, 26);
            this.pTB.TabIndex = 5;
            this.pTB.Text = "643";
            // 
            // qTB
            // 
            this.qTB.Location = new System.Drawing.Point(22, 149);
            this.qTB.Name = "qTB";
            this.qTB.Size = new System.Drawing.Size(100, 26);
            this.qTB.TabIndex = 6;
            this.qTB.Text = "107";
            this.qTB.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // hTB
            // 
            this.hTB.Location = new System.Drawing.Point(22, 208);
            this.hTB.Name = "hTB";
            this.hTB.Size = new System.Drawing.Size(100, 26);
            this.hTB.TabIndex = 7;
            this.hTB.Text = "2";
            // 
            // xTB
            // 
            this.xTB.Location = new System.Drawing.Point(22, 275);
            this.xTB.Name = "xTB";
            this.xTB.Size = new System.Drawing.Size(100, 26);
            this.xTB.TabIndex = 8;
            this.xTB.Text = "45";
            // 
            // kTB
            // 
            this.kTB.Location = new System.Drawing.Point(22, 339);
            this.kTB.Name = "kTB";
            this.kTB.Size = new System.Drawing.Size(100, 26);
            this.kTB.TabIndex = 9;
            this.kTB.Text = "31";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(22, 387);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(120, 41);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // plaintextRTB
            // 
            this.plaintextRTB.Location = new System.Drawing.Point(166, 61);
            this.plaintextRTB.Name = "plaintextRTB";
            this.plaintextRTB.Size = new System.Drawing.Size(600, 519);
            this.plaintextRTB.TabIndex = 11;
            this.plaintextRTB.Text = "";
            // 
            // StripMenu
            // 
            this.StripMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.StripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.проверитьПодписьToolStripMenuItem});
            this.StripMenu.Location = new System.Drawing.Point(0, 0);
            this.StripMenu.Name = "StripMenu";
            this.StripMenu.Size = new System.Drawing.Size(778, 33);
            this.StripMenu.TabIndex = 12;
            this.StripMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьПодписанныйToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(316, 34);
            this.открытьToolStripMenuItem.Text = "Открыть обычный";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьПодписанныйToolStripMenuItem
            // 
            this.сохранитьПодписанныйToolStripMenuItem.Name = "сохранитьПодписанныйToolStripMenuItem";
            this.сохранитьПодписанныйToolStripMenuItem.Size = new System.Drawing.Size(316, 34);
            this.сохранитьПодписанныйToolStripMenuItem.Text = "Сохранить подписанный";
            this.сохранитьПодписанныйToolStripMenuItem.Click += new System.EventHandler(this.сохранитьПодписанныйToolStripMenuItem_Click);
            // 
            // проверитьПодписьToolStripMenuItem
            // 
            this.проверитьПодписьToolStripMenuItem.Name = "проверитьПодписьToolStripMenuItem";
            this.проверитьПодписьToolStripMenuItem.Size = new System.Drawing.Size(192, 29);
            this.проверитьПодписьToolStripMenuItem.Text = "Проверить подпись";
            this.проверитьПодписьToolStripMenuItem.Click += new System.EventHandler(this.проверитьПодписьToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // hashTB
            // 
            this.hashTB.Location = new System.Drawing.Point(26, 473);
            this.hashTB.Name = "hashTB";
            this.hashTB.Size = new System.Drawing.Size(100, 26);
            this.hashTB.TabIndex = 13;
            // 
            // dsTB
            // 
            this.dsTB.Location = new System.Drawing.Point(26, 538);
            this.dsTB.Name = "dsTB";
            this.dsTB.Size = new System.Drawing.Size(100, 26);
            this.dsTB.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Хэш";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 512);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "ЭЦП";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 592);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dsTB);
            this.Controls.Add(this.hashTB);
            this.Controls.Add(this.plaintextRTB);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.kTB);
            this.Controls.Add(this.xTB);
            this.Controls.Add(this.hTB);
            this.Controls.Add(this.qTB);
            this.Controls.Add(this.pTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StripMenu);
            this.MainMenuStrip = this.StripMenu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.StripMenu.ResumeLayout(false);
            this.StripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pTB;
        private System.Windows.Forms.TextBox qTB;
        private System.Windows.Forms.TextBox hTB;
        private System.Windows.Forms.TextBox xTB;
        private System.Windows.Forms.TextBox kTB;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RichTextBox plaintextRTB;
        private System.Windows.Forms.MenuStrip StripMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьПодписанныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проверитьПодписьToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox hashTB;
        private System.Windows.Forms.TextBox dsTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

