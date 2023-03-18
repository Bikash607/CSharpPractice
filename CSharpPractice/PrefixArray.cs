using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class PrefixArray
    {
        public static List<long> PrefixSumArray(List<int> A, List<List<int>> B)
        {
            List<long> result = new List<long>();
            List<long> prefixArray = new List<long>();
            prefixArray.AddRange(A.Select(i => (long)i));

            for (int i = 1; i < A.Count; i++)
            {
                prefixArray[i] = prefixArray[i - 1] + prefixArray[i];
            }

            for (int j = 0; j < B.Count; j++)
            {
                if (B[j][0] == 1)
                {
                    result.Add(prefixArray[B[j][1] - 1]);
                }
                else
                {
                    result.Add(prefixArray[B[j][1] - 1] - prefixArray[B[j][0] - 2]);
                }
            }

            return result;
        }

        public static int EquilibriumIndex(List<int> A)
        {
            int SL;
            int SR;
            int N = A.Count;
            int result = -1;
            for (int i = 1; i < N; i++)
            {
                A[i] = A[i - 1] + A[i];
            }

            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    SL = 0;
                }
                else
                {
                    SL = A[i - 1];
                }

                SR = A[N - 1] - A[i];

                if (SL == SR)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
        public static List<int> EnvenNumberRange(List<int> A, List<List<int>> B)
        {
            List<int> result = new List<int>();

            for(int i = 0; i<A.Count; i++)
            {
                if (A[i] % 2 == 0)
                {
                    if (i == 0)
                    {
                        A[i] = 1;
                    }
                    else
                    {
                        A[i] = A[i - 1] + 1;
                    }

                }
                else
                {
                    if (i == 0)
                    {
                        A[i] = 0;
                    }
                    else
                    {
                        A[i] = A[i - 1];
                    }
                }
            }

            for(int i=0; i < B.Count; i++)
            {
                if (B[i][0] == 0)
                {
                    result.Add(A[B[i][1]]);
                }
                else
                {
                    result.Add(A[B[i][1]] - A[B[i][0] - 1]);
                }
            }

            return result;
        }

        public static List<int> ProductArray(List<int> A)
        {
            int n = A.Count;
            List<int> result = new List<int>();
            List<int> RP = new List<int>(A);
            for(int i =1; i< n; i++)
            {
                A[i] = A[i - 1] * A[i];
                RP[n-i-1] = RP[n-i-1] * RP[n-i];
            }

            for(int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    result.Add(RP[i + 1]);
                }
                else if (i == n - 1)
                {
                    result.Add(A[n - 2]);
                }
                else
                {
                    result.Add(A[i - 1] * RP[i + 1]);
                }
            }

            return result;
        }

        public static List<int> ProductArray_Sol_2(List<int> A)
        {
            int n = A.Count;
            int i, temp = 1;

            List<int> prod = new int[n].ToList();

            for (i = 0; i < n; i++)
            {
                prod[i] = temp;
                temp *= A[i];
            }

            temp = 1;
            for (i = n - 1; i >= 0; i--)
            {
                prod[i] *= temp;
                temp *= A[i];
            }

            return prod;
        }

        public static int MinimumPositive(int[] nums)
        {
            int startValue = 1;
            int sum = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                sum = sum + nums[i];
                if (sum < 1)
                {
                    startValue = startValue < (1 - sum) ? 1 - sum : startValue;
                }
            }

            return startValue;
        }

        public static int[] LongestSubsequenceWithLimitedSum(int[] nums, int[] queries)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int qn = queries.Length;
            int[] prefixSum = nums.ToArray();
            int[] ans = new int[qn];
            for (int i = 1; i < n; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + prefixSum[i];
            }

            for(int i = 0; i< qn; i++)
            {
                int index = Array.BinarySearch(prefixSum, queries[i], StringComparer.CurrentCulture);

                if(index >=0)
                {
                    ans[i] = nums[index];
                }
                else
                {
                    index = ~index;
                    ans[i] = index;
                }
            }

            return ans;
        }
    }
}
