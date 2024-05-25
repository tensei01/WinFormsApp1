namespace WinFormsApp1
{
    partial class RegressionWorldForm
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
            button1 = new Button();
            comboBox2 = new ComboBox();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label2 = new Label();
            dataGridView2 = new DataGridView();
            label3 = new Label();
            menuStrip1 = new MenuStrip();
            экспортToolStripMenuItem = new ToolStripMenuItem();
            экспортPdfToolStripMenuItem = new ToolStripMenuItem();
            экспортXLSXToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            формулыToolStripMenuItem = new ToolStripMenuItem();
            label4 = new Label();
            экспортWORDToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(201, 73);
            button1.Name = "button1";
            button1.Size = new Size(111, 33);
            button1.TabIndex = 6;
            button1.Text = "Расчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(11, 73);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(183, 33);
            comboBox2.TabIndex = 5;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(11, 118);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(864, 572);
            chart1.TabIndex = 4;
            chart1.Text = "chart1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 40);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 7;
            label2.Text = "Поле";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(11, 738);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(864, 137);
            dataGridView2.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 710);
            label3.Name = "label3";
            label3.Size = new Size(183, 25);
            label3.TabIndex = 8;
            label3.Text = "Проверка регрессии";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { экспортToolStripMenuItem, оПрограммеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(899, 33);
            menuStrip1.TabIndex = 10;
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
            label4.Location = new Point(12, 894);
            label4.Name = "label4";
            label4.Size = new Size(0, 25);
            label4.TabIndex = 11;
            // 
            // экспортWORDToolStripMenuItem
            // 
            экспортWORDToolStripMenuItem.Name = "экспортWORDToolStripMenuItem";
            экспортWORDToolStripMenuItem.Size = new Size(270, 34);
            экспортWORDToolStripMenuItem.Text = "Экспорт WORD";
            // 
            // RegressionWorldForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 945);
            Controls.Add(label4);
            Controls.Add(menuStrip1);
            Controls.Add(dataGridView2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(chart1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "RegressionWorldForm";
            Text = "Мировая регрессия";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label label2;
        private DataGridView dataGridView2;
        private Label label3;
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