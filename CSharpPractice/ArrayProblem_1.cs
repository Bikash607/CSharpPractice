using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class ArrayProblem_1
    {
        public static int CountIncreasingTriplets(List<int> A)
        {
            int n = A.Count;
            int count = 0;
            for (int i = 1; i < n - 1; i++)
            {
                int L = 0, R = 0;
                int I = i - 1;
                while (I >= 0)
                {
                    if (A[I] < A[i])
                    {
                        L++;
                    }

                    I--;
                }

                if (L == 0)
                {
                    continue;
                }

                int J = i + 1;
                while (J < n)
                {
                    if (A[J] > A[i])
                    {
                        R++;
                    }

                    J++;
                }

                count = count + (L * R);
            }

            return count;
        }

        public static int Lengthoflongestconsecutiveones(string A)
        {
            int n = A.Length;
            int oneCount = 0;
            int maxAns = 0;
            int ans;
            for (int i = 0; i < n; i++)
            {
                if (A[i] == '1')
                {
                    oneCount++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (A[i] == '0')
                {
                    int L = 0;
                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (A[k] == '1')
                        {
                            L++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    int R = 0;
                    for (int k = i + 1; k < n; k++)
                    {
                        if (A[k] == '1')
                        {
                            R++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    ans = L + R;
                    if (oneCount != ans)
                    {
                        ans += 1;
                    }

                    if (maxAns < ans)
                    {
                        maxAns = ans;
                    }
                }
            }

            return maxAns;
        }

        public static int JosephusProblem(int A)
        {
            //find closest power of 2 < A
            int i = 1;
            while (i <= A)
            {
                i = i * 2;
            }
            // changed i to i/2 becase in last iteration it is already increased from A befroe checking the while condition so to making it correct
            //by reducing it value.
            i = i / 2;
            //calculate number of kills we need to make in order to achieve i
            int kills = A - i;   
            //last man standing (based on 2t+1 as discussed in the video)
            int ans = 1 + (2 * kills);
            return ans;
        }

        public static List<int> Maximumpositivity(List<int> A)
        {
            List<int> res = new List<int>();
            int maxArrayCount = int.MinValue;
            int startIndex = -1;
            for(int i = 0; i<A.Count; i++)
            {
                int tempStartingIndex = -1;
                int current_Max = 0;
                while (i < A.Count && A[i] >=0) 
                {
                    if (tempStartingIndex == -1)
                        tempStartingIndex = i;
                    current_Max++;
                    i++;
                }

                if (maxArrayCount <= current_Max)
                {
                    maxArrayCount = current_Max;
                    startIndex = tempStartingIndex;
                }

            }

            for(int i = startIndex; i< startIndex + maxArrayCount; i++)
            {
                res.Add(A[i]);
            }

            return res;
        }

        public static int ChristmasTrees(List<int> A, List<int> B)
        {
            int n1 = A.Count;
            int minSum = int.MaxValue;
            for (int i = 1; i < n1 - 1; i++)
            {
                int L = i-1;
                int R = i+1;
                int LMin = int.MaxValue;
                int RMin = int.MaxValue;
                bool LMinFound = false;
                bool RMinFound = false;
                while (L>=0)
                {
                    if (A[L] < A[i])
                    {
                        LMinFound = true;
                        if (B[L] < LMin)
                        {
                            LMin = B[L];
                        }
                    }

                    L--;
                }

                if(LMinFound)
                {
                    while(R<n1)
                    {
                        if (A[R] > A[i])
                        {
                            RMinFound = true;
                            if (B[R] < RMin)
                            {
                                RMin = B[R];
                            }
                        }

                        R++;
                    }
                }

                if(LMinFound && RMinFound)
                {
                    if(minSum > (LMin + RMin + B[i]))
                    {
                        minSum = LMin + RMin + B[i];
                    }
                }
            }

            if (minSum == int.MaxValue)
                return -1;
            else
                return minSum;
        }

        public static List<List<int>> MultipleLeftRotations(List<int> A, List<int> B)
        {
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < B.Count; i++)
            {
                int r = B[i]%A.Count;
                List<int> row = new List<int>();
                for (int j = r; j < A.Count; j++)
                {
                    row.Add(A[j]);
                }

                for (int k = 0; k < r; k++)
                {
                    row.Add(A[k]);
                }

                result.Add(row);
            }

            return result;
        }

    }
}
