using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Linq;
using System.Reflection;


namespace WinFormsApp1
{
    internal class ExportToWord
    {
        private int count = 0;


        public void exportToWord(System.Data.DataTable dataTable, string filenameMain, string description)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;
                string fileName = filenameMain + ".docx";
                string filePath = System.IO.Path.Combine(folderPath, fileName);

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                    DocumentFormat.OpenXml.Wordprocessing.Paragraph header = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                    DocumentFormat.OpenXml.Wordprocessing.Run headerRun = header.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                    headerRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Корреляция"));
                    header.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties(
                        new DocumentFormat.OpenXml.Wordprocessing.ParagraphStyleId() { Val = "Heading1" }
                    ));

                    DocumentFormat.OpenXml.Wordprocessing.Paragraph descriptionParagraph = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                    DocumentFormat.OpenXml.Wordprocessing.Run descriptionRun = descriptionParagraph.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                    descriptionRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(description));

                    DocumentFormat.OpenXml.Wordprocessing.Table table = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Table());
                    DocumentFormat.OpenXml.Wordprocessing.TableProperties tableProps = new DocumentFormat.OpenXml.Wordprocessing.TableProperties(
                        new DocumentFormat.OpenXml.Wordprocessing.TableWidth() { Width = "5000", Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa },
                        new DocumentFormat.OpenXml.Wordprocessing.TableBorders(
                            new DocumentFormat.OpenXml.Wordprocessing.TopBorder() { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Single), Color = "auto", Size = 6 },
                            new DocumentFormat.OpenXml.Wordprocessing.BottomBorder() { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Single), Color = "auto", Size = 6 },
                            new DocumentFormat.OpenXml.Wordprocessing.LeftBorder() { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Single), Color = "auto", Size = 6 },
                            new DocumentFormat.OpenXml.Wordprocessing.RightBorder() { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Single), Color = "auto", Size = 6 },
                            new DocumentFormat.OpenXml.Wordprocessing.InsideHorizontalBorder() { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Single), Color = "auto", Size = 6 },
                            new DocumentFormat.OpenXml.Wordprocessing.InsideVerticalBorder() { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Single), Color = "auto", Size = 6 }
                        )
                    );
                    table.AppendChild(tableProps);

                    // Добавляем заголовок таблицы
                    DocumentFormat.OpenXml.Wordprocessing.TableRow headerRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        DocumentFormat.OpenXml.Wordprocessing.TableCell headerCell = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                        headerCell.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(column.ColumnName))));
                        headerRow.AppendChild(headerCell);
                    }
                    table.AppendChild(headerRow);

                    // Добавляем данные в таблицу
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DocumentFormat.OpenXml.Wordprocessing.TableRow dataRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                        foreach (var item in row.ItemArray)
                        {
                            DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                            dataCell.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(item.ToString()))));
                            dataRow.AppendChild(dataCell);
                        }
                        table.AppendChild(dataRow);
                    }

                    DocumentFormat.OpenXml.Wordprocessing.Paragraph chartDescription = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                    DocumentFormat.OpenXml.Wordprocessing.Run chartDescriptionRun = chartDescription.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                    chartDescriptionRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("График показывает зависимость нескольких величин по годам. На графике представлены данные по ВВП, продолжительности жизни, уровню безработицы, инфляции и смертности"));
                }

                MessageBox.Show("Файл успешно сохранен.");
            }
        }

        public void ExportChartToWord(System.Windows.Forms.DataVisualization.Charting.Chart chart, string filenameMain, string country, string variable, string fisherTest, double fStatistic, double pValue)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Files (*.docx)|*.docx|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                string fileName = saveFileDialog.FileName;
                string appPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // Получаем путь к шрифту относительно каталога с приложением
                string fontPath = System.IO.Path.Combine(System.IO.Path.GetFullPath(System.IO.Path.Combine(appPath, @"..\..\..\csv")), "ofont.ru_Arial Unicode MS.ttf");

                using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                    DocumentFormat.OpenXml.Wordprocessing.Paragraph header = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                    DocumentFormat.OpenXml.Wordprocessing.Run headerRun = header.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                    headerRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Полиномиальная регрессия"));
                    header.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties(
                        new DocumentFormat.OpenXml.Wordprocessing.ParagraphStyleId() { Val = "Heading1" }
                    ));

                    DocumentFormat.OpenXml.Wordprocessing.Paragraph countryParagraph = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                    DocumentFormat.OpenXml.Wordprocessing.Run countryRun = countryParagraph.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                    countryRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Страна: " + country));

                    DocumentFormat.OpenXml.Wordprocessing.Paragraph variableParagraph = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                    DocumentFormat.OpenXml.Wordprocessing.Run variableRun = variableParagraph.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                    variableRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Выбранное поле: " + variable));

                    // Создаем изображение из диаграммы
//                    MemoryStream stream = new MemoryStream();
//                    chart.SaveImage(stream, ChartImageFormat.Png);
//                    stream.Seek(0, SeekOrigin.Begin);

//                    // Добавляем изображение в документ

//                    var imagePart = mainPart.AddImagePart(ImagePartType.Png);
//                    using (var imageStream = new System.IO.MemoryStream())
//                    {
//                        stream.CopyTo(imageStream);
//                        imagePart.FeedData(imageStream);
//                    }
//                    Drawing drawing = new Drawing();
//                    drawing.Inline = new Inline(
//                        new DocumentFormat.OpenXml.Drawing.Graphic(
//                            new DocumentFormat.OpenXml.Drawing.GraphicData(
//                                new DocumentFormat.OpenXml.Drawing.Pictures.Picture(
//                                    new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(
//                                        new DocumentFormat.OpenXml.Drawing.NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "Picture 1" },
//                                        new DocumentFormat.OpenXml.Drawing.NonVisualPictureProperties()
//                                    ),
//                                    new Blip(
//    new BlipExtensionList(
//        new DocumentFormat.OpenXml.Drawing.BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" }
//    ),
//    new DocumentFormat.OpenXml.Drawing.Stretch()
//    {
//        FillRectangle = new DocumentFormat.OpenXml.Drawing.FillRectangle()
//    }
//)
//                                    {
//                                        Embed = mainPart.GetIdOfPart(imagePart),
//                                        CompressionState = DocumentFormat.OpenXml.Drawing.BlipCompressionValues.Print
//                                    },
//                                        new DocumentFormat.OpenXml.Drawing.Stretch(
//                                            new DocumentFormat.OpenXml.Drawing.FillRectangle()
//                                        )
//                                    ),
//                                    new DocumentFormat.OpenXml.Drawing.ShapeProperties(
//                                        new DocumentFormat.OpenXml.Drawing.Transform2D(
//                                            new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
//                                            new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 9900000L, Cy = 7920000L }
//                                        ),
//                                        new NonVisualPictureProperties(
//                                            new DocumentFormat.OpenXml.Drawing.NonVisualPictureProperties()
//                                        )
//                                    )
//                                )
//                            )


////                    );
//                    DocumentFormat.OpenXml.Wordprocessing.Paragraph imageParagraph = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
//                    imageParagraph.AppendChild(drawing);

                    // Добавляем ячейки в таблицу с границами
                    DocumentFormat.OpenXml.Wordprocessing.Table table = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Table());
                    DocumentFormat.OpenXml.Wordprocessing.TableProperties tableProps = new DocumentFormat.OpenXml.Wordprocessing.TableProperties(
                        new DocumentFormat.OpenXml.Wordprocessing.TableWidth() { Width = "5000", Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa },
                        new DocumentFormat.OpenXml.Wordprocessing.TableBorders(
                            new DocumentFormat.OpenXml.Wordprocessing.TopBorder() { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Single), Color = "auto", Size = 6 },
                            new DocumentFormat.OpenXml.Wordprocessing.BottomBorder() { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Single), Color = "auto", Size = 6 },
                            new DocumentFormat.OpenXml.Wordprocessing.LeftBorder() { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Single), Color = "auto", Size = 6 },
                            new DocumentFormat.OpenXml.Wordprocessing.RightBorder() { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Single), Color = "auto", Size = 6 },
                            new DocumentFormat.OpenXml.Wordprocessing.InsideHorizontalBorder() { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Single), Color = "auto", Size = 6 },
                            new DocumentFormat.OpenXml.Wordprocessing.InsideVerticalBorder() { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Single), Color = "auto", Size = 6 }
                        )
                    );
                    table.AppendChild(tableProps);

                    // Добавляем заголовок таблицы
                    DocumentFormat.OpenXml.Wordprocessing.TableRow headerRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    DocumentFormat.OpenXml.Wordprocessing.TableCell headerCell = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                    headerCell.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Критерий Фишера"))));
                    headerRow.AppendChild(headerCell);
                    table.AppendChild(headerRow);

                    // Добавляем данные в таблицу
                    DocumentFormat.OpenXml.Wordprocessing.TableRow dataRow1 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell1 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                    dataCell1.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Фрасчетное"))));
                    dataRow1.AppendChild(dataCell1);
                    DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell2 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                    dataCell2.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(fStatistic.ToString()))));
                    dataRow1.AppendChild(dataCell2);
                    table.AppendChild(dataRow1);

                    DocumentFormat.OpenXml.Wordprocessing.TableRow dataRow2 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell3 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                    dataCell3.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Фтабличное"))));
                    dataRow2.AppendChild(dataCell3);
                    DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell4 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                    dataCell4.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(pValue.ToString()))));
                    dataRow2.AppendChild(dataCell4);
                    table.AppendChild(dataRow2);

                    DocumentFormat.OpenXml.Wordprocessing.TableRow dataRow3 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell5 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                    dataCell5.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(""))));
                    dataRow3.AppendChild(dataCell5);
                    DocumentFormat.OpenXml.Wordprocessing.TableCell dataCell6 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                    dataCell6.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(fisherTest))));
                    dataRow3.AppendChild(dataCell6);
                    table.AppendChild(dataRow3);
                }

                count++;

                MessageBox.Show("Файл успешно сохранен.");
            }
        }
    }
}