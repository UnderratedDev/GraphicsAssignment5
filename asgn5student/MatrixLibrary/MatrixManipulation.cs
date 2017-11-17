using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asgn5v1.MatrixLibrary;

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
            if (MatrixValidation.validateIdentityMatrixSize(size))
                throw new Exception("Minimum size 1 for an identity matrix");

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
            if (MatrixValidation.validateInverse(a, b))
            {
                return false;
            }

            Matrix c = a * b;

            Matrix identity = generateIdentityMatrix(a.getColumns());

            return c == identity;
        }
    }
}