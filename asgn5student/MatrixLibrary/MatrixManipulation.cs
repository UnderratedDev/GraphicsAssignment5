using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    static class MatrixManipulation
    {

        public static double matrixDeterminant (Matrix a)
        {
            if (a == null || a.getRows () < 2)
                throw new Exception("Matrix is null");

            int columns = a.getColumns(), rows = a.getRows();

            double result = 0;

            Matrix b = new Matrix(columns - 1, rows - 1);

            int col = 0, row = 0;
           
            for (int x = 0; x < columns; ++x)
            {
                for (int column = 0; column < columns; ++column)
                {
                    if (x == column)
                    {
                        continue;
                    }
                    for (int y = 1; y < rows; ++y)
                    {
                        // b.insertValue(col, row++, a.getValue(x, y));
                    }
                    row = 0;
                    ++col;
                }

                double value = multiplyMatrix(b, a.getValue(x, 0));

                if (x % 2 == 0)
                    result += value;
                else
                    result -= value;
            }

            return result;
        }
        
        public static double multiplyMatrix (Matrix a, double multiplier)
        {

            if (a == null)
                throw new Exception("Matrix is null");

            double result = 0;

            int columns = a.getColumns(), rows = a.getRows();

            for (int x = 0; x < columns; ++x)
            {
                for (int y = 0; y < rows; ++y)
                {
                    result += a.getValue(x, y) * multiplier;
                }
            }

            return result;

        }

        public static Matrix generateInverseMatrix(Matrix a)
        {
            if (a == null)
                throw new Exception("Matrix is null");

            int columns = a.getColumns(), rows = a.getRows();

            return null;
        }

        public static Matrix generateTransposeMatrix (Matrix a)
        {
            if (a == null)
                throw new Exception ("Matrix is null");

            int columns = a.getColumns(), rows = a.getRows();

            Matrix b = new Matrix(rows, columns);

            for (int x = 0; x < columns; ++x)
            {
                for (int y = 0; y < rows; ++y)
                {
                    b.insertValue(y, x, a.getValue(x, y));
                }
            }

            return b;
        }

        public static Matrix generateIdentityMatrix (int size)
        {
            if (MatrixValidation.validateIdentityMatrixSize(size))
                throw new Exception("Minimum size 1 for an identity matrix");

            double[] multiples = new double[size];

            for (int i = 0; i < size; ++i)
            {
                multiples[i] = 1;
            }

            return generateScalarMatrix(multiples);
            
        }

        public static Matrix generateScalarMatrix (params double[] multiples)
        {
            if (multiples.Length < 1)
                throw new Exception("Minimum size 1 for an scalar matrix");

            Matrix a = new Matrix(multiples.Length, multiples.Length);

            for (int i = 0; i < multiples.Length; ++i)
            {
                for (int j = 0; j < multiples.Length; ++j)
                {
                    if (i == j)
                    {
                        a.insertValue(i, j, multiples[i]);
                    }
                }
            }

            return a;
        }

        public static bool checkInverse (Matrix a, Matrix b)
        {
            if (MatrixValidation.validateInverse(a, b))
            {
                return false;
            }

            Matrix c = a * b;

            Matrix identity = generateIdentityMatrix(a.getColumns());

            return c == identity;
        }

        public static Matrix matrixColumnExpander (Matrix a)
        {
            if (!MatrixValidation.validateNullMatrix(a))
            {
                return null;
            }

            int columns = a.getColumns(), rows = a.getRows();

            Matrix b = new Matrix(columns + 1, rows);

            for (int x = 0; x < columns; ++x)
            {
                for (int y = 0; y < rows; ++y)
                {
                    b.insertValue(x, y, a.getValue(x, y));
                }
            }

            return b;

        }

        public static Matrix generateHomogenousMatrix (Matrix a)
        {
            if (!MatrixValidation.validateNullMatrix(a))
            {
                return null;
            }
            Matrix b = matrixColumnExpander(a);

            int homogenousColumn = b.getColumns() - 1, rows = b.getRows();

            for (int y = 0; y < rows; ++y)
            {
                b.insertValue(homogenousColumn, y, 1);
            }

            return b;
        }

        public static Matrix inverseSigns (Matrix a)
        {
            if (!MatrixValidation.validateNullMatrix(a)) {
                return null;
            }

            int columns = a.getColumns(), rows = a.getRows();

            Matrix b = new Matrix(columns, rows);

            for (int x = 0; x < columns; ++x) {
                for (int y = 0; y < rows; ++y) {
                    b.insertValue(x, y, -a.getValue(x, y));
                }
            }

            return b;
        }
    }
}