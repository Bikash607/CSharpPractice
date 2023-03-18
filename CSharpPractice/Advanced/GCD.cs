using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class GCD
    {
        public static int Deleteone(List<int> A)
        {
            int n = A.Count;
            int []  suffixGcdArray  = new int[n];
            int maxGCD = int.MinValue;

            suffixGcdArray[n - 1] = A[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                suffixGcdArray[i] = gcd(suffixGcdArray[i + 1], A[i]);
            }

            maxGCD = Math.Max(maxGCD, gcd(0, suffixGcdArray[1]));

            int prefixGCD = A[0];
            for (int i = 1; i < n - 1; i++)
            {
                maxGCD = Math.Max(maxGCD, gcd(prefixGCD, suffixGcdArray[i + 1]));
                prefixGCD = gcd(prefixGCD, A[i]);
            }

            maxGCD = Math.Max(maxGCD, gcd(prefixGCD, 0));
            return maxGCD;
        }

        static int gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return gcd(b, a % b);
            }
        }

        //You are given two positive numbers A and B . You need to find the maximum valued integer X such that:
        // X divides A i.e. A % X = 0
        // X and B are co-prime i.e.gcd(X, B) = 1
        public static int cpFact(int A, int B)
        {
            int ans = 1;
            for (int i = 1; i * i <= A; i++)
            {
                if (A % i == 0)
                {
                    int t;
                    if (i == A / i)
                    {
                        if (gcd(i, B) == 1)
                            ans = Math.Max(ans, i);
                    }
                    else
                    {
                        if (gcd(i, B) == 1)
                            ans = Math.Max(ans, i);
                        if (gcd(A / i, B) == 1)
                            ans = Math.Max(A / i, ans);
                    }
                }
            }
            return ans;
        }
    }
}
