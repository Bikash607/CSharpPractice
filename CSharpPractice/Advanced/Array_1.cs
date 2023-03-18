using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class Array_1
    {

        /*
         Formula f(i, j) = |A[i] - A[j]| + |i - j|  IMP: if any equation Absolute operator 
                                                         is there alwasys try to simplify it and remove the Abs
        Take example and find observartion : i.e: f(i,i) =0; always, f(i,j) = f(j,i) so instead of checking 
        every condition if we will check till i<j we can cover all
        case 1: if A[i] >= A[j] then equation can be
                f(i,j) = (A[i] - A[j]) + (j-1)
                       = (A[i] - i) - (A[j]-j)
                      Xmax = x[i] - x[j]   :: if we take another array and store x[i] = A[i] -i;
        -> here we have to find max  of x[i] - x[j]
        case 2: if A[i] < A[j] then the equation can be
                f(i,j) = (A[j] - A[i]) + (j-i)
                       =  (A[j] + j) - (A[i] + i);
                       Ymax= y[j] - y[i] :: if we take another array and store x[i] = A[i] -i;
         -> here we have to find max  of y[j] - y[i]

        Ans : Max of (Xmax,Ymax);
         */
        public static int MaxArr(List<int> A)
        {
            int xMax = int.MinValue;
            int yMax = int.MinValue;
            int xMin = int.MaxValue;
            int yMin = int.MaxValue;
            for (int i = 0; i < A.Count; i++)
            {
                int x = A[i] - i;
                int y = A[i] + i;
                xMax = Math.Max(xMax, x);
                xMin = Math.Min(xMin, x);
                yMax = Math.Max(yMax, y);
                yMin = Math.Min(yMin, y);
            }

            return Math.Max(xMax - xMin, yMax - yMin);
        }

        // Kadane's Algorithm
        public static int maxSubArray(List<int> A)
        {
            int currentSum = 0;
            int maxSum = -10001;
            for (int i = 0; i < A.Count; i++)
            {
                currentSum += A[i];
                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                }

                if (currentSum < 0)
                {
                    currentSum = 0;
                }
            }

            return maxSum;
        }

        public static List<int> solve(int A, List<List<int>> B)
        {
            int[] ans = new int[A];
            for (int i = 0; i < B.Count; i++)
            {
                ans[B[i][0] - 1] += B[i][2];
                if (B[i][1] < A)
                {
                    ans[B[i][1]] -= B[i][2];
                }
            }

            for (int i = 1; i < A; i++)
            {
                ans[i] += ans[i - 1];
            }

            return ans.ToList();
        }

        // Add one to a digit present in the arrary ex: [9,9,9] add 1 to this and return [1,0,0,0]
        public static List<int> plusOne(List<int> A)
        {


            for (int i = A.Count - 1; i >= 0; i--)
            {
                if (A[i] == 9)
                {
                    A[i] = 0;
                }
                else
                {
                    A[i] += 1;
                    return A;
                }
            }

            A.Insert(0, 1);
            return A;
        }

        // flip any one sub array in the binary array such that number of 1's are maximum 
        public static List<int> Flip(string A)
        {
            int arraySize = A.Length;
            int curSum = 0;
            int maxSum = 0;
            int leftIndex = 0;
            int rightIndex = -1;
            int index = 0;
            for (int i = 0; i < arraySize; i++)
            {
                if (A[i] == '0')
                {
                    curSum++;
                }
                else
                {
                    curSum--;
                }
                if (curSum < 0)
                {
                    index = i + 1;
                    curSum = 0;
                }
                if (curSum > maxSum)
                {
                    maxSum = curSum;
                    rightIndex = i;
                    leftIndex = index;
                }
            }

            if (rightIndex == -1)
                return new List<int>();
            else
            {
                List<int> ans = new List<int>();
                ans.Add(leftIndex + 1);
                ans.Add(rightIndex + 1);
                return ans;
            }
        }

        // Search in a row wise and column wise sorted matrix
        public static int SearchInSortedMatrix(List<List<int>> A, int B)
        {
            int N = A.Count;
            int M = A[0].Count;
            int i = 0;
            int j = M - 1;
            int minimumValue = int.MaxValue;
            while (i < N && j >= 0)
            {
                if (A[i][j] < B)
                {
                    i++;
                }
                else if (A[i][j] > B)
                {
                    j--;
                }
                else
                {
                    minimumValue = Math.Min(minimumValue, (i + 1) * 1009 + (j + 1));
                    if (j > 0 && A[i][j - 1] == B)
                    {
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (minimumValue == int.MaxValue)
            {
                return -1;
            }

            return minimumValue;
        }
    }
}
