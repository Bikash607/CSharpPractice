using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class SubArray
    {
        public static List<List<int>> getAllSubArray(List<int> A)
        {
            int n = A.Count;
            List<List<int>> allSubArray = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    var rowSubArray = new List<int>();
                    for (int k = i; k <= j; k++)
                    {
                        rowSubArray.Add(A[k]);
                    }
                    allSubArray.Add(rowSubArray);
                }
            }

            return allSubArray;
        }

        public static List<int> SubArrayInRange(List<int> A, int B, int C)
        {
            var result = new List<int>();
            for (int i = B; i <= C; i++)
            {
                result.Add(A[i]);
            }

            return result;
        }

        public static int MaxSumSubArray(int A, int B, List<int> C)
        {
            int maxSum = int.MinValue;
            int sum = 0;
            for (int i = 0; i < A; i++)
            {
                sum = 0;
                for(int j = i; j < A; j++)
                {
                    sum = sum + C[j];
                    if(sum > maxSum && sum<=B)
                    {
                        maxSum = sum;
                    }
                }
            }

            if(maxSum == int.MinValue)
            {
                maxSum = 0;
            }

            return maxSum;
        }

        public static long TotalSumOfSubArray(List<int> A)
        {
            long totalSumOfAllSubArray = 0;
            int n = A.Count;
            for (int i = 0; i < n; i++)
            {
                totalSumOfAllSubArray += A[i] *(i + 1)*(n - i);
            }

            return totalSumOfAllSubArray;
        }

        // Total Subarray of length L can be formed from the array of length N is :-> N-L+1
        // TC :: O(B*(N-L+1) , SC ::(1)
        public static List<int> AlternatingSubarrays(List<int> A, int B)
        {
            List<int> result = new List<int>();
            int n = A.Count;
            int l = 2 * B + 1;
            int prev;
            bool flag;
            if (l <= 1)
            {
                for (int i = 0; i < n; i++)
                {
                    result.Add(i);
                }

                return result;
            }

            for (int i = 0; i< n - l + 1; i++)
            {
                prev = -1;
                flag = true;
                for (int j = i; j < i + l; j++)
                {
                    if (prev == A[j])
                    {
                        flag = false;
                        break;
                    }
                    prev = A[j];
                }

                if (flag)
                {
                    result.Add(i + B);
                }
            }

            return result;
        }

        // ArithMaticSubArray is a array of min size 3 and common difference between the element should be same
        public static int ArithMaticSubArray(List<int> A)
        {
            List<int> result = new List<int>();
            int k = 0, res = 0;
            int n = A.Count;
            for(int i=2; i< n; i++)
            {
                if (A[i] - A[i-1] == A[i-1] - A[i-2])
                {
                    k++;
                }
                else
                {
                    res += (k * (k + 1) / 2);
                    k = 0;
                }
            }

            //once array iteration is completed it will not go to else part and we are adding the
            //subarrays if present
            res += (k * (k + 1) / 2);
            return res;
        }
    }
}
