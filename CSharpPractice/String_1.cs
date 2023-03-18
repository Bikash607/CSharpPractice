using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class String_1
    {
        public static List<char> To_lower(List<char> A)
        {
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] >= 'A' && A[i] <= 'Z')
                {
                    A[i] = (char)(A[i] ^ (1 << 5));
                }
            }

            return A;
        }

        public static string ToggleCase(string A)
        {
            StringBuilder x = new StringBuilder(A);
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = (char)(x[i] ^ (1 << 5));
            }

            return x.ToString();
        }

        public static string LongestPalindrome(string A)
        {
            string logestSubstring = string.Empty;
            for (int i = 0; i < A.Length; i++)
            {
                string substring = FindSubString(A, i - 1, i + 1);
                if (logestSubstring.Length < substring.Length)
                {
                    logestSubstring = substring;
                }

                substring = FindSubString(A, i, i + 1);
                if (logestSubstring.Length < substring.Length)
                {
                    logestSubstring = substring;
                }
            }

            return logestSubstring;
        }

        private static string FindSubString(string s, int L, int R)
        {
            while (L >= 0 && R < s.Length)
            {
                if (s[L] != s[R])
                {
                    return s.Substring(L + 1, R - L - 1);
                }

                L--; R++;
            }

            if (L + 1 >= R - 1)
            {
                return string.Empty;
            }

            return s.Substring(L + 1, R - L - 1);
        }

        public static List<int> CountSort(List<int> A)
        {
            int max = A.Max();
            int[] countArra = new int[max + 1];
            for (int i = 0; i < A.Count; i++)
            {
                countArra[A[i]]++;
            }

            int k = 0;
            for (int i = 0; i < countArra.Length; i++)
            {
                while (countArra[i] > 0)
                {
                    A[k] = i;
                    countArra[i]--;
                    k++;
                }
            }

            return A;
        }

        public static string SimpleReverse(string A)
        {
            string s = string.Empty;
            string[] result = A.Split();
            for (int i = result.Length - 1; i >= 0; i--)
            {
                s += result[i].Trim() + " ";
            }

            return s.Trim();
        }

        public static string StringOperations(string A)
        {
            System.Text.StringBuilder x = new System.Text.StringBuilder();
            char[] vowel = { 'a', 'e', 'i', 'o', 'u' };
            for (int i = 0; i < A.Length; i++)
            {
                if (!(A[i] >= 'A' && A[i] <= 'Z'))
                {
                    if (vowel.Contains(A[i]))
                    {
                        x.Append('#');
                    }
                    else
                    {
                        x.Append(A[i]);
                    }
                }
            }

            var res = x.ToString();
            return res + res;
        }

        public static int CountOccurrences(string A)
        {
            int res = 0;
            if (A.Length <= 3)
            {
                return res;
            }

            for (int i = 0; i < A.Length - 3; i++)
            {
                if (A[i] == 'b' && A[i + 1] == 'o' && A[i + 2] == 'b')
                {
                    res++;
                    i += 1;
                }
            }

            return res;
        }

        public static string LongestCommonPrefix(List<string> A)
        {
            string ans = string.Empty;
            A.Sort(compareString);
            string temp = A[0];
            for (int i = 0; i < A[0].Length; i++)
            {
                bool flag = true;
                for (int j = 1; j < A.Count; j++)
                {
                    if (temp[i] != A[j][i])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    ans += temp[i];
                }
            }
            return ans;
        }
        private static int compareString(string a, string b)
        {
            if (a.Length < b.Length)
            {
                return -1;
            }
            else if (a.Length > b.Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int CheckAnagrams(string A, string B)
        {
            if (A.Length != B.Length)
            {
                return 0;
            }
            int[] frequency = new int[26];
            for (int i = 0; i < A.Length; i++)
            {
                frequency[A[i] - 'a']++;
                frequency[B[i] - 'a']--;
            }

            for (int i = 0; i < frequency.Length; i++)
            {
                if (frequency[i] != 0)
                {
                    return 0;
                }
            }

            return 1;

        }

        public static int ChangeCharacter(string A, int B)
        {
            int[] frequencyCount = new int[26];
            int uniqueCharCount = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int idx = A[i] - 'a';
                frequencyCount[idx]++;
                if (frequencyCount[idx] == 1)
                {
                    uniqueCharCount++;
                }
            }

            if (B < 0 || B == uniqueCharCount)
            {
                return uniqueCharCount;
            }

            frequencyCount = frequencyCount.OrderByDescending(x => x).ToArray();
            for (int i = 0; i < frequencyCount.Length; i++)
            {
                if (B - frequencyCount[i] >= 0 && frequencyCount[i] != 0)
                {
                    B -= frequencyCount[i];
                    uniqueCharCount--;
                }
            }

            return uniqueCharCount;
        }

        public static string DefangIPaddr(string address)
        {
            StringBuilder sb = new StringBuilder(address);
            sb.Replace(".", "[.]");
            return sb.ToString();
        }

        public static int NumJewelsInStones(string jewels, string stones)
        {
            int count = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < jewels.Length; i++)
            {
                if (dict.ContainsKey(jewels[i]))
                {
                    dict[jewels[i]]++;
                }
                else
                {
                    dict.Add(jewels[i], 1);
                }
            }

            for(int i =0; i<stones.Length;i++)
            {
                if(dict.ContainsKey(stones[i]))
                {
                    count++;
                }
            }

            return count;
        }

        public static string AddBinary(String A, String B)
        {
            System.Text.StringBuilder res = new System.Text.StringBuilder();
            int i = A.Length - 1;
            int j = B.Length - 1;
            int sum = 0;
            int carry = 0;

            while (i >= 0 || j >= 0)
            {
                sum = carry;
                if (i >= 0)
                {
                    sum = sum + A[i] - '0';          
                }
                if (j >= 0)
                {
                    sum = sum + B[j] - '0';         
                }

                res.Append(sum % 2);                        
                carry = sum / 2;                            
                i--;
                j--;
            }

            if (carry != 0)
            {                                   
                res.Append(1);
            }

            System.Text.StringBuilder res2 = new System.Text.StringBuilder();
            for (int k = res.Length - 1; k >= 0; k--)
            {
                res2.Append(res[k]);
            }

            return res2.ToString();

        }
    }
}
