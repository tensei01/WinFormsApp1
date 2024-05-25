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

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Context._data == null)
            {
                MessageBox.Show("��������� ������");
                return;
            }
            CorrelationForm form2 = new CorrelationForm();
            form2.Show();
        }

        private void ������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Context._data == null)
            {
                MessageBox.Show("��������� ������");
                return;
            }
            RegressionFormCountry regForm = new RegressionFormCountry();
            regForm.Show();
        }

        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Context._worldData == null)
            {
                MessageBox.Show("��������� ������");
                return;
            }
            RegressionWorldForm regressionWorldForm = new RegressionWorldForm();
            regressionWorldForm.Show();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
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
            dataGridView1.Refresh();
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        private void ��������XLSXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export.ExportToExcel((DataTable)dataGridView1.DataSource, "data");
        }

        private void ��������PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string description = "�������� ����������, ������������ ��� �������� ����������, � ��������� � �������.";
            export.ExportToPDF((DataTable)dataGridView1.DataSource, "data", description);
        }

        private void fAQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutFAQForm form = new AboutFAQForm();
            form.Show();
        }

        private void ���������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Context._worldData == null)
            {
                MessageBox.Show("��������� ������");
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
