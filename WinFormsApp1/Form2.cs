using MathNet.Numerics.Statistics;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private Correlition _correlition;

        public Form2()
        {
            InitializeComponent();
            Console.WriteLine("DrawCorrelationChart started one");

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
            DrawCorrelationChart(infoCorrelations, variableNames);

        }

        private void DrawCorrelationChart( List<InfoCorrelation> infoCorrelations, string[] variableNames)
        {
            chart1.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();

            Legend legend = new Legend();
            chart1.Legends.Add(legend);
            chart1.ChartAreas.Add(chartArea);

            int m = 4;

            // Добавляем серии для каждой переменной
            chart1.Series.Clear();
            for (int i = 0; i < m; i++)
            {
                chart1.Series.Add(variableNames[i]);
                chart1.Series[i].ChartType = SeriesChartType.Line;
                chart1.Series[i].MarkerStyle = MarkerStyle.Circle;
                chart1.Series[i].MarkerSize = 10;
            }

            
            // Добавляем точки на график
            for (int i = 0; i < infoCorrelations.Count; i++)
            {
             
               chart1.Series[i].Points.AddXY(i+1, infoCorrelations[i].value);
                
            }

            // Настраиваем внешний вид графика
            chart1.ChartAreas[0].AxisX.Title = "Номер переменной";
            chart1.ChartAreas[0].AxisX.Minimum = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 4;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Title = "Значение корреляции";
            chart1.ChartAreas[0].AxisY.Minimum = -1;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisY.Interval = 0.2;
            chart1.Legends[0].Enabled = true;

            // Обновляем график
            chart1.Refresh();
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
