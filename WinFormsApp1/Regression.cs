using Accord.Statistics.Models.Regression.Linear;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearRegression;

namespace WinFormsApp1
{
    public class Regression
    {
        public double[] PolynomialRegression(double[][] x, double[] y, int degree)
        {
            return MultipleRegression.QR(x, y, intercept: true);
        }
    }
}
