using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class PrognozForm : Form
    {

        private Regression regression = new Regression();
        public PrognozForm()
        {
            InitializeComponent();
            string[] variableNames = { "ВВП", "Продолжительность жизни", "Уровень безработицы", "Инфляция" };
            foreach (string variable in variableNames) { comboBox2.Items.Add(variable); }
        }

        private void PrognozForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String variable = comboBox2.Text;
            if (variable == null || variable.Equals(""))
            {
                MessageBox.Show("Обезательное поле не заполнено.");
                return;
            }
            double[] coefficient = Regression.PolynomialRegression(Regression.getValues(Context._worldData, variable), Array.ConvertAll(Context._worldData.Select(M => M.MortalityRate).ToArray(), x => (double)x));

            double result = Math.Round(coefficient[0] + coefficient[1] * Double.Parse(textBox1.Text) + coefficient[2] * Math.Pow(Double.Parse(textBox1.Text), 2), 2);

            label3.Text = "" + (result < 0 ? "Никто не умрёт" : result);
        }

        private void экспортВPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
