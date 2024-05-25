namespace WinFormsApp1
{
    partial class PrognozForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            comboBox2 = new ComboBox();
            menuStrip1 = new MenuStrip();
            экспортToolStripMenuItem = new ToolStripMenuItem();
            экспортВPDFToolStripMenuItem = new ToolStripMenuItem();
            экспортВXLSXToolStripMenuItem = new ToolStripMenuItem();
            fAQToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            button1 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 49);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 7;
            label2.Text = "Поле";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(49, 66);
            comboBox2.Margin = new Padding(2, 2, 2, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(129, 23);
            comboBox2.TabIndex = 6;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { экспортToolStripMenuItem, fAQToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(214, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // экспортToolStripMenuItem
            // 
            экспортToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { экспортВPDFToolStripMenuItem, экспортВXLSXToolStripMenuItem });
            экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            экспортToolStripMenuItem.Size = new Size(64, 22);
            экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // экспортВPDFToolStripMenuItem
            // 
            экспортВPDFToolStripMenuItem.Name = "экспортВPDFToolStripMenuItem";
            экспортВPDFToolStripMenuItem.Size = new Size(180, 22);
            экспортВPDFToolStripMenuItem.Text = "Экспорт в PDF";
            экспортВPDFToolStripMenuItem.Click += экспортВPDFToolStripMenuItem_Click;
            // 
            // экспортВXLSXToolStripMenuItem
            // 
            экспортВXLSXToolStripMenuItem.Name = "экспортВXLSXToolStripMenuItem";
            экспортВXLSXToolStripMenuItem.Size = new Size(180, 22);
            экспортВXLSXToolStripMenuItem.Text = "Экспорт в XLSX";
            // 
            // fAQToolStripMenuItem
            // 
            fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            fAQToolStripMenuItem.Size = new Size(41, 22);
            fAQToolStripMenuItem.Text = "FAQ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 193);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 9;
            label1.Text = "Прогноз смертности";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 176);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(49, 134);
            textBox1.Margin = new Padding(2, 2, 2, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(129, 23);
            textBox1.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 117);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 12;
            label4.Text = "Значение";
            // 
            // button1
            // 
            button1.Location = new Point(49, 164);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(127, 20);
            button1.TabIndex = 13;
            button1.Text = "Рассчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PrognozForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(214, 270);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(comboBox2);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 2, 2, 2);
            Name = "PrognozForm";
            Text = "Прогноз";
            Load += PrognozForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private ComboBox comboBox2;
        private MenuStrip menuStrip1;
        private Label label1;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private Button button1;
        private ToolStripMenuItem экспортToolStripMenuItem;
        private ToolStripMenuItem fAQToolStripMenuItem;
        private ToolStripMenuItem экспортВPDFToolStripMenuItem;
        private ToolStripMenuItem экспортВXLSXToolStripMenuItem;
    }
}