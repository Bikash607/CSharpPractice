using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class BinarySearch_2
    {
        public static int search(List<int> A, int B)
        {
            int l = 0;
            int n = A.Count;
            int h = n - 1;
            int m = 0;
            while (l <= h)
            {
                m = l + (h - l) / 2;
                if (A[m] > A[n - 1])
                {
                    l = m + 1;
                }
                else
                {
                    h = m - 1;
                }
            }

            if(m==0 && A[m+1] > A[m])
            {
                return BSearch(A, 0, n-1, B);
            }
            else if (B > A[n - 1])
            {
                return BSearch(A, 0, m, B);
            }
            else
            {
                return BSearch(A, m + 1, n - 1, B);
            }
        }

        public static int BSearch(List<int> A, int s, int e, int B)
        {
            while (s <= e)
            {
                int m = s + (e - s) / 2;
                if (A[m] == B)
                {
                    return m;
                }
                else if (B > A[m])
                {
                    s = m + 1;
                }
                else
                {
                    e = m - 1;
                }
            }

            return -1;
        }
    }
}
