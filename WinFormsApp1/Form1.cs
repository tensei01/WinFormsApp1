using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            List<MorderRow> morderRows = Context._data;

            DataTable table = new DataTable();
            table.Columns.Add("������", typeof(string));
            table.Columns.Add("���", typeof(int));
            table.Columns.Add("���", typeof(double));
            table.Columns.Add("����������������� �����", typeof(int));
            table.Columns.Add("������� �����������", typeof(double));
            table.Columns.Add("��������", typeof(double));
            table.Columns.Add("����������", typeof(int));

            foreach (MorderRow row in morderRows)
            {
                table.Rows.Add(row.Country, row.Year, row.Gdp, row.LifeExpectancy, row.UnemploymentRate, row.InflationRate, row.MortalityRate);
            }

            dataGridView1.DataSource = table;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegForm regForm = new RegForm();
            regForm.Show();
        }
    }
}
