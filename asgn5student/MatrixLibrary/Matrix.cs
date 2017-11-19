using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    class Matrix
    {
        private int columns;
        private int rows;
        private double[,] matrix;

        public Matrix(int columns, int rows)
        {
            this.columns = columns;
            this.rows = rows;
            this.matrix = new double[columns, rows];
        }

        public Matrix(int columns, int rows, double[,] matrix)
        {
            this.columns = columns;
            this.rows = rows;
            this.matrix = matrix;
        }

        public void setColumns(int columns)
        {
            this.columns = columns;
            this.matrix = new double[columns, rows];
        }

        public void setRows(int rows)
        {
            this.rows = rows;
            this.matrix = new double[columns, rows];
        }

        public void setMatrix(double[,] matrix, int x, int y)
        {
            this.matrix = matrix;
            columns = x;
            rows = y;
        }

        public int getColumns()
        {
            return columns;
        }

        public int getRows()
        {
            return rows;
        }

        public double[,] getMatrix()
        {
            return this.matrix;
        }

        public void insertValue(int x, int y, double value)
        {
            this.matrix[x, y] = value;
        }

        public double getValue(int x, int y)
        {
            return this.matrix[x, y];
        }

        public Matrix getRange(int x, int y, int x_, int y_)
        {
            if (x_ < x || y_ < y)
            {
                throw new Exception("Invalid range");
            }

            int columns = x_ - x + 1;
            int rows = y_ - y + 1;

            Matrix b = new Matrix(columns, rows);
            int col = 0, row = 0;
            for (int i = x; i <= x_; ++i)
            {

                for (int j = y; j <= y_; ++j)
                {
                    b.insertValue(col, row++, this.getValue(i, j));
                }
                row = 0;
                ++col;
            }

            return b;
        }

        public static Matrix operator+ (Matrix a, Matrix b)
        {
            if (a == null || b == null) 
            {
                throw new Exception("Matrix is null");
            }

            if (a.getColumns() != b.getColumns())
            {
                throw new Exception("Column sizes do not match");
            }

            if (a.getRows() != b.getRows())
            {
                throw new Exception("Row sizes do not match");
            }

            int width = a.getColumns();
            int height = b.getRows();

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

        public static Matrix operator- (Matrix a, Matrix b)
        {
            if (a == null || b == null)
            {
                throw new Exception("Matrix is null");
            }

            if (a.getColumns() != b.getColumns())
            {
                throw new Exception("Column sizes do not match");
            }

            if (a.getRows() != b.getRows())
            {
                throw new Exception("Row sizes do not match");
            }
            int width = a.getColumns();
            int height = b.getRows();

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

        public static Matrix operator* (Matrix a, Matrix b)
        {
            if (a == null || b == null)
            {
                throw new Exception("Matrix is null");
            }

            if (a.getColumns() != b.getRows())
            {
                throw new Exception("Columns do not match multiplier matrix row");
            }

            int width = b.getColumns();
            int height = a.getRows();
            int colLength = a.getColumns();

            Matrix c = new Matrix(width, height);

            double value = 0;

            for (int row = 0; row < width; ++row)
            {
                for (int col = 0; col < height; ++col)
                {
                    for (int ndx = 0; ndx < colLength; ++ndx)
                    {
                        value = c.getValue(row, col);
                        value += a.getValue(ndx, col) * b.getValue(row, ndx);
                        c.insertValue(row, col, value);
                    }
                }
            }
            return c;
        }

        public static Matrix operator* (Matrix a, double multiplier)
        {
            if (a == null)
            {
                throw new Exception("Matrix is null");
            }

            int width = a.getColumns();
            int height = a.getRows();

            Matrix b = new Matrix(width, height);

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    b.insertValue(x, y, a.getValue(x, y) * multiplier);
                }
            }

            return b;
        }

        /*
         * Not a "proper" mathematical division of a matrix however it is the same as multiplying by 1/10 if dividing by 10
        */
        public static Matrix operator/ (Matrix a, double divisor)
        {
            return a * (MathematicalHelper.Invert(divisor));
        }

        public static bool operator== (Matrix a, Matrix b)
        {

            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }
            else if (object.ReferenceEquals(b, null) || a.getColumns() != b.getColumns() || a.getRows() != b.getRows())
            {
                return false;
            }

            int width = a.getColumns();
            int height = a.getRows();
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    if (a.getValue(i, j) != b.getValue(i, j))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }
        
        /*
         * Operator overloading for ., concatination (concat) / appending of matricies
         */

        public override string ToString ()
        {
            string print = "";
            for (int y = 0; y < rows; ++y)
            {
                print += "[";
                for (int x = 0; x < columns; ++x)
                {
                    print += this.matrix[x, y] + " ";
                }
                print += "]\n";
            }
            return print;
        }

        public override bool Equals(object obj)
        {
            var matrix = obj as Matrix;
            return matrix != null &&
                   columns == matrix.columns &&
                   rows == matrix.rows &&
                   EqualityComparer<double[,]>.Default.Equals(this.matrix, matrix.matrix);
        }

        public override int GetHashCode()
        {
            var hashCode = -2012147648;
            hashCode = hashCode * -1521134295 + columns.GetHashCode();
            hashCode = hashCode * -1521134295 + rows.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<double[,]>.Default.GetHashCode(matrix);
            return hashCode;
        }

        /*
         * ++, --, divide and conquer, n^2, homogoues coordinates, append
         */
    }
}
