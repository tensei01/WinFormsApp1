using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using iText.Kernel.Font;
using iText.IO.Font;
using iText.Layout.Properties;
using System.Reflection;

namespace WinFormsApp1
{
    public partial class PrognozForm : Form
    {

        private Regression regression = new Regression();
        public PrognozForm()
        {
            InitializeComponent();
            string[] variableNames = { "ВВП", "Продолжительность жизни", "Уровень безработицы", "Инфляция" };
            List<MorderRow> data = Context._data;
            var countries = from data1 in data group data1 by data1.Country;
            foreach (var country in countries) { comboBox1.Items.Add(country.Key); }
            foreach (string variable in variableNames) { comboBox2.Items.Add(variable); }
        }

        private void PrognozForm_Load(object sender, EventArgs e)
        {

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

            double[] coefficient = Regression.PolynomialRegression(Regression.getValues(filteredData, variable), Array.ConvertAll(filteredData.Select(M => M.MortalityRate).ToArray(), x => (double)x));

            double result = Math.Round(coefficient[0] + coefficient[1] * Double.Parse(textBox1.Text) + coefficient[2] * Math.Pow(Double.Parse(textBox1.Text), 2), 2);

            label3.Text = "" + (result < 0 ? "Никто не умрёт" : result);
        }
        public void ExportToPDF(string country, string variable, double result)
        {
            SaveFileDialog openFileDialog = new SaveFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // Получаем путь к шрифту относительно каталога с приложением
                string fontPath = Path.Combine(Path.GetFullPath(Path.Combine(appPath, @"..\..\..\csv")), "ofont.ru_Arial Unicode MS.ttf");

                // Создаем шрифт
                PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);

                using (PdfWriter writer = new PdfWriter(fileName))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document document = new Document(pdf))
                {
                    Paragraph header = new Paragraph("Прогноз смертности").SetFont(font).SetFontSize(20);
                    document.Add(header);

                    Paragraph countryParagraph = new Paragraph($"Страна: {country}").SetFont(font).SetFontSize(14);
                    document.Add(countryParagraph);

                    Paragraph variableParagraph = new Paragraph($"Переменная: {variable}").SetFont(font).SetFontSize(14);
                    document.Add(variableParagraph);

                    Paragraph resultParagraph = new Paragraph($"Прогноз смертности: {result}").SetFont(font).SetFontSize(14);
                    document.Add(resultParagraph);

                    Paragraph descriptionParagraph = new Paragraph($"В результате проведения расчета прогнозирования в стране {country} с выбранным полем {variable} и значением {textBox1.Text} составляет {result}").SetFont(font).SetFontSize(14);
                    document.Add(descriptionParagraph);
                }

                MessageBox.Show("Файл успешно сохранен.");
            }
        }



        private void экспортВPDFToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string country = comboBox1.SelectedItem.ToString();
                string variable = comboBox2.SelectedItem.ToString();
                double result = double.Parse(label3.Text);

                ExportToPDF(country, variable, result);

                MessageBox.Show("Файл успешно экспортирован.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при экспорте файла: " + ex.Message);
            }
        }

        private void fAQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutPrognozForm aboutPrognozForm = new AboutPrognozForm();
            aboutPrognozForm.Show();
        }
    }
}
