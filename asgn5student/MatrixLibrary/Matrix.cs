using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    class Matrix
    {
        private int x_len;
        private int y_len;
        private double[,] matrix;

        public Matrix (int x, int y)
        {
            this.x_len = x;
            this.y_len = y;
            this.matrix = new double[x_len, y_len];
        }

        public Matrix (int x, int y, double [,] matrix)
        {
            this.x_len = x;
            this.y_len = y;
            this.matrix = matrix;
        }

        public void setXLen (int x)
        {
            this.x_len = x;
            this.matrix = new double[x_len, y_len];
        }
        
        public void setYLen (int y)
        {
            this.y_len = y;
            this.matrix = new double[x_len, y_len];
        }

        public void setMatrix(double[,] matrix, int x, int y)
        {
            this.matrix = matrix;
            x_len = x;
            y_len = y;
        }

        public int getXLen ()
        {
            return x_len;
        }

        public int getYLen()
        {
            return y_len;
        }

        public double[,] getMatrix()
        {
            return this.matrix;
        }

        public void insertValue (int x, int y, double value)
        {
            this.matrix[x, y] = value;
        }

        public double getValue (int x, int y)
        {
            return this.matrix[x, y];
        }

        public void printMatrix ()
        {
            for (int y = 0; y < y_len; ++y)
            {
                Console.Write("[");
                for (int x = 0; x < x_len; ++x)
                {
                    Console.Write(this.matrix[x, y] + " ");
                }
                Console.WriteLine("]");
            }
           
        }


    }
}
