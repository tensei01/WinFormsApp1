using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Context
    {
        public static List<MorderRow> _data { get; set; }

        public static List<MorderRow> _worldData { get; set; }

        public void clear() { 
            _data.Clear();
        }

        public static void calculate(List<MorderRow> data)
        {
            _worldData = data
                .GroupBy(m => m.Year)
                .Select(g => new MorderRow
        {
            Year = g.Key,
            Country = "World",
            Gdp = g.Sum(m => m.Gdp),
            LifeExpectancy = (int) g.Average(m => m.LifeExpectancy),
            UnemploymentRate = g.Average(m => m.UnemploymentRate),
            InflationRate = g.Average(m => m.InflationRate),
            MortalityRate = g.Sum(m => m.MortalityRate)
        })
        .ToList();
        }

    }
}
