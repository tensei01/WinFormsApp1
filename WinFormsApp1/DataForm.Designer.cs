namespace WinFormsApp1
{
    partial class DataForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            фвйлToolStripMenuItem = new ToolStripMenuItem();
            экспортToolStripMenuItem = new ToolStripMenuItem();
            экспортВPDFToolStripMenuItem = new ToolStripMenuItem();
            экспортВXLSXToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            корреляцияToolStripMenuItem = new ToolStripMenuItem();
            регрессияToolStripMenuItem = new ToolStripMenuItem();
            регрессияПоСтранамToolStripMenuItem = new ToolStripMenuItem();
            мироваяРегрессияToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            прогназированиеToolStripMenuItem = new ToolStripMenuItem();
            fAQToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 38);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1250, 709);
            dataGridView1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.MenuBar;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { фвйлToolStripMenuItem, корреляцияToolStripMenuItem, регрессияToolStripMenuItem, прогназированиеToolStripMenuItem, оПрограммеToolStripMenuItem, fAQToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1263, 33);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // фвйлToolStripMenuItem
            // 
            фвйлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { экспортToolStripMenuItem, открытьToolStripMenuItem });
            фвйлToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            фвйлToolStripMenuItem.Name = "фвйлToolStripMenuItem";
            фвйлToolStripMenuItem.Size = new Size(75, 29);
            фвйлToolStripMenuItem.Text = "Файл";
            // 
            // экспортToolStripMenuItem
            // 
            экспортToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { экспортВPDFToolStripMenuItem, экспортВXLSXToolStripMenuItem });
            экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            экспортToolStripMenuItem.Size = new Size(190, 34);
            экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // экспортВPDFToolStripMenuItem
            // 
            экспортВPDFToolStripMenuItem.Name = "экспортВPDFToolStripMenuItem";
            экспортВPDFToolStripMenuItem.Size = new Size(248, 34);
            экспортВPDFToolStripMenuItem.Text = "Экспорт в PDF";
            экспортВPDFToolStripMenuItem.Click += экспортВPDFToolStripMenuItem_Click;
            // 
            // экспортВXLSXToolStripMenuItem
            // 
            экспортВXLSXToolStripMenuItem.Name = "экспортВXLSXToolStripMenuItem";
            экспортВXLSXToolStripMenuItem.Size = new Size(248, 34);
            экспортВXLSXToolStripMenuItem.Text = "Экспорт в XLSX";
            экспортВXLSXToolStripMenuItem.Click += экспортВXLSXToolStripMenuItem_Click;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(190, 34);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // корреляцияToolStripMenuItem
            // 
            корреляцияToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            корреляцияToolStripMenuItem.Name = "корреляцияToolStripMenuItem";
            корреляцияToolStripMenuItem.Size = new Size(137, 29);
            корреляцияToolStripMenuItem.Text = "Корреляция";
            корреляцияToolStripMenuItem.Click += корреляцияToolStripMenuItem_Click;
            // 
            // регрессияToolStripMenuItem
            // 
            регрессияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { регрессияПоСтранамToolStripMenuItem, мироваяРегрессияToolStripMenuItem });
            регрессияToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            регрессияToolStripMenuItem.Name = "регрессияToolStripMenuItem";
            регрессияToolStripMenuItem.Size = new Size(115, 29);
            регрессияToolStripMenuItem.Text = "Регрессия";
            // 
            // регрессияПоСтранамToolStripMenuItem
            // 
            регрессияПоСтранамToolStripMenuItem.Name = "регрессияПоСтранамToolStripMenuItem";
            регрессияПоСтранамToolStripMenuItem.Size = new Size(306, 34);
            регрессияПоСтранамToolStripMenuItem.Text = "Регрессия по странам";
            регрессияПоСтранамToolStripMenuItem.Click += регрессияПоСтранамToolStripMenuItem_Click;
            // 
            // мироваяРегрессияToolStripMenuItem
            // 
            мироваяРегрессияToolStripMenuItem.Name = "мироваяРегрессияToolStripMenuItem";
            мироваяРегрессияToolStripMenuItem.Size = new Size(306, 34);
            мироваяРегрессияToolStripMenuItem.Text = "Мировая регрессия";
            мироваяРегрессияToolStripMenuItem.Click += мироваяРегрессияToolStripMenuItem_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(146, 29);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // прогназированиеToolStripMenuItem
            // 
            прогназированиеToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            прогназированиеToolStripMenuItem.Name = "прогназированиеToolStripMenuItem";
            прогназированиеToolStripMenuItem.Size = new Size(186, 29);
            прогназированиеToolStripMenuItem.Text = "Прогназирование";
            прогназированиеToolStripMenuItem.Click += прогназированиеToolStripMenuItem_Click;
            // 
            // fAQToolStripMenuItem
            // 
            fAQToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            fAQToolStripMenuItem.Size = new Size(63, 29);
            fAQToolStripMenuItem.Text = "FAQ";
            fAQToolStripMenuItem.Click += fAQToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // DataForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1263, 752);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(6, 5, 6, 5);
            Name = "DataForm";
            Text = "Данные";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem фвйлToolStripMenuItem;
        private ToolStripMenuItem экспортToolStripMenuItem;
        private ToolStripMenuItem экспортВPDFToolStripMenuItem;
        private ToolStripMenuItem экспортВXLSXToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem корреляцияToolStripMenuItem;
        private ToolStripMenuItem регрессияToolStripMenuItem;
        private ToolStripMenuItem регрессияПоСтранамToolStripMenuItem;
        private ToolStripMenuItem мироваяРегрессияToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem fAQToolStripMenuItem;
        private ToolStripMenuItem прогназированиеToolStripMenuItem;
    }
}
