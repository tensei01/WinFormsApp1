using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class DataForm : Form
    {

        private Export export = new Export();

        public DataForm()
        {
            InitializeComponent();
            dataGridView1.Dock = DockStyle.Fill;
            menuStrip1.AutoSize = true;

        }

        private void корреляцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Context._data == null)
            {
                MessageBox.Show("Загрузите данные");
                return;
            }
            CorrelationForm form2 = new CorrelationForm();
            form2.Show();
        }

        private void регрессияПоСтранамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Context._data == null)
            {
                MessageBox.Show("Загрузите данные");
                return;
            }
            RegressionFormCountry regForm = new RegressionFormCountry();
            regForm.Show();
        }

        private void мироваяРегрессияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Context._worldData == null)
            {
                MessageBox.Show("Загрузите данные");
                return;
            }
            RegressionWorldForm regressionWorldForm = new RegressionWorldForm();
            regressionWorldForm.Show();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CvsReader reader = new CvsReader();
                    Context._data = reader.ReadCsv(openFileDialog1.FileName);
                    Context.calculate(Context._data);
                    insertTable();
                    this.pictureBox1.Hide();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }


        private void insertTable()
        {
            List<MorderRow> morderRows = Context._data;

            DataTable table = new DataTable();
            table.Columns.Add("Страна", typeof(string));
            table.Columns.Add("Год", typeof(int));
            table.Columns.Add("ВВП", typeof(double));
            table.Columns.Add("Продолжительность жизни", typeof(int));
            table.Columns.Add("Уровень безработицы", typeof(double));
            table.Columns.Add("Инфляция", typeof(double));
            table.Columns.Add("Смертность", typeof(int));

            foreach (MorderRow row in morderRows)
            {
                table.Rows.Add(row.Country, row.Year, row.Gdp, row.LifeExpectancy, row.UnemploymentRate, row.InflationRate, row.MortalityRate);
            }

            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        private void экспортВXLSXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export.ExportToExcel((DataTable)dataGridView1.DataSource, "data");
        }

        private void экспортВPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string description = "Описание алгоритмов, используемых для подсчета корреляции, и пояснения к графику.";
            export.ExportToPDF((DataTable)dataGridView1.DataSource, "data", description);
        }

        private void fAQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutFAQForm form = new AboutFAQForm();
            form.Show();
        }

        private void прогназированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Context._worldData == null)
            {
                MessageBox.Show("Загрузите данные");
                return;
            }
            PrognozForm prognozForm = new PrognozForm();
            prognozForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
