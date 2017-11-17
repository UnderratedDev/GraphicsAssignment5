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

            /*
            Matrix e = MatrixManipulation.generateIdentityMatrix(4);
            e = TransformationsHelper.scale(e, 2, 3, 8);

            Matrix g = MatrixManipulation.generateIdentityMatrix(3);
            g = TransformationsHelper.scale(g, 2, 5);

            Matrix h = MatrixManipulation.generateIdentityMatrix(4);
            h = TransformationsHelper.scale(h, 2, 5, 6);

            Console.WriteLine(a);

            Console.WriteLine(b);

            Console.WriteLine(e);

            Matrix i = MatrixManipulation.generateIdentityMatrix(5);

            Console.WriteLine(i); */

            Matrix j = MatrixManipulation.generateTransposeMatrix(b);

            Console.WriteLine(b);

            Console.WriteLine(j);

            // Matrix e = a + b;
            // Matrix f = a * b;
            
            // Console.WriteLine(f);
        }
    }
}
