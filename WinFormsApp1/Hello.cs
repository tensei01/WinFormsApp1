using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp1
{
    public partial class Hello : Form
    {
        public Hello()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                // Чтение файла и передача данных на вторую страницу
                Form1 form1 = new Form1(filePath);
                this.Hide();
                form1.ShowDialog();
                this.Show();
            }
        }

        private void Hello_Load(object sender, EventArgs e)
        {

        }
    }
}
