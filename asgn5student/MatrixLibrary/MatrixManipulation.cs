using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    static class MatrixManipulation
    {

        public static Matrix generateInverseMatrix(Matrix a)
        {
            if (a == null || a.getColumns() != a.getRows())
                return null;

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
           if (size < 1)
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
            if (a == null || a.getColumns() != a.getRows() || a.getColumns() != b.getColumns() || a.getRows() != b.getRows())
            {
                return false;
            }

            Matrix c = a * b;

            Matrix identity = generateIdentityMatrix(a.getColumns());

            return c == identity;
        }
    }
}