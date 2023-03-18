using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class StringPatternMatching
    {
        public static int BoringSubstring(String A)
        {
            int evenMax = int.MinValue;
            int evenMin = int.MaxValue;
            int oddMax = int.MinValue;
            int oddMin = int.MaxValue;

            int n = A.Length;
            for (int i = 0; i < n; i++)
            {
                int val = (int)(A[i] - 'a') + 1;
                if (val % 2 == 0)
                {
                    evenMax = Math.Max(evenMax, val);
                    evenMin = Math.Min(evenMin, val);
                }
                else
                {
                    oddMax = Math.Max(oddMax, val);
                    oddMin = Math.Min(oddMin, val);
                }
            }

            if (Math.Abs(evenMax - oddMin) != 1 || Math.Abs(oddMax - evenMin) != 1)
                return 1;
            return 0;
        }
    }
}
