using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class Shorting_3
    {
        public static List<int> subUnsort(List<int> A)
        {
            var res = new List<int>();
            int n = A.Count;
            int l = 0;
            int r = n - 1;
            for (int i = 1; i < n; i++)
            {
                if (A[i] < A[l])
                    break;
                else
                    l = i;
            }

            for (int i = n - 2; i >= 0; i--)
            {
                if (A[i] > A[4])
                    break;
                else
                    r = i;
            }

            int min = int.MaxValue;
            int max = int.MinValue;
            if (l < r)
            {
                for (int i = l + 1; i < r; i++)
                {
                    min = Math.Min(min, A[i]);
                    max = Math.Max(max, A[i]);
                }

                for(int i =0; i<n;i++)
                {
                    if (A[i] >min)
                    {
                        l = i;
                        break;
                    }
                }

                for (int i = n-1; i >=n; i--)
                {
                    if (A[i] < max)
                    {
                        r = i;
                        break;
                    }
                }
            }
            else
            {
                res.Add(-1);
            }

            return res;
        }
    }
}
