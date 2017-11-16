using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    static class TransformationsHelper
    {
        private static Matrix identity2D = MatrixManipulation.generateIdentityMatrix(3);

        private static Matrix translateMatrix(int columns, int rows, params double[] translation)
        {
            if (columns != rows || columns <= translation.Length - 1)
            {
                return null;
            }
            Matrix a = MatrixManipulation.generateIdentityMatrix(columns);
            int rowIndex = rows - 1;
            for (int x = 0; x < translation.Length; ++x)
            {
                a.insertValue(rowIndex, x, translation[x]);
            }
            return a;
        }

        private static Matrix shear2DMatrix(double x, double y) {
            Matrix a = identity2D;
            a.insertValue(0, 1, x);
            a.insertValue(1, 0, y);
            return a;
        }

        private static Matrix scaleMatrix (int columns, int rows, params double[] scaling)
        {
            if (columns != rows || columns <= scaling.Length - 1 || rows <= scaling.Length - 1)
            {
                return null;
            }
            Matrix a = MatrixManipulation.generateIdentityMatrix(columns);
            for (int index = 0; index < scaling.Length; ++index)
            {
                a.insertValue(index, index, scaling[index]);
            }
            return a;
        }

        private static Matrix rotate2DMatrix(double rot) {
            Matrix a = identity2D;
            a.insertValue(0, 0, Math.Cos(rot));
            a.insertValue(1, 0, Math.Sin(rot));
            a.insertValue(0, 1, -Math.Sin(rot));
            a.insertValue(1, 1, Math.Cos(rot));
            return a;
        }

        private static Matrix reflectMatrix(int columns, int rows, params bool[] reflect)
        {
            if (columns != rows || columns <= reflect.Length - 1 || rows <= reflect.Length - 1)
            {
                return null;
            }

            Matrix a = MatrixManipulation.generateIdentityMatrix(columns);
            for (int index = 0; index < reflect.Length; ++index)
            {
                a.insertValue(index, index, reflect[index] ? -1 : 1);
            }
            return a;
        }

        public static Matrix translate (Matrix a, params double[] translation)
        {
            Matrix translate = translateMatrix(a.getXLen(), a.getYLen(), translation);
            Matrix result = MatrixManipulation.multiplyMatrices(a, translate);
            return result;
        }

        public static Matrix scale (Matrix a, params double[] scaling)
        {
            Matrix scale = scaleMatrix(a.getXLen(), a.getYLen (), scaling);
            Matrix result = MatrixManipulation.multiplyMatrices(a, scale);
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

        public static Matrix reflect (Matrix a, params bool[] reflect)
        {
            Matrix reflection = reflectMatrix(a.getXLen(), a.getYLen(), reflect);
            Matrix result = MatrixManipulation.multiplyMatrices(a, reflection);
            return result;
        }

        public static Matrix tNet (params Matrix[] matricies)
        {
            Matrix tNet = identity2D;
            for (int i = 0; i < matricies.Length; ++i)
                tNet = MatrixManipulation.multiplyMatrices(tNet, matricies[i]);

            return tNet;
        }
    }
}