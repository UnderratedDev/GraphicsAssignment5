using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    static class TransformationsHelper {
        private static Matrix identity2D = MatrixManipulation.generateIdentityMatrix(3);
        private static Matrix identity3D = MatrixManipulation.generateIdentityMatrix(4);
        private static int minTransformationMatrixSize = 3;

        private static bool minTransformationMatrix (int columns, int rows)
        {
            return (columns > minTransformationMatrixSize && rows > minTransformationMatrixSize);
        }

        private static Matrix translateMatrix(int columns, int rows, params double[] translation)
        {
            if (MatrixValidation.validateTranslation(rows, columns, translation.Length))
            {
                return null;
            }
            Matrix a = MatrixManipulation.generateIdentityMatrix(columns);
            int rowIndex = rows - 1;
            for (int x = 0; x < translation.Length; ++x)
            {
                a.insertValue(x, rowIndex, translation[x]);
            }
            return a;
        }

        private static Matrix translateMatrix(int columns, int rows, Matrix translation)
        {
            if (!MatrixValidation.validateNullMatrix(translation))
            {
                return null;
            }

            if (MatrixValidation.validateTranslation(rows, columns, translation.getColumns())) {
                return null;
            }
            
            if (translation.getRows() > 1)
            {
                return null;
            }

            Matrix a = MatrixManipulation.generateIdentityMatrix(columns);
            int m_Columns = translation.getColumns();
            int rowIndex = rows - 1;
            for (int x = 0; x < m_Columns; ++x)
            {
                a.insertValue(x, rowIndex, translation.getValue(x, 0));
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
            if (MatrixValidation.validateReflectScaling(rows, columns, scaling.Length))
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

        private static Matrix rotate3DXMatrix(double rot) {
            Matrix a = identity3D;
            a.insertValue(1 , 1, Math.Cos(rot));
            a.insertValue(2, 1, Math.Sin(rot));
            a.insertValue(1, 2, -Math.Sin(rot));
            a.insertValue(2, 2, Math.Cos(rot));
            return a;
        }

        private static Matrix rotate3DYMatrix(double rot)
        {
            Matrix a = identity3D;
            a.insertValue(0, 0, Math.Cos(rot));
            a.insertValue(2, 0, Math.Sin(rot));
            a.insertValue(0, 2, -Math.Sin(rot));
            a.insertValue(2, 2, Math.Cos(rot));
            return a;
        }

        private static Matrix rotate3DZMatrix(double rot)
        {
            Matrix a = identity3D;
            a.insertValue(0, 0, Math.Cos(rot));
            a.insertValue(1, 0, Math.Sin(rot));
            a.insertValue(0, 1, -Math.Sin(rot));
            a.insertValue(1, 1, Math.Cos(rot));
            return a;
        }

        private static Matrix reflectMatrix(int columns, int rows, params bool[] reflect)
        {
            if (MatrixValidation.validateReflectScaling(rows, columns, reflect.Length))
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
            Matrix translate = translateMatrix(a.getColumns(), a.getRows(), translation);
            Matrix result = a * translate;
            return result;
        }

        public static Matrix translate(Matrix a, Matrix b)
        {
            Matrix translate = translateMatrix(a.getColumns(), a.getRows(), b);
            Matrix result = a * translate;
            return result;
        }
        
        public static Matrix scale (Matrix a, params double[] scaling)
        {
            Matrix scale = scaleMatrix(a.getColumns(), a.getRows(), scaling);
            Matrix result = a * scale;
            return result;
        }

        public static Matrix shear2D(Matrix a, double x, double y) {
            Matrix shear = shear2DMatrix(x, y);
            Matrix result = a * shear;
            return result;
        }

        public static Matrix rotate2D(Matrix a, double rot) {
            Matrix rotation = rotate2DMatrix(rot);
            Matrix result = a * rotation;
            return result;
        }

        public static Matrix rotate3DX(Matrix a, double rot) {
            Matrix rotation = rotate3DXMatrix(rot);
            Matrix result = a * rotation;
            return result;
        }

        public static Matrix rotate3DY(Matrix a, double rot)
        {
            Matrix rotation = rotate3DYMatrix(rot);
            Matrix result = a * rotation;
            return result;
        }

        public static Matrix rotate3DZ(Matrix a, double rot)
        {
            Matrix rotation = rotate3DZMatrix(rot);
            Matrix result = a * rotation;
            return result;
        }

        public static Matrix reflect (Matrix a, params bool[] reflect)
        {
            Matrix reflection = reflectMatrix(a.getColumns(), a.getRows(), reflect);
            Matrix result = a * reflection;
            return result;
        }

        public static Matrix tNet (params Matrix[] matricies)
        {
            Matrix tNet = identity2D;
            for (int i = 0; i < matricies.Length; ++i)
                tNet *= matricies[i];

            return tNet;
        }
    }
}