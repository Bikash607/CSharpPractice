using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class Hashing_1
    {
        public static List<int> FrequencyOfElementQuery(List<int> A, List<int> B)
        {
            Dictionary<int, int> result = new();
            for (int i = 0; i < A.Count; i++)
            {
                if (result.ContainsKey(A[i]))
                    result[A[i]]++;
                else
                    result.Add(A[i], 1);
            }

            List<int> ans = new List<int>();
            for (int i = 0; i < B.Count; i++)
            {
                if (result.ContainsKey(B[i]))
                {
                    ans.Add(result[B[i]]);
                }
                else
                {
                    ans.Add(0);
                }

            }
            return ans;
        }

        public static int FirstRepeatingElement(List<int> A)
        {
            Dictionary<int, int> ans = new Dictionary<int, int>();
            int minIndex = -1;
            for (int i = A.Count - 1; i >= 0; i--)
            {
                if (ans.ContainsKey(A[i]))
                {
                    minIndex = i;
                }
                else
                {
                    ans.Add(A[i], 1);
                }
            }

            if (minIndex == -1)
            {
                return minIndex;
            }
            else
            {
                return A[minIndex];
            }
        }

        // Sum(L,R) = PS(R) - PS(L-1); => 0 = PS(R) - PS(L-1) =>  PS(R) = PS(L-1);
        // so from the above equation  if there is a subarray exists whose sum will be zero in that case there
        // should be 2 element in the prpefix sum array whose values will be equal. 
        // 2nd case -> If there is a 0 in the prefix sum then there is also a sub array whose sum is zero
        // ex: a ={2, 3, -5, 10}  PS is {2, 5, 0, 10 } -> here there is no same element in PS arrary but there
        //  exist a sub array whose sum is zero . So for this case check if there is a element in PS array whose
        // value is Zero.
        public static int Sub_arraywith_0_sum(List<int> A)
        {
            HashSet<int> prefixSum = new HashSet<int>();
            prefixSum.Add(0);
            int sum = 0;
            for (int i = 0; i < A.Count; i++)
            {
                sum = sum + A[i];
                if (prefixSum.Contains(sum))
                {
                    return 1;
                }
                else
                {
                    prefixSum.Add(sum);
                }
            }

            return 0;
        }

        public static int UniqueElements(List<int> A)
        {
            Dictionary<int, int> ans = new Dictionary<int, int>();
            int unique = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (ans.ContainsKey(A[i]))
                {
                    ans[A[i]]++;
                }
                else
                {
                    ans.Add(A[i], 1);
                }
            }

            foreach (var i in ans.Keys)
            {
                if (ans[i] == 1)
                {
                    unique++;
                }
            }

            return unique;
        }

        public static List<int> CommonElement(List<int> A, List<int> B)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            List<int> result = new List<int>();
            for (int i = 0; i < A.Count; i++)
            {
                if (map.ContainsKey(A[i]))
                {
                    map[A[i]]++;
                }
                else
                {
                    map.Add(A[i], 1);
                }
            }

            for (int i = 0; i < B.Count; i++)
            {
                if (map.ContainsKey(B[i]) && map[B[i]] > 0)
                {
                    result.Add(B[i]);
                    map[B[i]]--;
                }
            }

            return result;
        }


        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> ASet = new HashSet<int>(nums1);
            HashSet<int> BSet = new HashSet<int>(nums2);
            if (nums1.Length < nums2.Length)
            {
                return GetResult(ASet, BSet);
            }
            else
            {
                return GetResult(BSet, ASet);
            }
        }
        private static int[] GetResult(HashSet<int> x, HashSet<int> y)
        {
            List<int> res = new List<int>();
            foreach (int i in x)
            {
                if (y.Contains(i))
                {
                    res.Add(i);
                }
            }

            return res.ToArray();
        }

        public static int CountSubarrayZeroSum(List<int> A)
        {
            int prefsum = 0;
            int count = 0;
            Dictionary<int, int> map = new()
            {
                { 0, 1 }  //cases when the prefix sum itself becomes zero
            };
            for (int i = 0; i < A.Count; i++)
            {
                prefsum += A[i];
                if (map.ContainsKey(prefsum))
                {
                    count += map[prefsum];
                    map[prefsum]++;
                }
                else
                    map.Add(prefsum, 1);
            }

            return count % 1000000007;
        }

        public static int SubarraysWithKDistinct(int[] nums, int k)
        {
            int count = 0;
            Dictionary<int, int> subArray = new Dictionary<int, int>();
            for(int i=0; i<k-1;i++)
            {
                if (subArray.ContainsKey(nums[i]))
                {
                    subArray[nums[i]]++;
                }
                else
                {
                    subArray.Add(nums[i], 1);
                }
            }

            for(int j=0, i = k-1;i<nums.Length;)
            {
                if (subArray.ContainsKey(nums[i]))
                {
                    subArray[nums[i]]++;
                }
                else
                {
                    subArray.Add(nums[i], 1);
                }

                int freq = subArray[nums[j]];
                if(freq == 1)
                {
                    subArray.Remove(nums[j]);
                }
                else
                {
                    subArray[nums[j]]--;
                }

                j++;
                i++;

                count += (i - j + 1);
            }
            return count;
        }
    }
}
