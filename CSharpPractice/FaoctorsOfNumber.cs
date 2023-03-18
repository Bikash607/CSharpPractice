using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class FaoctorsOfNumber
    {
        public static int NumberOfFactors(int n)
        {
            int count = 0;
            int iteratons = (int)Math.Floor(Math.Sqrt(n));
            for (int i=1; i <= iteratons; i++)
            {
                if (n % i == 0)
                {
                    if (i != n / i)
                    {
                        count += 2;
                    }
                    else
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
