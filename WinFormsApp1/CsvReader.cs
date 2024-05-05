using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class CvsReader
    {
        public List<MorderRow> ReadCsv(String path)
        {
            List<MorderRow> result = new List<MorderRow>();

            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();

                    if (fields.Length < 6 || fields.Length > 7)
                    {
                        continue;
                    }

                    string country = fields[0];
                    double gdp, lifeExpectancy, inflation, unemploymentRate, mortalityRate = 0.0;
                    int year;

                    if (!int.TryParse(fields[1], out year) ||
                        !double.TryParse(fields[2], out gdp) ||
                        !double.TryParse(fields[3], out lifeExpectancy) ||
                        !double.TryParse(fields[4], out inflation) ||
                        !double.TryParse(fields[5], out unemploymentRate))
                    {
                        continue;
                    }

                    if (fields.Length == 6 & !double.TryParse(fields[6], out mortalityRate))
                    {
                        continue;
                    }

                    if(inflation < 0 || year < 0 || mortalityRate < 0 || gdp < 0 || lifeExpectancy < 0 || lifeExpectancy > 120 || unemploymentRate > 100 || unemploymentRate < 0) {
                        MessageBox.Show("Ошибка в данных - " + country + " - " + year);
                        throw new Exception("Ошибка чтения из файла");
                    }

                    MorderRow row = new MorderRow
                    {
                        Country = country,
                        Year = year,
                        Gdp = gdp,
                        LifeExpectancy = (int)lifeExpectancy,
                        UnemploymentRate = unemploymentRate,
                        InflationRate = inflation,
                        MortalityRate = (int)mortalityRate
                    };

                    result.Add(row);
                }
            }

            return result;
        }
    }
}
