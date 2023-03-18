using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class BitManipulation_2
    {
        public static int solve(int A)
        {
            long magicNum = 0;
            int i = 1;
            while (A > 0)
            {
                int n = A % 2;
                magicNum += (long)Math.Pow(5, i) * n;
                A >>= 1;
            }

            return (int)magicNum;
        }
    }
}
