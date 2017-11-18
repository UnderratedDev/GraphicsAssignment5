using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    static class MathematicalHelper
    {
        public static double Invert (double number)
        {
            if (number == 0)
            {
                throw new DivideByZeroException();
            }

            return 1 / number;

        }
    }
}
