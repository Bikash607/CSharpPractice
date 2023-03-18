using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class BinarySearch_3
    {
        public static int AthMagicalNumber(int A, int B, int C)
        {
            long l = 1, ans = 0;
            long h = (long)A * Math.Min(B, C);
            long lcm = (long)(B * C) / gcd(B, C);
            int mod = 1000000007;
            while (l <= h)
            {
                long m = (l + h) / 2;
                long num = (m / B) + (m / C) - (m / lcm);

                if (num >= A)
                {
                    ans = m;
                    h = m - 1;
                }
                else l = m + 1;
            }

            if (ans < 0)
            {
                ans += mod;
            }
            return (int)(ans % mod);
        }

        public static int gcd(int x, int y)
        {
            if (x == 0)
                return y;
            return gcd(y % x, x);
        }
    }
}
