using MathNet.Numerics.Statistics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace WinFormsApp1
{
    public partial class RegressionFormCountry : Form
    {
        public double FStatistic { get; private set; }
        public double PValue { get; private set; }
        private Export export;
        public RegressionFormCountry()
        {
            InitializeComponent();
            export = new Export();
            string[] variableNames = { "ВВП", "Продолжительность жизни", "Уровень безработицы", "Инфляция" };
            Regression regression = new Regression();
            List<MorderRow> data = Context._data;
            var countries = from data1 in data group data1 by data1.Country;
            foreach (var country in countries) { comboBox1.Items.Add(country.Key); }
            foreach (string variable in variableNames) { comboBox2.Items.Add(variable); }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            String country = comboBox1.Text;
            String variable = comboBox2.Text;
            if (country == null || variable == null || country.Equals("") || variable.Equals(""))
            {
                MessageBox.Show("Обезательное поле не заполнено.");
                return;
            }

            List<MorderRow> data = Context._data;
            List<MorderRow> filteredData = data.Where(m => m.Country == country).OrderBy(m => m.Year).ToList();

            DrawRegressionChart(filteredData, Regression.calculateRegression(filteredData, variable));
            insetIntoTable(filteredData, variable);
        }

        private void DrawRegressionChart(List<MorderRow> sortedList, double[] predictedValues)
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Legends.Clear();
            ChartArea chartArea = new ChartArea();

            Legend legend = new Legend();
            chart1.Legends.Add(legend);
            chart1.ChartAreas.Add(chartArea);


            chart1.ChartAreas[0].AxisX.Title = "Год";
            chart1.ChartAreas[0].AxisY.Title = "Смерность";

            Series actualSeries = new Series("Фактические данные");
            actualSeries.ChartType = SeriesChartType.Spline;
            chart1.Series.Add(actualSeries);

            Series predictedSeries = new Series("Расчитанные данные");
            predictedSeries.ChartType = SeriesChartType.Spline;
            chart1.Series.Add(predictedSeries);



            for (int i = 0; i < sortedList.Count; i++)
            {
                MorderRow morder = sortedList[i];
                actualSeries.Points.AddXY(morder.Year, morder.MortalityRate);
                predictedSeries.Points.AddXY(morder.Year, predictedValues[i]);
            }
        }



        public void insetIntoTable(List<MorderRow> sortedList, String value)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Фрасчёт", typeof(double));
            table.Columns.Add("Фтабл", typeof(double));

            (FStatistic, PValue) = Regression.CalculateFisherFStatistic(sortedList, value);

            label4.Text = "Вывод: " + (FStatistic > PValue ? "Критерий Фишера расчётный больше табличного, поэтому регрессия адекватна." : "Критерий Фишера расчётный меньше табличного, поэтому регрессиям не адекватна.");

            table.Rows.Add(Math.Round(FStatistic, 3), Math.Round(PValue, 3));

            dataGridView2.DataSource = table;

        }

        private void формулыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutRegressionForm1 form = new AboutRegressionForm1();
            form.Show();
        }
        private void экспортPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string country = comboBox1.Text;
            string variable = comboBox2.Text;
            string fisherTest = label4.Text;
            double fStatistic = FStatistic;
            double pValue = PValue;


            export.ExportChartToPdf(chart1, "RegressionChart", country, variable, fisherTest, fStatistic, pValue);
        }

        private void экспортWORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export.saveWord2();
        }
    }
}
