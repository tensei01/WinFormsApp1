﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Correlition
    {
        public double[] PearsonCorrelation(double[,] matrix){
            int n = matrix.GetLength(0);
            int lenght = matrix.GetLength(1);
            int m = matrix.GetLength(1);
            double[,] correlations = new double[lenght, m];

            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    double sumX = 0, sumY = 0, sumXSq = 0, sumYSq = 0, sumXY = 0;
                    for (int k = 0; k < n; k++)
                    {
                        double x = matrix[k, i];
                        double y = matrix[k, j];
                        sumX += x;
                        sumY += y;
                        sumXSq += Math.Pow(x, 2);
                        sumYSq += Math.Pow(y, 2);
                        sumXY += x * y;
                    }
                    double numerator = n * sumXY - sumX * sumY;
                    double denominator = Math.Sqrt((n * sumXSq - Math.Pow(sumX, 2)) * (n * sumYSq - Math.Pow(sumY, 2)));
                    correlations[i, j] = numerator / denominator;
                }
            }

            double[] result = new double[m-1];
            for (int i = 0; i < m-1; i++) {
                result[i] = Math.Round(correlations[lenght-1, i], 4);
            }

            return result;
        }

        public List<InfoCorrelation> getInfoCorrelation(double[] info) {
            List<InfoCorrelation> infoCorrelation = new List<InfoCorrelation> ();
            for (int i = 0; i < info.Length; i++) {
                InfoCorrelation correlation = new InfoCorrelation();
                String result;
                double value = info[i];
                if (value > 0)
                {
                    result = "Положительная " + getinfo(value);
                }
                else {
                    result = "Отрицательная " + getinfo(Math.Abs(value));
                }
                correlation.info = result;
                correlation.value = value;
                infoCorrelation.Add(correlation);
            }
            return infoCorrelation;
        }

        private String getinfo(double value) {
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
            else {
                return "очень сильная корреляция";
            }
        }

    }

    public class InfoCorrelation {

        public String info { get; set; }

        public double value { get; set; }
    
    }
}
