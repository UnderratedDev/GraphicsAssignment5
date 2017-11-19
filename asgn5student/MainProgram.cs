using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asgn5v1.MatrixLibrary;

namespace asgn5v1
{
    public class MainProgram
    {
        public MainProgram ()
        {
            Matrix a = new Matrix(3, 4);
            Matrix b = new Matrix(3, 3);
            double[,] c = new double[,] { { 1, 4, 7, 10 }, { 2, 5, 8, 11 }, { 3, 6, 9, 12 } };
            double[,] d = new double[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } };
            a.setMatrix(c, 3, 4);
            b.setMatrix(d, 3, 3);

            Matrix e = new Matrix(3, 3);
            double[,] f = new double[,] { { 6, 4, 2 }, { 5, -2, 8 }, { 234, 5, 7 } };
            e.setMatrix(f, 3, 3);

            // Console.WriteLine(f);
            // double derterminent = MatrixManipulation.matrixDeterminant(e);

            Matrix z = MatrixManipulation.generateHomogenousMatrix(e);

            // Console.WriteLine(z);

            // Console.WriteLine(derterminent);

        }
    }
}
