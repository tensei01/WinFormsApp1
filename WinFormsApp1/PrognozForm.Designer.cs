﻿namespace WinFormsApp1
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
            label5 = new Label();
            label6 = new Label();
            comboBox1 = new ComboBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 125);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 7;
            label2.Text = "Поле";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(57, 153);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(183, 33);
            comboBox2.TabIndex = 6;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { экспортToolStripMenuItem, fAQToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(306, 33);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // экспортToolStripMenuItem
            // 
            экспортToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { экспортВPDFToolStripMenuItem, экспортВXLSXToolStripMenuItem });
            экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            экспортToolStripMenuItem.Size = new Size(95, 29);
            экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // экспортВPDFToolStripMenuItem
            // 
            экспортВPDFToolStripMenuItem.Name = "экспортВPDFToolStripMenuItem";
            экспортВPDFToolStripMenuItem.Size = new Size(241, 34);
            экспортВPDFToolStripMenuItem.Text = "Экспорт в PDF";
            // 
            // экспортВXLSXToolStripMenuItem
            // 
            экспортВXLSXToolStripMenuItem.Name = "экспортВXLSXToolStripMenuItem";
            экспортВXLSXToolStripMenuItem.Size = new Size(241, 34);
            экспортВXLSXToolStripMenuItem.Text = "Экспорт в XLSX";
            // 
            // fAQToolStripMenuItem
            // 
            fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            fAQToolStripMenuItem.Size = new Size(62, 29);
            fAQToolStripMenuItem.Text = "FAQ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 346);
            label1.Name = "label1";
            label1.Size = new Size(182, 25);
            label1.TabIndex = 9;
            label1.Text = "Прогноз смертности";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 384);
            label3.Name = "label3";
            label3.Size = new Size(0, 25);
            label3.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(57, 250);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(183, 31);
            textBox1.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 201);
            label4.Name = "label4";
            label4.Size = new Size(89, 25);
            label4.TabIndex = 12;
            label4.Text = "Значение";
            // 
            // button1
            // 
            button1.Location = new Point(57, 300);
            button1.Name = "button1";
            button1.Size = new Size(182, 34);
            button1.TabIndex = 13;
            button1.Text = "Рассчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(126, 213);
            label5.Name = "label5";
            label5.Size = new Size(54, 25);
            label5.TabIndex = 14;
            label5.Text = "Поле";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(57, 48);
            label6.Name = "label6";
            label6.Size = new Size(69, 25);
            label6.TabIndex = 15;
            label6.Text = "Страна";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(57, 76);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(183, 33);
            comboBox1.TabIndex = 16;
            // 
            // PrognozForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 450);
            Controls.Add(comboBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(comboBox2);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
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
        private Label label5;
        private Label label6;
        private ComboBox comboBox1;
    }
}