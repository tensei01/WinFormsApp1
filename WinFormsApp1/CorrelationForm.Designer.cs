namespace WinFormsApp1
{
    partial class CorrelationForm
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
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            экспортToolStripMenuItem = new ToolStripMenuItem();
            экспортВXLSXToolStripMenuItem = new ToolStripMenuItem();
            экспортВPDFToolStripMenuItem = new ToolStripMenuItem();
            экспортВWORDToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            формулаПирсонаToolStripMenuItem = new ToolStripMenuItem();
            допИнформацияToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.Size = new Size(1154, 673);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { экспортToolStripMenuItem, оПрограммеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1179, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // экспортToolStripMenuItem
            // 
            экспортToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { экспортВXLSXToolStripMenuItem, экспортВPDFToolStripMenuItem, экспортВWORDToolStripMenuItem });
            экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            экспортToolStripMenuItem.Size = new Size(95, 29);
            экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // экспортВXLSXToolStripMenuItem
            // 
            экспортВXLSXToolStripMenuItem.Name = "экспортВXLSXToolStripMenuItem";
            экспортВXLSXToolStripMenuItem.Size = new Size(270, 34);
            экспортВXLSXToolStripMenuItem.Text = "Экспорт в XLSX";
            экспортВXLSXToolStripMenuItem.Click += экспортВXLSXToolStripMenuItem_Click;
            // 
            // экспортВPDFToolStripMenuItem
            // 
            экспортВPDFToolStripMenuItem.Name = "экспортВPDFToolStripMenuItem";
            экспортВPDFToolStripMenuItem.Size = new Size(270, 34);
            экспортВPDFToolStripMenuItem.Text = "Экспорт в PDF";
            экспортВPDFToolStripMenuItem.Click += экспортВPDFToolStripMenuItem_Click;
            // 
            // экспортВWORDToolStripMenuItem
            // 
            экспортВWORDToolStripMenuItem.Name = "экспортВWORDToolStripMenuItem";
            экспортВWORDToolStripMenuItem.Size = new Size(270, 34);
            экспортВWORDToolStripMenuItem.Text = "Экспорт в WORD";
            экспортВWORDToolStripMenuItem.Click += экспортВWORDToolStripMenuItem_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { формулаПирсонаToolStripMenuItem, допИнформацияToolStripMenuItem });
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(97, 29);
            оПрограммеToolStripMenuItem.Text = "Справка";
            // 
            // формулаПирсонаToolStripMenuItem
            // 
            формулаПирсонаToolStripMenuItem.Name = "формулаПирсонаToolStripMenuItem";
            формулаПирсонаToolStripMenuItem.Size = new Size(266, 34);
            формулаПирсонаToolStripMenuItem.Text = "Формула Пирсона";
            формулаПирсонаToolStripMenuItem.Click += формулаПирсонаToolStripMenuItem_Click;
            // 
            // допИнформацияToolStripMenuItem
            // 
            допИнформацияToolStripMenuItem.Name = "допИнформацияToolStripMenuItem";
            допИнформацияToolStripMenuItem.Size = new Size(266, 34);
            допИнформацияToolStripMenuItem.Text = "Доп. информация";
            допИнформацияToolStripMenuItem.Click += допИнформацияToolStripMenuItem_Click;
            // 
            // CorrelationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 743);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(6, 5, 6, 5);
            Name = "CorrelationForm";
            Text = "Корреляция";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem экспортToolStripMenuItem;
        private ToolStripMenuItem экспортВXLSXToolStripMenuItem;
        private ToolStripMenuItem экспортВPDFToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem формулаПирсонаToolStripMenuItem;
        private ToolStripMenuItem допИнформацияToolStripMenuItem;
        private ToolStripMenuItem экспортВWORDToolStripMenuItem;
    }
}