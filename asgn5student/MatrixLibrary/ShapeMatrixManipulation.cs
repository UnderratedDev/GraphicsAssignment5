using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    class ShapeMatrixManipulation
    {
        public static double getDimensionPolygon(Matrix a, int column)
        {
            if (!MatrixValidation.validateNullMatrix(a)) {
                return 0;
            }

            if (!MatrixValidation.validationColumnLength(a, column)) {
                throw new Exception("Matrix does not contain column for dimension");
            }

            double low = a.getValue(column, 0);
            double high = low;
            int rows = a.getRows();

            for (int y = 0; y < rows; ++y)
            {
                if (a.getValue(column, y) < low)
                    low = a.getValue(column, y);
                else if (a.getValue(column, y) > high)
                    high = a.getValue(column, y);
                Console.WriteLine(high);
                Console.WriteLine(low);
            }
            Console.WriteLine("width: " + (high - low));
            return high - low;
        }

        public static double getWidthPolygonMatrix2D(Matrix a) {
            return getDimensionPolygon(a, 0);
        }

        public static double getHeightPolygonMatrix2D(Matrix a) {
            return getDimensionPolygon(a, 1);
        }

        public static double getLengthPolygonMatrix3D(Matrix a) {
            return getDimensionPolygon(a, 2);
        }
    }
}
