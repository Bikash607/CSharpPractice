using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class CarryForwardArray
    {
        public static int Pair_A_AND_G_COUNT(string A)
        {
            int A_Count = 0;
            int PainCount=0;
            for(int i =0; i<A.Length; i++)
            {
                if (A[i] == 'a' || A[i] == 'A')
                {
                    A_Count++;
                }

                if(A[i] == 'g' || A[i] == 'G')
                {
                    PainCount += A_Count;
                }
            }

            return PainCount;
        }

        public static int LeaderCountInArray(int[] A)
        {
            int max = int.MinValue;
            int leaderCount = 1;
            for(int i = A.Length -2; i >= 0; i--)
            {
                max = max > A[i +1] ? max : A[i + 1];
                if (A[i] > max)
                {
                    leaderCount++;
                }
                else
                {
                    max = A[i];
                }
            }

            return leaderCount;
        }

        public static int MinMaxSubArray(int[] A)
        {
            int min = A[0];
            int minindex = 0;
            int max = A[0];
            int maxindex = 0;
            int length = A.Length;
            for(int i =1; i < A.Length; i++)
            {
                if (A[i] <= min)
                {
                    min = A[i];
                    minindex = i;
                }

                if(A[i] >= max)
                {
                    max = A[i];
                    maxindex = i;
                }
                
                int l = minindex > maxindex ? (minindex - maxindex) + 1 : (maxindex - minindex) + 1;
                length = length < l ? length : l;
            }

            return length;
        }

        public static List<int> LeaderCount(int[] A)
        {
            int MaxCount = int.MinValue;
            List<int> leaderCount = new List<int>();
            for (int i= A.Length - 1; i >= 0; i--)
            {
                if (A[i] > MaxCount)
                {
                    leaderCount.Add(A[i]);
                    MaxCount = A[i];
                }
            }

          
            return leaderCount;
        }

        public static string EvenSubarrays(List<int> A)
        {
            int n = A.Count;
            if (n % 2 == 0 && A[0] % 2 == 0 && A[n - 1] % 2 == 0)
            {
                return "YES";
            }
            else
            {
                return "NO";
            }
        }

        public static int AmazingSubarrays(string s)
        {
            int n= s.Length;
            int count = 0;
            string vowel = "aeiouAEIOU";
            for(int i = n-1; i >=0; i--)
            {
                if (vowel.Contains(s[i]))
                {
                    count = count+ n - i;
                }
            }

            return count% 10003;
        }


        // code is not correct need to be changed
        public static int MaxSum(List<int> A, int B)
        {
            int n = A.Count;
            int totalSum = 0;
            for (int i = 0; i <n; i++)
            {
                totalSum += A[i];
            }

            for (int i = 1; i < n; i++)
            {
                A[i] = A[i - 1] + A[i];
            }

            int LNonPickedElemet = 0;
            int RNonPickedElemet = n - B - 1;
            int max_Sum = totalSum = A[n - B - 1];
            while (RNonPickedElemet < n)
            {
                int tempSum = 0;
                if (LNonPickedElemet == 0)
                {
                    tempSum = totalSum - A[n - RNonPickedElemet];
                }
                else
                {
                    tempSum = totalSum - (A[n - RNonPickedElemet] - A[n - LNonPickedElemet]);
                }

                if (max_Sum < tempSum)
                {
                    max_Sum = tempSum;
                }

                RNonPickedElemet++;
                LNonPickedElemet++;
            }

            return max_Sum;
        }

        public static int MaxProfit(List<int> A)
        {
            int n = A.Count;
            if (n <=0)
            {
                return 0;
            }
            int minProfit = A[0];
            int maxProfit = 0;

            for (int i = 0; i < n; i++)
            {
                if (minProfit > A[i])
                {
                    minProfit = A[i];
                }

                if (maxProfit < A[i] - minProfit)
                {
                    maxProfit = A[i] - minProfit;
                }
            }

            return maxProfit;
        }

        public static int bulbs(List<int> A)
        {
            int n = A.Count;
            int switchCount = 0;
            for (int i = 0; i < n; i++)
            {
                if (switchCount % 2 != 0)
                {
                    A[i] = A[i] == 0 ? 1 : 0;
                }

                if (A[i] == 0)
                {
                    switchCount++;
                }
            }

            return switchCount;
        }
    }
}
