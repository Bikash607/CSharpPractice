using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class DynamicProgramming_1
    {
        public static string LongestPalindrome(string s)
        {
            int n = s.Length;
            int maxLength = 1;
            string ans = s;
            int[,] dp = new int[n, n];
            if (n == 1)
            {
                return s;
            }

            for (int diff = 0; diff < n; diff++)
            {
                for (int i = 0, j = i + diff; j < n; i++, j++)
                {
                    if (diff == 0)
                    {
                        dp[i, j] = 1;
                    }
                    else if (diff == 1)
                    {
                        dp[i, j] = (s[i] == s[j]) ? 2 : 0;
                    }
                    else
                    {
                        dp[i, j] = (s[i] == s[j]) && (dp[i + 1, j - 1] > 0) ? dp[i + 1, j - 1] + 2 : 0;
                    }

                    if (dp[i, j] > 0 && j - i + 1 > maxLength)
                    {
                        maxLength = j - i + 1;
                        ans = s.Substring(i, maxLength);
                    }
                }
            }

            return ans;
        }
    }
}
