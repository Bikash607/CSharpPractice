using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class Hashing_2
    {
        public static List<int> DNums(List<int> A, int B)
        {
            Dictionary<int, int> hm = new Dictionary<int, int>();
            List<int> ans = new List<int>();
            int elm = 0;
            for (int i = 0; i < B - 1; i++)
            {
                if (hm.ContainsKey(A[i]))
                {
                    hm[A[i]]++;
                }
                else
                {
                    hm.Add(A[i], 1);
                    elm++;
                }
            }

            for (int j = 0, i = B - 1; i < A.Count; i++, j++)
            {
                if (hm.ContainsKey(A[i]))
                {
                    ans.Add(elm);
                    hm[A[i]]++;
                }
                else
                {
                    elm++;
                    ans.Add(elm);
                    hm.Add(A[i], 1);
                }

                if (hm[A[j]] > 1)
                {
                    hm[A[j]]--;
                }
                else
                {
                    elm--;
                    hm.Remove(A[j]);
                }
            }

            return ans;
        }

        public static int CountPairSum(List<int> A, int B)
        {
            Dictionary<int, int> hs = new Dictionary<int, int>();
            int count = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (hs.ContainsKey(B - A[i]) && B != (B - A[i]))
                {
                    count += hs[B - A[i]];
                }

                if (hs.ContainsKey(A[i]))
                {
                    hs[A[i]]++;
                }
                else
                {
                    hs.Add(A[i], 1);
                }
            }

            return count;
        }

        public static int CountPairDifference(List<int> A, int B)
        {
            Dictionary<int, int> hs = new Dictionary<int, int>();
            int count = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (hs.TryGetValue(A[i] + B, out int c))
                {
                    count = (count + c) % 1000000007;
                }
                if (hs.TryGetValue(A[i] - B, out int c1))
                {
                    count = (count + c1) % 1000000007;
                }

                if (hs.ContainsKey(A[i]))
                {
                    hs[A[i]]++;
                }
                else
                {
                    hs.Add(A[i], 1);
                }
            }

            return count;
        }

        public static int SubarraySumEqualsK(List<int> A, int B)
        {
            Dictionary<int, int> hm = new Dictionary<int, int>();
            int prefixSum = 0;
            int count = 0;
            hm.Add(0, 1);
            for (int i = 0; i < A.Count; i++)
            {
                prefixSum += A[i];
                if (hm.ContainsKey(prefixSum - B))
                {
                    count += hm[prefixSum - B];
                }

                if (hm.ContainsKey(prefixSum))
                {
                    hm[prefixSum]++;
                }
                else
                {
                    hm.Add(A[i], 1);
                }
            }

            return count;
        }

        public static List<int> Subarraywithgivensum(List<int> A, int B)
        {
            long n = A.Count;
            int l = 0, r = 0;
            long sum = A[l];
            while (r < n && l <= r)
            {
                if (sum == B)
                {
                    List<int> ans = new List<int>();
                    for (int i = l; i <= r; i++)
                        ans.Add(A[i]);
                    return ans;
                }
                else if (sum < B)
                {
                    r++;
                    if (r < n) sum += A[r];
                }
                else
                {
                    sum -= A[l];
                    l++;
                    if (l > r && l < n - 1)
                    {
                        r++;
                        sum += A[r];
                    }
                }
            }

            return new List<int>() { -1 };
        }

        public static int isValidSudoku(List<string> A)
        {
            HashSet<string> hs = new HashSet<string>();
            int boxNumber = 0;
            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    if (A[i][j] != '.')
                    {
                        boxNumber = (i / 3) * 3 + (j / 3);

                        string columnKey = $"column {j} value {A[i][j]}";
                        string rowKey = $"row {i} value {A[i][j]}";
                        string boxKey = $"box {boxNumber} value {A[i][j]}";

                        if (!hs.Add(columnKey) || !hs.Add(rowKey) || !hs.Add(boxKey))
                        {
                            return 0;
                        }
                    }
                }
            }

            return 1;
        }

        public static int Dictionary(List<string> A, string B)
        {
            int n = A.Count;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < B.Length; i++)
            {
                char c = B[i];
                if(!map.ContainsKey(c))
                {
                    map.Add(c, i);
                }            
            }

            //traversing all the string of array and check its sorted or not
            for (int i = 1; i < n; i++)
            {
                string curr = A[i];
                string prev = A[i - 1];
                if (!IsSorted(curr, prev, map))
                {
                    return 0;
                }
            }

            return 1;
        }

        public static bool IsSorted(String curr, String prev, Dictionary<char, int> map)
        {
            int i = 0, j = 0; //currIndex , prevIndex
            while (i < curr.Length && j < prev.Length)
            {
                char currChar = curr[i];
                char prevChar = prev[j];
                if (map[currChar] == map[prevChar])
                { // if both character index are equal need to check next char
                    i++;
                    j++;
                }
                else if (map[currChar] > map[prevChar]) // if curr string char is greater than prev string char
                    return true;
                else return false;
            }

            if (curr.Length < prev.Length) 
                return false;

            return true;
        }
    }
}
