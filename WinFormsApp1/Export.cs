﻿using MathNet.Numerics.Statistics;
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
using System.Diagnostics.Metrics;
using iText.IO.Font;
using iText.Layout.Borders;
using MathNet.Numerics.Distributions;
using iText.Kernel.Colors;
using System.Reflection;
using Accord.IO;
using Xceed.Words.NET;


namespace WinFormsApp1
{
    public class Export
    {
        private int count = 1;
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

        public void ExportToPDF(DataTable dataTable, String filenameMain, String description)
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
                    Paragraph header = new Paragraph("Корреляция").SetFont(font).SetFontSize(20);
                    document.Add(header);
                    Paragraph descriptionParagraph = new Paragraph(description).SetFont(font).SetFontSize(14);
                    document.Add(descriptionParagraph);

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

                    
                    document.Add(table);

                    Paragraph chartDescription = new Paragraph("График показывает зависимость нескольких величин по годам. На графике представлены данные по ВВП, продолжительности жизни, уровню безработицы, инфляции и смертности").SetFont(font).SetFontSize(14);
                    document.Add(chartDescription);
                }

                MessageBox.Show("Файл успешно сохранен.");
            }
        }

        public void ExportChartToPdf(Chart chart, string filenameMain, string country, string variable, string fisherTest, double fStatistic, double pValue)
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
                    MemoryStream stream = new MemoryStream();
                    chart.SaveImage(stream, ChartImageFormat.Png);
                    iText.IO.Image.ImageData imageData = iText.IO.Image.ImageDataFactory.Create(stream.ToArray());
                    iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData);

                    Paragraph header = new Paragraph("Полиномиальная регрессия").SetFont(font);
                    document.Add(header);
                    Paragraph countryParagraph = new Paragraph("Страна: " + country).SetFont(font);
                    document.Add(countryParagraph);

                    Paragraph variableParagraph = new Paragraph("Выбранное поле: " + variable).SetFont(font);
                    document.Add(variableParagraph);

                    document.Add(image);

                    // Добавляем ячейки в таблицу с границами
                    Table table = new Table(UnitValue.CreatePercentArray(new float[] { 50, 50 }));
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    // Добавляем заголовок таблицы
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Критерий Фишера").SetFont(font)).SetBackgroundColor(ColorConstants.LIGHT_GRAY));

                    // Добавляем ячейки в таблицу с границами
                    table.AddCell(new Cell().Add(new Paragraph("Фрасчетное").SetFont(font)).SetBorder(new SolidBorder(1)));
                    table.AddCell(new Cell().Add(new Paragraph(fStatistic.ToString()).SetFont(font)).SetBorder(new SolidBorder(1)));

                    table.AddCell(new Cell().Add(new Paragraph("Фтабличное").SetFont(font)).SetBorder(new SolidBorder(1)));
                    table.AddCell(new Cell().Add(new Paragraph(pValue.ToString()).SetFont(font)).SetBorder(new SolidBorder(1)));

                    table.AddCell(new Cell().Add(new Paragraph("").SetFont(font)).SetBorder(new SolidBorder(1)));
                    table.AddCell(new Cell().Add(new Paragraph(fisherTest).SetFont(font)).SetBorder(new SolidBorder(1)));

                    document.Add(table);

                }
                count++;

                MessageBox.Show("Файл успешно сохранен.");
            }
        }

        public void ExportToWord(DataTable dataTable, String filenameMain, String description)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Documents (*.docx)|*.docx|All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            // Отобразите диалоговое окно
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = saveFileDialog.FileName;

                using (DocX document = DocX.Create(selectedFilePath))
                {
                    Xceed.Document.NET.Paragraph header = document.InsertParagraph("Корреляция", false);
                    header.FontSize(20);

                    Xceed.Document.NET.Paragraph descriptionParagraph = document.InsertParagraph(description, false);
                    descriptionParagraph.FontSize(14);

                    Xceed.Document.NET.Table table = document.AddTable(dataTable.Rows.Count, dataTable.Columns.Count);
                    table.Design = Xceed.Document.NET.TableDesign.TableGrid;
                    table.Alignment = Xceed.Document.NET.Alignment.center;
                    table.SetWidths(new float[] { 115f, 115f });

                    // Добавляем заголовки таблицы
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        table.Rows[0].Cells[i].Paragraphs[0].Append(dataTable.Columns[i].ColumnName);
                    }

                    // Добавляем данные в таблицу
                    for (int i = 1; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            table.Rows[i].Cells[j].Paragraphs[0].Append(dataTable.Rows[i][j].ToString());
                        }
                    }

                    descriptionParagraph.InsertTableAfterSelf(table);

                    Xceed.Document.NET.Paragraph chartDescription = document.InsertParagraph("График показывает зависимость нескольких величин по годам. На графике представлены данные по ВВП, продолжительности жизни, уровню безработицы, инфляции и смертности", false);
                    chartDescription.FontSize(14);
                    document.Save();
                }

                MessageBox.Show("Файл успешно сохранен.");
            }
        }

        public void ExportChartToWord(Chart chart, string filenameMain, string country, string variable, string fisherTest, double fStatistic, double pValue)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Documents (*.docx)|*.docx|All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = saveFileDialog.FileName;

                using (DocX document = DocX.Create(selectedFilePath))
                {
                    Xceed.Document.NET.Paragraph header = document.InsertParagraph("Полиномиальная регрессия", false);
                    header.FontSize(20);

                    Xceed.Document.NET.Paragraph countryParagraph = document.InsertParagraph("Страна: " + country, false);
                    countryParagraph.FontSize(14);

                    Xceed.Document.NET.Paragraph variableParagraph = document.InsertParagraph("Выбранное поле: " + variable, false);
                    variableParagraph.FontSize(14);

                    MemoryStream stream = new MemoryStream();
                    chart.SaveImage(stream, ChartImageFormat.Png);

                    Xceed.Document.NET.Image image = document.AddImage(stream);
                    variableParagraph.AppendPicture(image.CreatePicture());

                    // Добавляем таблицу с границами
                    Xceed.Document.NET.Table table = document.AddTable(4, 2);
                    table.Design = Xceed.Document.NET.TableDesign.TableGrid;

                    // Добавляем заголовок таблицы
                    table.Rows[0].Cells[0].Paragraphs[0].Append("Критерий Фишера");

                    // Добавляем ячейки в таблицу с границами
                    table.Rows[1].Cells[0].Paragraphs[0].Append("Фрасчетное");
                    table.Rows[1].Cells[1].Paragraphs[0].Append(fStatistic.ToString());

                    table.Rows[2].Cells[0].Paragraphs[0].Append("Фтабличное");
                    table.Rows[2].Cells[1].Paragraphs[0].Append(pValue.ToString());

                    table.Rows[3].Cells[0].Paragraphs[0].Append("");
                    table.Rows[3].Cells[1].Paragraphs[0].Append(fisherTest);

                    variableParagraph.AppendLine("Проверка").FontSize(14);
                    variableParagraph.InsertTableAfterSelf(table);

                    document.Save();
                }

                count++;
                MessageBox.Show("Файл успешно сохранен.");
            }
        }
    }
}
