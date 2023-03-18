using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class Recursion_2
    {
        public static int pow(int A, int B, int C)
        {
            if (A == 0)
            {
                return 0;
            }
            if (B == 0)
            {
                return 1;
            }

            long temp;
            if (B % 2 == 0)
            {
                temp = pow(A, B / 2, C);
                temp = (temp * temp) % C;
            }
            else
            {
                temp = A % C;
                temp = (temp * pow(A, B - 1, C) % C) % C;
            }
            return (int)((temp + C) % C);
        }

        public static int MagicNumber(int A)
        {
            int res = SumOfNumber(A);
            while (res >= 10)
            {
                res = SumOfNumber(res);
            }

            if (res == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int SumOfNumber(int A)
        {
            if (A / 10 == 0)
            {
                return A % 10;
            }

            return SumOfNumber(A / 10) + A % 10;
        }

        public static int KthSumbol(int A, int B)
        {
            if (B == 0)
                return 0;
            int ans = ksymbol("0", A, B) - '0';
            return ans;
        }

        public static char ksymbol(string s, int A, int B)
        {
            if (s.Length > B)
            {
                return s[B];
            }
            System.Text.StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    sb.Append("01");
                }
                else
                {
                    sb.Append("10");
                }
            }
            return ksymbol(sb.ToString(), A - 1, B);
        }

        public static int KthSymbol(int A, long B)
        {
            return find(A, B);
        }

        public static int find(int n, long k)
        {
            if (k == 0)
            {
                return 0;
            }
            int val = find(n - 1, k / 2);
            if (k % 2 == 0)
            {
                return val;
            }

            return 1 - val;
        }
    }
}
