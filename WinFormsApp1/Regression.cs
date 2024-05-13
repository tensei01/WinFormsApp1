using Accord.Statistics.Models.Regression.Linear;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Statistics;
using Microsoft.Vbe.Interop.Forms;
using MathNet.Numerics.Distributions;

namespace WinFormsApp1
{
    public class Regression
    {
        public static double[] PolynomialRegression(double[] x, double[] y)
        {
            return Fit.Polynomial(x, y, 2);
        }

        public static double[] calculateRegression(List<MorderRow> filteredData, String text) {

            double[] mortalityRates = Array.ConvertAll(filteredData.Select(m => m.MortalityRate).ToArray(), x => (double)x);
            double[] variableValues= getValues(filteredData, text);

            double[] coefficients = PolynomialRegression(variableValues, mortalityRates);

            double[] predictedMortalityRates;
            switch (text)
            {
                case "ВВП":
                    predictedMortalityRates = filteredData.Select(m => coefficients[0] + coefficients[1] * m.Gdp + coefficients[2] * Math.Pow(m.Gdp, 2)).ToArray();
                    break;
                case "Продолжительность жизни":
                    predictedMortalityRates = Array.ConvertAll(filteredData.Select(m => coefficients[0] + coefficients[1] * m.LifeExpectancy + coefficients[2] * Math.Pow(m.LifeExpectancy, 2)).ToArray(), x => (double)x);
                    break;
                case "Уровень безработицы":
                    predictedMortalityRates = filteredData.Select(m => coefficients[0] + coefficients[1] * m.UnemploymentRate + coefficients[2] * Math.Pow(m.UnemploymentRate, 2)).ToArray();
                    break;
                case "Инфляция":
                    predictedMortalityRates = filteredData.Select(m => coefficients[0] + coefficients[1] * m.InflationRate + coefficients[2] * Math.Pow(m.InflationRate, 2)).ToArray();
                    break;
                default:
                    throw new InvalidOperationException("Invalid variable selected.");
            }

            return predictedMortalityRates;
        }

        public static (double fStatistic, double pValue) CalculateFisherFStatistic(List<MorderRow> filteredData, String text)
        {
            double[] x = getValues(filteredData, text);
            double[] y = Array.ConvertAll(filteredData.Select(data => data.MortalityRate).ToArray(), ys => (double) ys);
            double[] yPredicate = new double[y.Length];
            double[] coefficients = PolynomialRegression(x, y);
            double sse = 0;
            double sst = 0;

            for (int i = 0; i < y.Length; i++)
            {
                yPredicate[i] = coefficients[0] + coefficients[1] * x[i] + coefficients[2] * Math.Pow(x[i], 2);
            }

            double avgY = yPredicate.Average();

            for (int i = 0; i < y.Length; i++)
            {
                sse += (y[i] - yPredicate[i]) * (y[i] - yPredicate[i]);
                sst += (yPredicate[i] - avgY) * (yPredicate[i] - avgY);
            }

            double fStatistic = (sst/2) * ((y.Length - 3)/sse);
            double pValue = FisherSnedecor.InvCDF(2, y.Length - 3, 0.95);

            return (fStatistic, pValue);
        }

        private static double[] getValues(List<MorderRow> filteredData, String text) {
            double[] variableValues;

            switch (text)
            {
                case "ВВП":
                    variableValues = filteredData.Select(m => m.Gdp).ToArray();
                    break;
                case "Продолжительность жизни":
                    variableValues = Array.ConvertAll(filteredData.Select(m => m.LifeExpectancy).ToArray(), x => (double)x);
                    break;
                case "Уровень безработицы":
                    variableValues = filteredData.Select(m => m.UnemploymentRate).ToArray();
                    break;
                case "Инфляция":
                    variableValues = filteredData.Select(m => m.InflationRate).ToArray();
                    break;
                default:
                    throw new InvalidOperationException("Invalid variable selected.");
            }

            return variableValues;

        }
    }
}
