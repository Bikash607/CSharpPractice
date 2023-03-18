using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class ArrayRotation
    {
        public static List<int> solve(List<int> A, int B)
        {
            int n = A.Count;
            int k = B % n;
            Rotate(A, 0, n - 1);
            Rotate(A, 0, k - 1);
            Rotate(A, k, n - 1);
            return A;
        }

         static void Rotate(List<int> A, int i, int j)
        {
            while (i < j)
            {
                A[i] = A[i] + A[j];
                A[j] = A[i] - A[j];
                A[i] = A[i] -A[j];
                i++;
                j--;
            }
        }

        public static int MaxMinSum(List<int> A)
        {
            int min = (int)Math.Pow(10, 9);
            int max = -min;
        
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] > max)
                {
                    max = A[i];
                }

                if (A[i] < min)
                {
                    min = A[i];
                }
            }

            return max + min;
        }

        public static int TotalCount(List<int> A)
        {
            A.Sort();
            int count = 0;
            int n = A.Count;
            for (int i = 0; i < n; i++)
            {
                count += A[n - 1] - A[i];
            }
            return count;
        }

        public static List<int> RangeSumQuery(List<int> A, List<List<int>> B)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < B.Count; i++)
            {
                int Count = 0;
                for (int j = B[i][0] - 1; j < B[i][1]; j++)
                {
                    Count += A[j];
                }
                result.Add(Count);
            }

            return result;
        }

        public static List<int> RangeSumQuery_Updated(List<int> A, List<List<int>> B)
        {
            List<int> result = new List<int>();
            for (int i = 1; i < A.Count; i++)
            {
                A[i] = A[i] + A[i - 1];
            }

            for (int i = 0; i < B.Count; i++)
            {
                if (B[i][0] <= 1)
                {
                    result.Add(A[B[i][1] - 1]);
                }
                else
                {
                    result.Add(A[B[i][1] - 1] - A[B[i][0] - 2]);
                }
            }

            return result;
        }
    }
}
