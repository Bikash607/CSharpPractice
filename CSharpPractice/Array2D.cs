using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class Array2D
    {
        public static int MaxSumRow(int[,] A)
        {
            int maxSum = 0;
            int sum;
            for (int j = 0; j < A.GetLength(1); j++)
            {
                sum = 0;
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    sum += A[i, j];
                }

                if (sum > maxSum)
                    maxSum = sum;
            }

            return maxSum;
        }

        //left top to right bottom diagonal (0,0),(1,1) ---(n-1,n-1) :TC::O(N) :: SC:O(1)
        public static void PrintDiagonal(int[,] A)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                Console.WriteLine(A[i, i]);
            }
        }

        public List<int> solve(List<List<int>> A)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < A.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < A[i].Count; j++)
                {
                    sum += A[i][j];
                }
                result.Add(sum);
            }

            return result;
        }

        public static List<int> SumOfColumns(List<List<int>> A)
        {
            List<int> result = new List<int>();
            for (int j = 0; j < A[0].Count; j++)
            {
                int sum = 0;
                for (int i = 0; i < A.Count; i++)
                {
                    sum += A[i][j];
                }
                result.Add(sum);
            }

            return result;
        }

        public static List<List<int>> AntiDiagonal(List<List<int>> A)
        {
            int M = A[0].Count;
            int N = A.Count;
            int zeroCount;
            int I;
            int J;
            List<List<int>> result = new List<List<int>>();
            for (int j = 0; j < M; j++)
            {
                zeroCount = N;
                I = 0; J = j;
                var innerList = new List<int>();
                while (I < N && J >= 0)
                {
                    innerList.Add(A[I][J]);
                    I++;
                    J--;
                    zeroCount--;
                }

                while (zeroCount > 0)
                {
                    innerList.Add(0);
                    zeroCount--;
                }

                result.Add(innerList);
            }

            for (int i = 1; i < N; i++)
            {
                I = i; J = M - 1;
                zeroCount = i;
                var innerList = new List<int>();
                while (I < N && J >= 0)
                {
                    innerList.Add(A[I][J]);
                    I++; J--;
                }

                while (zeroCount > 0)
                {
                    innerList.Add(0);
                    zeroCount--;
                }

                result.Add(innerList);
            }

            return result;
        }

        public static List<List<int>> AntiDiagonal_Optimized(List<List<int>> A)
        {
            int l = A.Count;
            List<List<int>> res = new List<List<int>>();
            for (int i = 0; i < 2 * l - 1; i++)
            {
                int offset = i < l ? 0 : i - l + 1;
                List<int> row = new List<int>();
                int k = 0;
                for (int j = offset; j <= i - offset; j++)
                {
                    row.Add(A[j][i - j]);
                    k++;
                }
                for (int j = k; j < l; j++)
                {
                    row.Add(0);
                }
                res.Add(row);
            }

            return res;
        }

        public static int[,] TransPoseMatrix(List<List<int>> A)
        {
            int N = A.Count;
            int M = A[0].Count;
            int[,] result = new int[M, N];
            result[0, 0] = 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    result[j, i] = A[i][j];
                }
            }

            return result;
        }

        public static List<List<int>> Rorate90Degree(List<List<int>> A)
        {
            int n = A.Count;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int temp = A[i][j];
                    A[i][j] = A[j][i];
                    A[j][i] = temp;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = A[i][j];
                    A[i][j] = A[i][n - 1 - j];
                    A[i][n - 1 - j] = temp;
                }
            }

            return A;
        }

        public List<List<int>> AddMatrix(List<List<int>> A, List<List<int>> B)
        {
            int AN = A.Count;
            int AM = A[0].Count;

            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i < AN; i++)
            {
                var innerList = new List<int>();
                for (int j = 0; j < AM; j++)
                {
                    innerList.Add(A[i][j] + B[i][j]);
                }

                result.Add(innerList);
            }

            return result;
        }

        public static List<List<int>> RowToColumn(List<List<int>> A)
        {
            bool firstRow = false;
            bool firstCol = false;
            int N = A.Count;
            int M = A[0].Count;

            for (int i = 0; i < N; i++)
            {
                if (A[i][0] == 0)
                {
                    firstCol = true;
                    break;
                }
            }

            for (int j = 0; j < M; j++)
            {
                if (A[0][j] == 0)
                {
                    firstRow = true;
                    break;
                }
            }

            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < M; j++)
                {
                    if (A[i][j] == 0)
                    {
                        A[0][j] = 0;
                        A[i][0] = 0;
                    }
                }
            }

            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < M; j++)
                {
                    if (A[i][0] == 0 || A[0][j] == 0)
                    {
                        A[i][j] = 0;
                    }
                }
            }

            if (firstCol)
            {
                for (int i = 0; i < N; i++)
                {
                    A[i][0] = 0;
                }
            }

            if (firstRow)
            {
                for (int j = 0; j < M; j++)
                {
                    A[0][j] = 0;
                }
            }

            return A;
        }

        public static int SubarraywithgivensumAndLength(List<int> A, int B, int C)
        {
            int n = A.Count;
            int maxSum = 0;
            for (int i = 0; i < B; i++)
            {
                maxSum += A[i];
            }

            if (maxSum == C)
                return 1;
            int sum = maxSum;
            int L = 1; int R = B;
            while (R < n)
            {
                sum = sum - A[L - 1] + A[R];
                L++;
                R++;

                if (sum == C)
                {
                    return 1;
                }
            }

            return 0;
        }

        public static int MinimumSwaps(List<int> A, int B)
        {
            int k = 0;
            int n = A.Count;
            int g = 0;
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                if (A[i] <= B)
                {
                    k++;
                }
            }

            for (int i = 0; i < k; i++)
            {
                if (A[i] <= B)
                {
                    g++;
                }
            }

            res = k - g;
            int L = 1;
            int R = k;
            while (R < n)
            {
                if (A[L - 1] <= B)
                {
                    g--;
                }

                if (A[R] <= B)
                {
                    g++;
                }

                if ((k - g) < res)
                {
                    res = g;
                }

                L++; R++;
            }

            return res;
        }

        public static List<List<int>> SpiralMatrix(int A)
        {
            int[,] result = new int[A, A];
            if(A == 1)
            {
                result[0, 0] = 1;
            }
            else if (A > 1)
            {
                int i = 0, j = 0, ans = 1;
                while(A > 1)
                {
                    for (int x = 1; x <= 4; x++)
                    {
                        for (int k = 1; k <= A - 1; k++)
                        {
                            result[i, j] = ans;
                            ans++;
                            if (x == 1)
                                j++;
                            else if (x == 2)
                                i++;
                            else if (x == 3)
                                j--;
                            else
                                i--;
                        }
                    }

                    i++;
                    j++;
                    A -= 2;
                }

                if(A == 1)
                {
                    result[i, j] = ans;
                }
            }

            return result.Cast<int>()
            .Select((x, i) => new { x, index = i / result.GetLength(1) })  // Use overloaded 'Select' and calculate row index.
            .GroupBy(x => x.index)                                   // Group on Row index
            .Select(x => x.Select(s => s.x).ToList())                  // Create List for each group.  
            .ToList();
        }

        public static double Subarraywithleastaverage(List<int> A, int B)
        {
            int indexofSubArray = 0;
            int minSum = 0;
            int N = A.Count;
            for (int i = 0;i<B;i++)
            {
                minSum += A[i];
            }

            int L = 1, R = B;
            int currentSum = minSum;
            while (R < N)
            {
                currentSum = currentSum - A[L - 1] + A[R];
                if(currentSum < minSum)
                {
                    minSum = currentSum;
                    indexofSubArray = L;
                }

                L++;
                R++;
            }

            return indexofSubArray;
        }

        public static IList<int> SpiralOrder(List<List<int>> matrix)
        {
            var result = new List<int>();
            int m = matrix.Count;
            int n = matrix[0].Count;
            int L = 0, R = 0;
            int k = m;
            while(k >1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    result.Add(matrix[L][R]);
                    R++;
                }

                for (int i = 0; i < m - 1; i++)
                {
                    result.Add(matrix[L][R]);
                    L++;
                }

                for (int i = 0; i < n - 1; i++)
                {
                    result.Add(matrix[L][R]);
                    R--;
                }

                for (int i = 0; i < m - 1; i++)
                {
                    result.Add(matrix[L][R]);
                    L--;
                }

                k-=2;
                L++;
                R++;
                m-=2;
                n-=2;
            }

            if (k == 1)
            {
                result.Add(matrix[L][R]);
            }

            m = matrix.Count;
            n = matrix[0].Count;
            if(m < n && m%2 !=0)
            {
                result.Add(matrix[L][L+1]);
            }

            return result;
        }
    }
}