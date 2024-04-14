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
        private Dictionary<string, List<List<double>>> _data;
        private CvsReader _cvsReader;
        private Correlition _correlition;

        public Form2(string filePath)
        {
            InitializeComponent();
            _cvsReader = new CvsReader();
            _data = _cvsReader.ReadCsv(filePath);
            comboBox1.DataSource = new BindingSource(_data.Keys, null);
            _correlition = new Correlition();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = comboBox1.SelectedItem.ToString();
            List<List<double>> values = _data[key];
            values.RemoveAt(0);// Удаление первого значения (года)
            double[,] matrix = new double[values.Count, values[0].Count];
            if (values.Count < 2)
            {
                MessageBox.Show("Недостаточно данных для вычисления корреляции");
                return;
            }
            for (int i = 0; i < values.Count; i++)
            {
                List<double> row = values[i];
                if (row.Count != values[0].Count)
                {
                    MessageBox.Show("Некорректные данные в строке " + (i + 1));
                    return;
                }
                for (int j = 0; j < row.Count; j++)
                {
                    if (double.IsNaN(row[j]))
                    {
                        MessageBox.Show("Некорректные данные в строке " + (i + 1) + " столбце " + (j + 1));
                        return;
                    }
                }
            }
            for (int i = 0; i < values.Count; i++)
            {
                for (int j = 0; j < values[i].Count; j++)
                {
                    matrix[i, j] = values[i][j];
                }
            }
            double[] correlationCoefficients = _correlition.PearsonCorrelation(matrix);
            List<InfoCorrelation> infoCorrelations = _correlition.getInfoCorrelation(correlationCoefficients);
            // Вывод результатов в текстовое поле или таблицу
            textBoxResult.Clear();
            textBoxResult.AppendText("Результаты корреляции:\n");
            foreach (var info in infoCorrelations)
            {
                textBoxResult.AppendText($"{info.info}: {info.value}\n");
            }
        }

        
    }
}
