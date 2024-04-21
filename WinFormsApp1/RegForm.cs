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
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
            Regression regression = new Regression();
            List<MorderRow> data = Context._data;

            int n = data.Count;
            int m = 4;
            double[][] matrix = new double[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new double[m];
            }
            double[] y = new double[n];
            for (int i = 0; i < n; i++)
            {
                matrix[i][0] = data[i].Gdp;
                matrix[i][1] = data[i].LifeExpectancy;
                matrix[i][2] = data[i].UnemploymentRate;
                matrix[i][3] = data[i].InflationRate;
                y[i] = data[i].MortalityRate;
            }

            double[] coefficient = regression.PolynomialRegression(matrix, y, 3);

            List<MorderRow> sortedList = data.OrderBy(m => m.Year).ToList();

            List<double> predictedValues = new List<double>();

            for (int i = 0; i < sortedList.Count; i++)
            {
                MorderRow morder = sortedList[i];
                double predictedValue = coefficient[0] + coefficient[1] * morder.Gdp + coefficient[2] * morder.LifeExpectancy + coefficient[3] * morder.UnemploymentRate + coefficient[4] * morder.InflationRate;
                predictedValues.Add(predictedValue);
            }

            DataTable table = new DataTable();
            table.Columns.Add("Year", typeof(int));
            table.Columns.Add("Actual Value", typeof(double));
            table.Columns.Add("Predicted Value", typeof(double));

            for (int i = 0; i < sortedList.Count; i++)
            {
                MorderRow morder = sortedList[i];
                table.Rows.Add(morder.Year, morder.MortalityRate, predictedValues[i]);
            }

            dataGridView2.DataSource = table;
            DrawRegressionChart(sortedList, predictedValues);
        }
        private void DrawRegressionChart(List<MorderRow> sortedList, List<double> predictedValues)
        {
            chart1.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();

            Legend legend = new Legend();
            chart1.Legends.Add(legend);
            chart1.ChartAreas.Add(chartArea);


            chart1.ChartAreas[0].AxisX.Title = "Year";
            chart1.ChartAreas[0].AxisY.Title = "Mortality Rate";

            Series actualSeries = new Series("Actual Value");
            actualSeries.ChartType = SeriesChartType.Line;
            chart1.Series.Add(actualSeries);

            Series predictedSeries = new Series("Predicted Value");
            predictedSeries.ChartType = SeriesChartType.Line;
            chart1.Series.Add(predictedSeries);

       

            for (int i = 0; i < sortedList.Count; i++)
            {
                MorderRow morder = sortedList[i];
                actualSeries.Points.AddXY(morder.Year, morder.MortalityRate);
                predictedSeries.Points.AddXY(morder.Year, predictedValues[i]);
            }
        }

        private void RegForm_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
