using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class ArrayProblem_2
    {
        public static int MajorityElement(int[] nums)
        {
            int CME = -1;
            int F = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (F == 0)
                {
                    F++;
                    CME = nums[i];
                }
                else if (nums[i] == CME)
                {
                    F++;
                }
                else
                {
                    F--;
                }
            }

            if (F == 0)
                return 0;
            F = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] == CME)
                {
                    F++;
                }

            }

            if (F > nums.Length / 2)
                return CME;
            else
                return 0;
        }

        public static List<int> SumOfEvenIndices(List<int> A, List<List<int>> B)
        {
            int n = A.Count;
            List<int> result = new List<int>();
            for (int i = 3; i < n; i += 2)
            {
                A[i] = A[i - 2] + A[i];
            }

            for (int i = 0; i < B.Count; i++)
            {
                if (B[i][0] <= 1)
                {
                    if (B[i][1] <= 1)
                    {
                        result.Add(0);
                    }
                    else
                    {
                        if (B[i][1] % 2 != 0)
                        {
                            result.Add(A[B[i][1]]);
                        }
                        else
                        {
                            result.Add(A[B[i][1] - 1]);
                        }
                    }
                }
                else
                {
                    int L, R;
                    if (B[i][0] % 2 != 0)
                    {
                        L = B[i][0] - 2;
                    }
                    else
                    {
                        L = B[i][0] - 1;
                    }

                    if (B[i][1] % 2 == 0)
                    {
                        R = B[i][1] - 1;
                    }
                    else
                    {
                        R = B[i][1];
                    }

                    result.Add((A[R] - A[L]));
                }
            }

            return result;
        }

        public static List<int> SumOfOddIndices(List<int> A, List<List<int>> B)
        {
            int n = A.Count;
            List<int> result = new List<int>();
            for (int i = 3; i < n; i += 2)
            {
                A[i] = A[i - 2] + A[i];
            }

            for (int i = 0; i < B.Count; i++)
            {
                if (B[i][0] == 0)
                {
                    if (B[i][1] % 2 == 0)
                    {
                        result.Add(A[B[i][1]]);
                    }
                    else
                    {
                        result.Add(A[B[i][1] - 1]);
                    }
                }
                else
                {
                    int L, R;
                    if (B[i][0] % 2 == 0)
                    {
                        L = B[i][0] - 2;
                    }
                    else
                    {
                        L = B[i][0] - 1;
                    }

                    if (B[i][1] % 2 != 0)
                    {
                        R = B[i][1] - 1;
                    }
                    else
                    {
                        R = B[i][1];
                    }

                    result.Add((A[R] - A[L]));
                }
            }

            return result;
        }

        public static int SpecialIndex(List<int> A)
        {
            int n = A.Count;
            List<int> evenSumPrefix = new List<int>();
            List<int> oddSumPrefix = new List<int>();
            int count = 0;
            evenSumPrefix.Add(A[0]);
            evenSumPrefix.Add(A[0]);
            oddSumPrefix.Add(0);
            oddSumPrefix.Add(A[1]);
            for (int i = 2; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    evenSumPrefix.Add(evenSumPrefix[i - 1] + A[i]);
                    oddSumPrefix.Add(oddSumPrefix[i - 1]);
                }
                else
                {
                    oddSumPrefix.Add(oddSumPrefix[i - 1] + A[i]);
                    evenSumPrefix.Add(evenSumPrefix[i - 1]);
                }

            }

            for (int i = 0; i < n; i++)
            {
                int evenSum = 0;
                int oddSum = 0;

                if (i - 1 < 0)
                {
                    evenSum += 0;
                    oddSum += 0;
                }
                else
                {
                    evenSum += evenSumPrefix[i - 1];
                    oddSum += oddSumPrefix[i - 1];
                }

                evenSum += (oddSumPrefix[n - 1] - oddSumPrefix[i]);
                oddSum += (evenSumPrefix[n - 1] - evenSumPrefix[i]);

                if (evenSum == oddSum)
                {
                    count++;
                }
            }

            return count;
        }

        public static int RepeatedNumberMoreThanN_By_3(List<int> A)
        {
            int ME1 = 0;
            int ME2 = 0;
            int F1 = 0;
            int F2 = 0;

            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] == ME1)
                {
                    F1++;
                }
                else if (A[i] == ME2)
                {
                    F2++;
                }
                else if (F1 == 0)
                {
                    ME1 = A[i];
                    F1++;
                }
                else if (F2 == 0)
                {
                    ME2 = A[i];
                    F2++;
                }
                else
                {
                    F1--;
                    F2--;
                }
            }

            F1 = 0; F2 = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (ME1 != 0 && A[i] == ME1)
                {
                    F1++;
                }
                else if (ME2 != 0 && A[i] == ME2)
                {
                    F2++;
                }

            }

            if (F1 > System.Math.Floor((decimal)(A.Count / 3)))
            {
                return ME1;
            }
            else if (F2 > System.Math.Floor((decimal)(A.Count / 3)))
            {
                return ME2;
            }
            else
            {
                return -1;
            }
        }
    }
}
