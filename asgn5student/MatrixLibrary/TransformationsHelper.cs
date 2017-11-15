using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    static class TransformationsHelper
    {
        private static Matrix translation2D = new Matrix (3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1} });

        public static Matrix translate2DMatrix (double x, double y)
        {
            Matrix a = translation2D;
            a.insertValue(0, 2, x);
            a.insertValue(1, 2, y);
            return a;
        }

        public static Matrix translate2D (Matrix a, double x, double y)
        {
            Matrix translate = translate2DMatrix(x, y);
            Matrix result = MatrixManipulation.multiplyMatrix(a, translate);
            return result;
        }

    }
}
