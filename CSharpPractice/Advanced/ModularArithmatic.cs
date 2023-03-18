using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class ModularArithmatic
    {
        public static int PairSumdivisiblebyM(List<int> A, int B)
        {
            int n = A.Count;
            long count = 0;
            int mod = 1000000007;
            Dictionary<int, long> map = new Dictionary<int, long>();
            for (int i = 0; i < n; i++)
            {
                int mod1 = A[i] % B;
                if (map.ContainsKey(mod1))
                {
                    map[mod1]++;
                }
                else
                {
                    map.Add(mod1, 1);
                }
            }

            for (int i = 0; i <= B / 2; i++)
            {
                if (map.ContainsKey(i))
                {
                    long val = map[i];
                    int diff = B - i;
                    if (i == 0)
                    {
                        count += val * (val - 1) / 2;
                    }
                    else if (i == diff)
                    {
                        count += val * (val - 1) / 2;
                    }
                    else
                    {
                        long val1 = 0;
                        if (map.ContainsKey(diff))
                        {
                            val1 = map[diff];
                        }
                        count += val1 * val;
                    }
                }

            }
            return (int)count % mod;
        }
    }
}
