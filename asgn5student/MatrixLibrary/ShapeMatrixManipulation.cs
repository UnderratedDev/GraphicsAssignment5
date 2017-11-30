using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    class ShapeMatrixManipulation
    {
        public static Matrix getDimensionLow(Matrix a, int column)
        {
            if (!MatrixValidation.validateNullMatrix(a))
            {
                return null;
            }

            if (!MatrixValidation.validationColumnLength(a, column))
            {
                throw new Exception("Matrix does not contain column for dimension");
            }

            double low = a.getValue(column, 0);

            List<Matrix> lowPoints = new List<Matrix>();
           
            int rows = a.getRows();

            for (int y = 0; y < rows; ++y) {
                if (a.getValue(column, y) < low)
                    low = a.getValue(column, y);
            }

            for (int y = 0; y < rows; ++y) {
                if (a.getValue(column, y) == low) {
                    int columns = a.getColumns();
                    Matrix point = a.getRange(0, y, columns - 1, y);
                    lowPoints.Add(point);
                }
            }

            int columnSZ = lowPoints[0].getColumns();
            int rowSZ    = lowPoints.Count;

            Matrix points = new Matrix(columnSZ, rowSZ);

            int pCol = 0;
            int pRow = 0;

            int mCol = 0;
            int mRow = 0;

            foreach (Matrix m in lowPoints) {
                mCol = m.getColumns();
                mRow = m.getRows();
                for (int y = 0; y < mRow; ++y) {
                    for (int x = 0; x < mCol; ++x) {
                        // Console.WriteLine("HERE : " + m.getValue(x, y) + " " + pCol + " " + pRow + " " + (pCol++ % columnSZ));
                        if (pCol == columnSZ)
                            pCol = 0;

                        // Console.WriteLine(pCol + " " + pRow + " " + x + " " + y + " " + m.getValue(x, y));

                        points.insertValue(pCol++, pRow, m.getValue(x, y));
                    }
                    ++pRow;
                }
            }

            Console.WriteLine(points);

            return points;
        }

        public static Matrix getDimensionHigh(Matrix a, int column) {
            if (!MatrixValidation.validateNullMatrix(a))
            {
                return null;
            }

            if (!MatrixValidation.validationColumnLength(a, column))
            {
                throw new Exception("Matrix does not contain column for dimension");
            }

            double high = a.getValue(column, 0);

            List<Matrix> highPoints = new List<Matrix>();

            int rows = a.getRows();

            for (int y = 0; y < rows; ++y)
            {
                if (a.getValue(column, y) > high)
                    high = a.getValue(column, y);
            }

            for (int y = 0; y < rows; ++y)
            {
                if (a.getValue(column, y) == high)
                {
                    int columns = a.getColumns();
                    Matrix point = a.getRange(0, y, columns - 1, y);
                    highPoints.Add(point);
                }
            }

            int columnSZ = highPoints[0].getColumns();
            int rowSZ = highPoints.Count;

            Matrix points = new Matrix(columnSZ, rowSZ);

            int pCol = 0;
            int pRow = 0;

            int mCol = 0;
            int mRow = 0;

            foreach (Matrix m in highPoints)
            {
                mCol = m.getColumns();
                mRow = m.getRows();
                for (int y = 0; y < mRow; ++y)
                {
                    for (int x = 0; x < mCol; ++x)
                    {
                        if (pCol == columnSZ)
                            pCol = 0;

                        points.insertValue(pCol++, pRow, m.getValue(x, y));
                    }
                    ++pRow;
                }
            }

            Console.WriteLine(points);

            return points;
        }
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
            }
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
