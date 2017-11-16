using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    static class MatrixManipulation
    {

        public static Matrix inverseMatrix(Matrix a)
        {
            if (a == null || a.getColumns() != a.getRows())
                return null;


            return null;
        }

        public static Matrix generateIdentityMatrix (int size)
        {
            if (size == 0)
                return null;

            Matrix a = new Matrix(size, size);

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (i == j)
                    {
                        a.insertValue(i, j, 1);
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