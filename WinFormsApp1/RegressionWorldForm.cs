using System;
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

    public partial class RegressionWorldForm : Form
    {
        private Export export;
        public RegressionWorldForm()
        {
            InitializeComponent();
            export = new Export();
            string[] variableNames = { "ВВП", "Продолжительность жизни", "Уровень безработицы", "Инфляция" };
            foreach (string variable in variableNames) { comboBox2.Items.Add(variable); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String variable = comboBox2.Text;
            if (variable == null || variable.Equals(""))
            {
                MessageBox.Show("Обезательное поле не заполнено.");
                return;
            }

            DrawRegressionChart(Context._worldData, Regression.calculateRegression(Context._worldData, variable));
            insetIntoTable(Context._worldData, variable);
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

            (double fStatistic, double pValue) = Regression.CalculateFisherFStatistic(sortedList, value);

            label4.Text = "Вывод: " + (fStatistic > pValue ? "Критерй Фишера расчётный больше табличного, поэтому регрессия адекватна." : "Критерй Фишера расчётный меньше табличного, поэтому регрессиям не адекватна.");

            table.Rows.Add(Math.Round(fStatistic, 3), Math.Round(pValue, 3));

            dataGridView2.DataSource = table;

        }

        private void экспортPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export.ExportChartToPdf(chart1, "RegressionChart");
        }

        private void формулыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutRegressionForm1 form  = new AboutRegressionForm1();
            form.Show();
        }
    }
}
