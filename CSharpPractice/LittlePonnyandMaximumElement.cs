using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Little Ponny is given an array, A, of N integers. In a particular operation,
he can set any element of the array equal to -1.
He wants your help in finding out the minimum number of operations required
such that the maximum element of the resulting array is B. If it is not possible, then return -1.

Problem Constraints
1 <= |A| <= 105

1 <= A[i] <= 109

Input Format
The first argument of input contains an integer array, A.
The second argument of input contains an integer, B.

Output Format
Return an integer representing the answer.

Example Input
Input 1:
 A = [2, 4, 3, 1, 5]
 B = 3 

Input 2:
 A = [1, 4, 2]
 B = 3 

Example Output
Output 1:
 2 
Output 2:
 -1 

Example Explanation
Explanation 1:
 We need to remove 4 and 5 to make 3 the biggest element. 
Explanation 2:
 As 3 doesn't exist in the array, the answer is -1.

 */
namespace CSharpPractice
{
    public static class LittlePonnyandMaximumElement
    {
        public static int solve(List<int> A, int B)
        {
            int result = A.IndexOf(B);
            if (result == -1)
                return -1;
            else
            {
                result = 0;
                for(int i = 0; i < A.Count; i++)
                {
                    if(A[i] > B)
                        result++;
                }
            }
            return result;
        }

        public static int MaxEvnMinOddDiff(List<int> A)
        {
            return A.Where(x => x % 2 == 0).Max() - A.Where(x => x % 2 != 0).Min(); 
        }

        public static int PairCountInArray(List<int> A, int B)
        {
            int pairCount = 0;
            if(A.Count >= 2)
            {
                for (int i = 0; i < A.Count - 1; i++)
                {
                    for (int j = i+1; j < A.Count; j++)
                    {
                        if (A[i] + A[j] == B)
                            pairCount++;
                }
                }
            }
        
            return pairCount;
        }

        public static int ArrauSum(List<int> A)
        {
            if (A.Count >= 2)
            {
                int result = 0;
                for (int i = 0; i < A.Count - 1; i++)
                {
                    int arraySum = A[i];
                    for (int j = i + 1; j < A.Count; j++)
                    {
                        arraySum += A[j];
                        if (arraySum == 0)
                        {
                            return 1;
                        }
                    }
                }

                return result;
            }
            else
            {
                return 0;
            }
        }

        public static List<int> ElementInBothArray(List<int> A, List<int> B)
        {
            Dictionary<int, int> Bresult = new Dictionary<int, int>();
            List<int> result = new();
            for(int i = 0; i < B.Count; i++)
            {
                if (Bresult.ContainsKey(B[i]))
                {
                    Bresult[B[i]]++;
                }
                else
                {
                    Bresult.Add(B[i], 1);
                }           
            }

            for (int j = 0; j < A.Count; j++)
            {
                if (Bresult.ContainsKey(A[j]) && Bresult[A[j]] > 0)
                {
                    result.Add(A[j]);
                    Bresult[A[j]]--;
                }
            }

            return result;
        }


        public static List<int> solve(List<int> A, List<int> B)
        {
            Dictionary<int, int> Bresult = new Dictionary<int, int>();
            List<int> result = new List<int>();
            for (int i = 0; i < B.Count; i++)
            {
                if (Bresult.ContainsKey(B[i]))
                {
                    Bresult[B[i]]++;
                }
                else
                {
                    Bresult.Add(B[i], 1);
                }
            }

            for (int j = 0; j < A.Count; j++)
            {
                if (Bresult.ContainsKey(A[j]) && Bresult[A[j]] > 0){
                    result.Add(A[j]);
                    Bresult[A[j]]--;
                }
            }
            return result;
        }

        public static int PoWMod(int A, int B, int C)
        {
            int result = 0;
            return result;
        }
    }
}
