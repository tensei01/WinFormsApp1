namespace WinFormsApp1
{
    partial class RegressionFormCountry
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridView2 = new DataGridView();
            menuStrip1 = new MenuStrip();
            экспортToolStripMenuItem = new ToolStripMenuItem();
            экспортPdfToolStripMenuItem = new ToolStripMenuItem();
            экспортXLSXToolStripMenuItem = new ToolStripMenuItem();
            экспортWORDToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            формулыToolStripMenuItem = new ToolStripMenuItem();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(11, 110);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(864, 572);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(11, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(183, 33);
            comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(236, 70);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(183, 33);
            comboBox2.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(453, 68);
            button1.Name = "button1";
            button1.Size = new Size(111, 33);
            button1.TabIndex = 3;
            button1.Text = "Расчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 42);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 4;
            label1.Text = "Страна";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(239, 42);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 5;
            label2.Text = "Поле";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 693);
            label3.Name = "label3";
            label3.Size = new Size(183, 25);
            label3.TabIndex = 6;
            label3.Text = "Проверка регрессии";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(11, 722);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(864, 137);
            dataGridView2.TabIndex = 7;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { экспортToolStripMenuItem, оПрограммеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(899, 33);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // экспортToolStripMenuItem
            // 
            экспортToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { экспортPdfToolStripMenuItem, экспортXLSXToolStripMenuItem, экспортWORDToolStripMenuItem });
            экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            экспортToolStripMenuItem.Size = new Size(95, 29);
            экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // экспортPdfToolStripMenuItem
            // 
            экспортPdfToolStripMenuItem.Name = "экспортPdfToolStripMenuItem";
            экспортPdfToolStripMenuItem.Size = new Size(270, 34);
            экспортPdfToolStripMenuItem.Text = "Экспорт PDF";
            экспортPdfToolStripMenuItem.Click += экспортPdfToolStripMenuItem_Click;
            // 
            // экспортXLSXToolStripMenuItem
            // 
            экспортXLSXToolStripMenuItem.Name = "экспортXLSXToolStripMenuItem";
            экспортXLSXToolStripMenuItem.Size = new Size(270, 34);
            экспортXLSXToolStripMenuItem.Text = "Экспорт XLSX";
            // 
            // экспортWORDToolStripMenuItem
            // 
            экспортWORDToolStripMenuItem.Name = "экспортWORDToolStripMenuItem";
            экспортWORDToolStripMenuItem.Size = new Size(270, 34);
            экспортWORDToolStripMenuItem.Text = "Экспорт WORD";
            экспортWORDToolStripMenuItem.Click += экспортWORDToolStripMenuItem_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { формулыToolStripMenuItem });
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(97, 29);
            оПрограммеToolStripMenuItem.Text = "Справка";
            // 
            // формулыToolStripMenuItem
            // 
            формулыToolStripMenuItem.Name = "формулыToolStripMenuItem";
            формулыToolStripMenuItem.Size = new Size(193, 34);
            формулыToolStripMenuItem.Text = "Формулы";
            формулыToolStripMenuItem.Click += формулыToolStripMenuItem_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 879);
            label4.Name = "label4";
            label4.Size = new Size(0, 25);
            label4.TabIndex = 9;
            // 
            // RegressionFormCountry
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 931);
            Controls.Add(label4);
            Controls.Add(dataGridView2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(chart1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Name = "RegressionFormCountry";
            Text = "Регрессия";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem экспортToolStripMenuItem;
        private ToolStripMenuItem экспортPdfToolStripMenuItem;
        private ToolStripMenuItem экспортXLSXToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem формулыToolStripMenuItem;
        private Label label4;
        private ToolStripMenuItem экспортWORDToolStripMenuItem;
    }
}