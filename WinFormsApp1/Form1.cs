using System.Data;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Dictionary<string, List<List<double>>> _data;
        private CvsReader _cvsReader;

        public Form1(string filePath)
        {
            InitializeComponent();
            _cvsReader = new CvsReader();
            _data = _cvsReader.ReadCsv(filePath);
            comboBox1.DataSource = new BindingSource(_data.Keys, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = comboBox1.SelectedItem.ToString();
            List<List<double>> values = _data[key];

            // Создаем таблицу с нужным количеством строк и столбцов
            int rowCount = values.Count;
            int columnCount = 7; // количество столбцов в таблице
            DataTable table = new DataTable();
            for (int i = 0; i < columnCount; i++)
            {
                table.Columns.Add($"Column{i + 1}", typeof(double));
            }
            for (int i = 0; i < rowCount; i++)
            {
                table.Rows.Add(table.NewRow());
            }

            // Заполняем таблицу данными
            for (int i = 0; i < values.Count; i++)
            {
                List<double> row = values[i];
                for (int j = 0; j < columnCount; j++)
                {
                    if (j < row.Count)
                    {
                        table.Rows[i][j] = row[j];
                    }
                }
            }
            // Отображаем таблицу в DataGridView
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\C#\WinFormsApp1\WinFormsApp1\csv\test.csv"; // замените на путь к вашему файлу CSV
            Form2 form2 = new Form2(filePath);
            form2.Show();
        }

       
    }
}
