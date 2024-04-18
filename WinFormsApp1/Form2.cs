using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private Correlition _correlition;

        public Form2()
        {
            InitializeComponent();

            _correlition = new Correlition();

            List<MorderRow> data = Context._data;

            int n = data.Count;
            int m = 5;
            double[,] matrix = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                matrix[i, 0] = data[i].Gdp;
                matrix[i, 1] = data[i].LifeExpectancy;
                matrix[i, 2] = data[i].UnemploymentRate;
                matrix[i, 3] = data[i].InflationRate;
                matrix[i, 4] = data[i].MortalityRate;
            }

            double[] correlations = _correlition.PearsonCorrelation(matrix);

            List<InfoCorrelation> infoCorrelations = _correlition.getInfoCorrelation(correlations);

            DataTable table = new DataTable();
            table.Columns.Add("Переменная", typeof(string));
            table.Columns.Add("Корреляция", typeof(double));
            table.Columns.Add("Вывод", typeof(string));

            string[] variableNames = { "ВВП", "Продолжительность жизни", "Уровень безработицы", "Инфляция"};
            for (int i = 0; i < infoCorrelations.Count; i++)
            {
                DataRow row = table.NewRow();
                row["Переменная"] = variableNames[i];
                row["Корреляция"] = infoCorrelations[i].value;
                row["Вывод"] = infoCorrelations[i].info;
                table.Rows.Add(row);
            }

            dataGridView1.DataSource = table;

        }

        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
