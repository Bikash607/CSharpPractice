using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class PrimeNumbers
    {
        public static List<int> FindAllPrimes(int A)
        {
            List<int> list = new List<int>();
            bool[] ans = new bool[A];
            int n = ans.Length;
            ans[0] = true;
            ans[1] = true;
            for (int i = 2; i * i < n; i++)
            {
                if (ans[i] == false)
                {
                    for (int j = i * i; j < n; j+=i)
                    {
                        ans[j] = true;
                    }
                }
            }

            for (int i = 2; i < n; i++)
            {
                if (ans[i] == false)
                {
                    list.Add(i);
                }
            }

            return list;
        }

        // Given an array of integers A, find and return the count of divisors of each element of the array.
        public static List<int> CountOfDivisors(List<int> A)
        {

            int n = A.Count;

            int max = 0;
            for (int i = 0; i < n; i++)
                max = Math.Max(max, A[i]);

            int[] fn = new int[max + 1];
            for (int i = 0; i < fn.Length; i++)
                fn[i] = 1;

            for (int i = 2; i < fn.Length; i++)
            {
                for (int j = i; j < fn.Length; j = j + i)
                    fn[j] = fn[j] + 1;
            }

            for (int i = 0; i < n; i++)
                A[i] = fn[A[i]];

            return A;
        }
    }
}
