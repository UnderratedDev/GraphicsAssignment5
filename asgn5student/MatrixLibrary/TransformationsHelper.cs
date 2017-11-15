using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    static class TransformationsHelper
    {
        private static Matrix blank2D = new Matrix (3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1} });

        private static Matrix translate2DMatrix (double x, double y)
        {
            Matrix a = blank2D;
            a.insertValue(0, 2, x);
            a.insertValue(1, 2, y);
            return a;
        }

        private static Matrix shear2DMatrix(double x, double y) {
            Matrix a = blank2D;
            a.insertValue(0, 1, x);
            a.insertValue(1, 0, y);
            return a;
        }

        private static Matrix rotate2DMatrix(double rot) {
            Matrix a = blank2D;
            a.insertValue(0, 0, Math.Cos(rot));
            a.insertValue(1, 0, Math.Sin(rot));
            a.insertValue(0, 1, -Math.Sin(rot));
            a.insertValue(1, 1, Math.Cos(rot));
            return a;
        }

        public static Matrix translate2D (Matrix a, double x, double y)
        {
            Matrix translate = translate2DMatrix(x, y);
            Matrix result = MatrixManipulation.multiplyMatrices(a, translate);
            return result;
        }

        public static Matrix shear2D(Matrix a, double x, double y) {
            Matrix shear = shear2DMatrix(x, y);
            Matrix result = MatrixManipulation.multiplyMatrices(a, shear);
            return result;
        }

        public static Matrix rotate2D(Matrix a, double rot) {
            Matrix rotation = rotate2DMatrix(rot);
            Matrix result = MatrixManipulation.multiplyMatrices(a, rotation);
            return result;
        }

    }
}
