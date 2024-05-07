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
using GrapeCity.DataVisualization.Chart;
using OfficeOpenXml;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Font;

namespace WinFormsApp1
{
    public partial class CorrelationForm : Form
    {
        private Correlition _correlition = new Correlition();
        private Export export = new Export();
        public CorrelationForm()
        {
            InitializeComponent();

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

            double[,] correlations = _correlition.PearsonCorrelation(matrix);

            DataTable table = new DataTable();
            table.Columns.Add("Переменная", typeof(string));

            string[] variableNames = { "ВВП", "Продолжительность жизни", "Уровень безработицы", "Инфляция", "Смертность" };

            foreach (string variableName in variableNames)
            {
                table.Columns.Add(variableName, typeof(double));
            }


            for (int i = 0; i < 5; i++)
            {
                DataRow row = table.NewRow();
                row["Переменная"] = variableNames[i];
                row["ВВП"] = Math.Round(correlations[i, 0], 2);
                row["Продолжительность жизни"] = Math.Round(correlations[i, 1], 2);
                row["Уровень безработицы"] = Math.Round(correlations[i, 2], 2);
                row["Инфляция"] = Math.Round(correlations[i, 3], 2);
                row["Смертность"] = Math.Round(correlations[i, 4], 2);
                table.Rows.Add(row);
            }

            dataGridView1.DataSource = table;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridView1_CellToolTipTextNeeded);
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (e.Value != null)
                {
                    double value = (double)e.Value;

                    if (value >= -0.2 && value <= 0.2)
                    {
                        e.CellStyle.BackColor = Color.Green;
                    }
                    else if ((value < -0.2 && value >= -0.5) || (value > 0.2 && value <= 0.5))
                    {
                        e.CellStyle.BackColor = Color.Orange;
                    }
                    else if ((value < -0.5 && value > -1) || (value > 0.5 && value < 1))
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Black;
                    }
                }
            }
        }

        private void dataGridView1_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e != null)
            {
                if (e.RowIndex > 0 && e.ColumnIndex > 0)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        double rowValue;
                        if (double.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out rowValue))
                        {
                            String result;

                            if (rowValue > 0)
                            {
                                result = "Положительная " + getinfo(rowValue);
                            }
                            else
                            {
                                result = "Отрицательная " + getinfo(Math.Abs(rowValue));
                            }

                            e.ToolTipText = result;
                        }
                    }
                }
            }
        }

        private String getinfo(double value)
        {
            if (value <= 0.2)
            {
                return "слабая корреляция";
            }
            else if (value <= 0.5)
            {
                return "средняя корреляция";
            }
            else if (value <= 0.9)
            {
                return "сильная корреляция";
            }
            else
            {
                return "очень сильная корреляция";
            }
        }

        private void экспортВXLSXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export.ExportToExcel((DataTable)dataGridView1.DataSource, "correlation");
        }

        private void экспортВPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export.ExportToPDF((DataTable)dataGridView1.DataSource, "correlation");
        }

        private void формулаПирсонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutCorrelationForm aboutCorrelationForm = new AboutCorrelationForm();
            aboutCorrelationForm.Show();
        }

        private void допИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutCorrelationForm1 aboutCorrelationForm = new AboutCorrelationForm1();
            aboutCorrelationForm.Show();
        }
    }
}
