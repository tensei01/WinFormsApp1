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
using Accord.Statistics.Kernels;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.VisualBasic.ApplicationServices;
using iText.IO.Image;

namespace WinFormsApp1
{
    public class Export
    {
        public void ExportToExcel(DataTable table, String filenameMain)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;
                string fileName = filenameMain + ".xlsx";
                string filePath = Path.Combine(folderPath, fileName);

                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].LoadFromDataTable(table, true);

                    package.SaveAs(new FileInfo(filePath));
                }

                MessageBox.Show("Файл успешно сохранен.");
            }
        }

        public void ExportToPDF(DataTable dataTable, String filenameMain)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;
                string fileName = filenameMain + ".pdf";
                string fontPath = "C:\\Users\tense\\Source\\Repos\\WinFormsApp1\\WinFormsApp1\\csv\\ofont.ru_Arial Unicode MS.ttf";
                PdfFont font = PdfFontFactory.CreateFont(fontPath);

                string filePath = Path.Combine(folderPath, fileName);

                using (PdfWriter writer = new PdfWriter(filePath))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document document = new Document(pdf))
                {

                    float[] columnWidths = new float[dataTable.Columns.Count];
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        columnWidths[i] = 150;
                    }

                    Table table = new Table(columnWidths);
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(dataTable.Columns[i].ColumnName).SetFont(font)));
                    }

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(dataTable.Rows[i][j].ToString()).SetFont(font)));
                        }
                    }

                    Paragraph header = new Paragraph("Корреляция");
                    document.Add(header);
                    document.Add(table);
                }

                MessageBox.Show("Файл успешно сохранен.");
            }
        }

        //public void ExportChartToPdf(Chart chart, string filenameMain)
        //{
        //    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        //    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string folderPath = folderBrowserDialog.SelectedPath;
        //        string fileName = filenameMain + ".pdf";
        //        string filePath = Path.Combine(folderPath, fileName);

        //        using (PdfWriter writer = new PdfWriter(filePath))
        //        using (PdfDocument pdf = new PdfDocument(writer))
        //        using (Document document = new Document(pdf))
        //        {
        //            MemoryStream stream = new MemoryStream();
        //            chart.SaveImage(stream, ChartImageFormat.Png);
        //            Image image = new Image(stream.ToArray());

        //            Paragraph header = new Paragraph("Регрессия");
        //            document.Add(header);
        //            document.Add(new Image(iText.Kernel.Pdf.Xobject.PdfFormXObject.Create(pdf, image)));
        //        }

        //        MessageBox.Show("Файл успешно сохранен.");
        //    }

        //}
    }
}
