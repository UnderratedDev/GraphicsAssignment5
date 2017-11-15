using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    class MatrixManipulation
    {
        public static Matrix addMatricies (Matrix a, Matrix b)
        {
            if (a == null || b == null || a.getXLen() != b.getXLen() || a.getYLen() != b.getYLen ())
            {
                return null;
            }

            int width  = a.getXLen();
            int height = b.getYLen();

            Matrix c = new Matrix(width, height);

            double value = 0;

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    value = a.getValue(x, y) + b.getValue(x, y);
                    c.insertValue(x, y, value);
                }
            }

            return c;
        }

        public static Matrix subtractMatricies(Matrix a, Matrix b)
        {
            if (a == null || b == null || a.getXLen() != b.getXLen() || a.getYLen() != b.getYLen())
            {
                return null;
            }

            int width = a.getXLen();
            int height = b.getYLen();

            Matrix c = new Matrix(width, height);

            double value = 0;

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    value = a.getValue(x, y) - b.getValue(x, y);
                    c.insertValue(x, y, value);
                }
            }

            return c;
        }

        public static Matrix multiplyMatrix (Matrix a, Matrix b)
        {
            if (a == null || b == null || a.getXLen() != b.getYLen())
            {
                return null;
            }

            int width = a.getXLen();
            int height = b.getYLen();

            int colLength = a.getXLen();

                

            Matrix c = new Matrix(width, height);

            double value = 0;

            for (int row = 0; row < height; ++row)
            {
                for (int col = 0; col < width; ++col)
                {
                    for (int ndx = 0; ndx < colLength; ++ndx)
                    {
                        value = c.getValue(row, col);
                        value += a.getValue(row, ndx) * b.getValue (ndx, col);
                        c.insertValue(row, col, value);
                    }
                }
            }

            return c;

        }

        public static Matrix inverseMatrix(Matrix a)
        {
            if (a == null || a.getXLen() != a.getYLen())
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

        public static bool equalsMatrix (Matrix a, Matrix b)
        {
            if (a == null || b == null || a.getXLen() != b.getXLen() || a.getYLen () != b.getYLen ())
            {
                return false;
            }

            int width = a.getXLen();
            int height = a.getYLen();
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    if (a.getValue(i, j) != b.getValue (i, j))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool checkInverse (Matrix a, Matrix b)
        {
            if (a == null || a.getXLen() != a.getYLen() || a.getXLen() != b.getXLen() || a.getYLen() != b.getYLen())
            {
                return false;
            }

            Matrix c = multiplyMatrix(a, b);

            Matrix identity = generateIdentityMatrix(a.getXLen());

            return equalsMatrix(c, identity);
        }
    }
}