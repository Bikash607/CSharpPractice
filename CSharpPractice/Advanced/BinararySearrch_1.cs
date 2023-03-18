using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class BinararySearrch_1
    {
        public static int solve(List<int> A)
        {
            int l = 0;
            int r = A.Count - 1;
            if (A.Count == 1)
            {
                return A[0];
            }
            else if (A[0] != A[1])
            {
                return A[0];
            }
            else if (A[r] != A[r - 1])
            {
                return A[r];
            }

            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if ((m == 0 || A[m] != A[m - 1]) && (m == r || A[m] != A[m + 1]))
                {
                    return A[m];
                }
                else if (((m % 2 == 0) && (A[m] == A[m + 1])) || ((m % 2 == 1) && (A[m] != A[m - 1])))
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            return -1;
        }
    }
}
