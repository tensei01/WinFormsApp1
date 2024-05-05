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
            button2 = new Button();
            label1 = new Label();
            button1 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 70);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1163, 671);
            dataGridView1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(603, 19);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(126, 42);
            button2.TabIndex = 3;
            button2.Text = "Корреляция";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(117, 38);
            label1.TabIndex = 4;
            label1.Text = "Данные";
            // 
            // button1
            // 
            button1.Location = new Point(737, 19);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(214, 42);
            button1.TabIndex = 5;
            button1.Text = "Регрессия по странам";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(958, 19);
            button3.Name = "button3";
            button3.Size = new Size(207, 40);
            button3.TabIndex = 6;
            button3.Text = "Мировая регрессия";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // DataForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 744);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 5, 6, 5);
            Name = "DataForm";
            Text = "Основная страница";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button button2;
        private Label label1;
        private Button button1;
        private Button button3;
    }
}
