//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Wordprocessing;
//using DocumentFormat.OpenXml.Drawing;
//using DocumentFormat.OpenXml.Drawing.Charts;
//using DocumentFormat.OpenXml.Drawing.Wordprocessing;
//using DocumentFormat.OpenXml;
//using System.Data;
//using System.Windows.Forms.DataVisualization.Charting;

//namespace WinFormsApp1
//{
//    internal class ExportToWord
//    {
//        private int count = 0; // Добавленное поле для подсчета количества сохраненных файлов

//        public void exportToWord(DataTable dataTable, string filenameMain, string description)
//        {
//            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
//            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
//            {
//                string folderPath = folderBrowserDialog.SelectedPath;
//                string fileName = filenameMain + ".docx";
//                string filePath = Path.Combine(folderPath, fileName);

//                using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
//                {
//                    MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
//                    mainPart.Document = new Document();
//                    Body body = mainPart.Document.AppendChild(new Body());

//                    Paragraph header = body.AppendChild(new Paragraph());
//                    Run headerRun = header.AppendChild(new Run());
//                    headerRun.AppendChild(new Text("Корреляция"));
//                    header.AppendChild(new ParagraphProperties(
//                        new ParagraphStyleId() { Val = "Heading1" }
//                    ));

//                    Paragraph descriptionParagraph = body.AppendChild(new Paragraph());
//                    Run descriptionRun = descriptionParagraph.AppendChild(new Run());
//                    descriptionRun.AppendChild(new Text(description));

//                    Table table = body.AppendChild(new Table());
//                    TableProperties tableProps = new TableProperties(
//                        new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Dxa },
//                        new TableBorders(
//                            new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "auto", Size = "6" },
//                            new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "auto", Size = "6" },
//                            new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "auto", Size = "6" },
//                            new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "auto", Size = "6" },
//                            new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "auto", Size = "6" },
//                            new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "auto", Size = "6" }
//                        )
//                    );
//                    table.AppendChild(tableProps);

//                    // Добавляем заголовок таблицы
//                    TableRow headerRow = new TableRow();
//                    foreach (DataColumn column in dataTable.Columns)
//                    {
//                        TableCell headerCell = new TableCell();
//                        headerCell.AppendChild(new Paragraph(new Run(new Text(column.ColumnName))));
//                        headerRow.AppendChild(headerCell);
//                    }
//                    table.AppendChild(headerRow);

//                    // Добавляем данные в таблицу
//                    foreach (DataRow row in dataTable.Rows)
//                    {
//                        TableRow dataRow = new TableRow();
//                        foreach (var item in row.ItemArray)
//                        {
//                            TableCell dataCell = new TableCell();
//                            dataCell.AppendChild(new Paragraph(new Run(new Text(item.ToString()))));
//                            dataRow.AppendChild(dataCell);
//                        }
//                        table.AppendChild(dataRow);
//                    }

//                    Paragraph chartDescription = body.AppendChild(new Paragraph());
//                    Run chartDescriptionRun = chartDescription.AppendChild(new Run());
//                    chartDescriptionRun.AppendChild(new Text("График показывает зависимость нескольких величин по годам. На графике представлены данные по ВВП, продолжительности жизни, уровню безработицы, инфляции и смертности"));
//                }

//                MessageBox.Show("Файл успешно сохранен.");
//            }
//        }

//        public void ExportChartToWord(Chart chart, string filenameMain, string country, string variable, string fisherTest, double fStatistic, double pValue)
//        {
//            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
//            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
//            {
//                string folderPath = folderBrowserDialog.SelectedPath;
//                string fileName = filenameMain + "_" + count + ".docx";
//                string filePath = Path.Combine(folderPath, fileName);

//                using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
//                {
//                    MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
//                    mainPart.Document = new Document();
//                    Body body = mainPart.Document.AppendChild(new Body());

//                    Paragraph header = body.AppendChild(new Paragraph());
//                    Run headerRun = header.AppendChild(new Run());
//                    headerRun.AppendChild(new Text("Полиномиальная регрессия"));
//                    header.AppendChild(new ParagraphProperties(
//                        new ParagraphStyleId() { Val = "Heading1" }
//                    ));

//                    Paragraph countryParagraph = body.AppendChild(new Paragraph());
//                    Run countryRun = countryParagraph.AppendChild(new Run());
//                    countryRun.AppendChild(new Text("Страна: " + country));

//                    Paragraph variableParagraph = body.AppendChild(new Paragraph());
//                    Run variableRun = variableParagraph.AppendChild(new Run());
//                    variableRun.AppendChild(new Text("Выбранное поле: " + variable));

//                    // Создаем изображение из диаграммы
//                    MemoryStream stream = new MemoryStream();
//                    chart.SaveImage(stream, ChartImageFormat.Png);
//                    stream.Seek(0, SeekOrigin.Begin);

//                    // Добавляем изображение в документ
//                    Drawing drawing = new Drawing();
//                    drawing.Inline = new Inline(
//                        new Graphic(
//                            new GraphicData(
//                                new Picture(
//                                    new NonVisualPictureProperties(
//                                        new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "Picture 1" },
//                                        new NonVisualPictureProperties()
//                                    ),
//                                    new BlipFill(
//                                        new Blip(
//                                            new BlipExtensionList(
//                                                new BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" }
//                                            )
//                                            {
//                                                Embed = stream.ToArray(),
//                                                CompressionState = BlipCompressionValues.Print
//                                            },
//                                        new Stretch(
//                                            new FillRectangle()
//                                        )
//                                    ),
//                                    new ShapeProperties(
//                    new Transform2D(
//                                            new Offset() { X = 0L, Y = 0L },
//                                            new Extents() { Cx = 9900000L, Cy = 7920000L }
//                                        ),
//                                        new PictureProperties(
//                                            new NonVisualPictureProperties()
//                                        )
//                                    )
//                                )
//                            )
//                        )
//                    );
//                    Paragraph imageParagraph = body.AppendChild(new Paragraph());
//                    imageParagraph.AppendChild(drawing);

//                    // Добавляем ячейки в таблицу с границами
//                    Table table = body.AppendChild(new Table());
//                    TableProperties tableProps = new TableProperties(
//                        new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Dxa },
//                        new TableBorders(
//                            new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "auto", Size = "6" },
//                            new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "auto", Size = "6" },
//                            new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "auto", Size = "6" },
//                            new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "auto", Size = "6" },
//                            new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "auto", Size = "6" },
//                            new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "auto", Size = "6" }
//                        )
//                    );
//                    table.AppendChild(tableProps);

//                    // Добавляем заголовок таблицы
//                    TableRow headerRow = new TableRow();
//                    TableCell headerCell = new TableCell();
//                    headerCell.AppendChild(new Paragraph(new Run(new Text("Критерий Фишера"));
//                    headerRow.AppendChild(headerCell);
//                    table.AppendChild(headerRow);

//                    // Добавляем данные в таблицу
//                    TableRow dataRow1 = new TableRow();
//                    TableCell dataCell1 = new TableCell();
//                    dataCell1.AppendChild(new Paragraph(new Run(new Text("Фрасчетное");
//                    dataRow1.AppendChild(dataCell1);
//                    TableCell dataCell2 = new TableCell();
//                    dataCell2.AppendChild(new Paragraph(new Run(new Text(fStatistic.ToString());
//                    dataRow1.AppendChild(dataCell2);
//                    table.AppendChild(dataRow1);

//                    TableRow dataRow2 = new TableRow();
//                    TableCell dataCell3 = new TableCell();
//                    dataCell3.AppendChild(new Paragraph(new Run(new Text("Фтабличное");
//                    dataRow2.AppendChild(dataCell3);
//                    TableCell dataCell4 = new TableCell();
//                    dataCell4.AppendChild(new Paragraph(new Run(new Text(pValue.ToString());
//                    dataRow2.AppendChild(dataCell4);
//                    table.AppendChild(dataRow2);

//                    TableRow dataRow3 = new TableRow();
//                    TableCell dataCell5 = new TableCell();
//                    dataCell5.AppendChild(new Paragraph(new Run(new Text("");
//                    dataRow3.AppendChild(dataCell5);
//                    TableCell dataCell6 = new TableCell();
//                    dataCell6.AppendChild(new Paragraph(new Run(new Text(fisherTest);
//                    dataRow3.AppendChild(dataCell6);
//                    table.AppendChild(dataRow3);
//                }

//                count++;

//                MessageBox.Show("Файл успешно сохранен.");
//            }
//        }
//    }
//}
