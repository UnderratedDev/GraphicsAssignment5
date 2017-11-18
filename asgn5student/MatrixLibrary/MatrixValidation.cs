using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    static class MatrixValidation
    {
        /*
           if (columns != rows || columns <= scaling.Length - 1 || rows <= scaling.Length - 1)
           {
               return null;
           }
           if (columns != rows || columns <= reflect.Length - 1 || rows <= reflect.Length - 1)
            {
                return null;
            }
            if (a == null || a.getColumns() != a.getRows() || a.getColumns() != b.getColumns() || a.getRows() != b.getRows())
            {
                return false;
            }

            if (columns != rows || columns <= translation.Length - 1)
           {
               return null;
           }

           if (size < 1)
                throw new Exception("Minimum size 1 for an identity matrix");
       */

        public static bool validateIdentityMatrixSize(int s) {
            return s < 1;
        }
        public static bool validateReflectScaling(int r, int c, int l) {
            return (c !=r || c <= l - 1 || r <= l - 1) ? true : false;
        }
        public static bool validateTranslation(int r, int c, int l) {
            return (c != r || c <= l - 1) ? true : false;
        }
        public static bool validateInverse(Matrix a, Matrix b) {
            return (a == null || a.getColumns() != a.getRows() || a.getColumns() != b.getColumns() || a.getRows() != b.getRows()) ? true : false;
        }
    }
}
