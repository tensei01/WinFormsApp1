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

        private CvsReader reader = new CvsReader();

        public Hello()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Context._data = reader.ReadCsv(openFileDialog1.FileName);
                    Context.calculate(Context._data);
                    DataForm form1 = new DataForm();
                    this.Hide();
                    form1.ShowDialog();
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void Hello_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
