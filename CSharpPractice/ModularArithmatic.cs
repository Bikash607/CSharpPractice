using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class ModularArithmatic
    {
        public static int Divisibilityby8(string A)
        {
            if(A.Length > 3)
            {
                A = A.Substring(A.Length - 3);
            }

            if (int.Parse(A) % 8 == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
