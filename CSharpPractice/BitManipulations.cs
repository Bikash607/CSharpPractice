using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class BitManipulations
    {
        public static int AnyBaseToDecimal(int A, int B)
        {
            int ans = 0;
            int i = 0;
            int x;
            while(((int)(A/10)) !=0)
            {
                x = A % 10;
                ans += x * (int)Math.Pow(B, i);

                i++;
                A /= 10;
            }

            x = A % 10;
            ans += x * (int)Math.Pow(B, i);

            return ans;
        }

        public static int DecimalToAnyBase(int A, int B)
        {
            int x;
            int i = 0;
            int ans = 0;
            while(A>1)
            {
                x = A % B;
                ans += x * (int)Math.Pow(10, i);
                i++;
                A = A/ B;
            }

            x = A % B;
            ans += x * (int)Math.Pow(10, i);

            return ans;
        }

        //array contains only 0 and 1
        public static long SubArrayWithBitWiseOr1(int A, List<int> B)
        {
            long ans = 0;
            long possibleSubArrayWithTheIndex = 0;
            for (int i = 0; i < A; i++)
            {
                if (B[i] == 1)
                {
                    possibleSubArrayWithTheIndex = i + 1;
                }

                ans += possibleSubArrayWithTheIndex;
            }
            return ans;
        }

        public static string InterestingArray(List<int> A)
        {
            int sum = 0;
            for (int i = 0; i < A.Count; i++)
            {
                sum += A[i];
            }

            if ((sum & 1) == 0)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
    }
}
