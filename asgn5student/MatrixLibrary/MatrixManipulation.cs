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
    }
}