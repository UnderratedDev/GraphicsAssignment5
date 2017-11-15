using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    class MatrixManipulation
    {
        public static Matrix addMatrices (Matrix a, Matrix b)
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
    }
}