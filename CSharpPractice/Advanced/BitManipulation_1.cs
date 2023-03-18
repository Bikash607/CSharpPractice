using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class BitManipulation_1
    {
        // Count no of Set bits , multiple aproaches are there but this is most efficient check the class for 
        // other aproach
        public static int numSetBits(int A)
        {
            int ans = 0;
            while (A > 0)
            {
                ans++;
                A &= (A - 1);
            }

            return ans;
        }

        // Working Code
        public static int SingleNumber1(List<int> A)
        {

            int res = 0;
            for (int i = 0; i < 32; i++)
            {
                int setBitCount = 0;
                for (int j = 0; j < A.Count; j++)
                {
                    if ((1 << i & A[j]) > 0)
                    {
                        setBitCount++;
                    }
                }
                if (setBitCount % 3 != 0)
                {
                    res += 1 << i;
                }
            }

            return res;
        }

        // not Working but aproch is correct to reduce time complexity (discussed this aproach in class)
        public static int singleNumber(List<int> A)
        {
            int ans = 0;
            int max = int.MinValue;
            int noOfBits = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (max < A[i])
                {
                    max = A[i];
                }
            }

            noOfBits = (int)Math.Log(max);
            for (int i = 0; i < noOfBits; i++)
            {
                int setBitCount = 0;
                for (int j = 0; j < A.Count; j++)
                {
                    if ((A[j] & 1 >> i) > 0)
                    {
                        setBitCount++;
                    }
                }

                if (setBitCount % 3 != 0)
                {
                    ans += 1 << i;
                }
            }

            return ans;
        }

        //Divide two integers without using multiplication, division and mod operator.
        public static int Divide(int A, int B)
        {
            long quotient = 0;
            bool ngeative = ((A < 0) ^ (B < 0)); // sign
            long divisor = Math.Abs((long)A);
            long divident = Math.Abs((long)B);
            for (int i = 31; i >= 0; i--)
            {
                if ((divident << i) <= divisor)
                {
                    quotient += ((long)1 << i);
                    divisor -= (divident << i);
                    if (quotient >= int.MaxValue) return (ngeative ? int.MinValue : int.MaxValue);
                }
            }
            return (int)(ngeative ? quotient * -1 : quotient);
        }

        // You are given an array of integers A of size N. The value of a subarray is defined as BITWISE OR of all elements in it.
        // Return the sum of value of all subarrays of A % 109 + 7.
        public static int SUBARRAYOR(List<int> A)
        {
            long n = A.Count;
            long tot_subArray = (n * (n + 1)) / 2;
            long ans = 0;
            for (int i = 0; i < 32; i++)
            {
                long subArray = 0;
                long bitzero = 0;
                for (int j = 0; j < n; j++)
                {
                    if ((A[j] & (1 << i)) == 0)
                    {
                        bitzero += 1;
                    }

                    if ((A[j] & (1 << i)) > 0 || j == n - 1)
                    {
                        subArray += (bitzero * (bitzero + 1)) / 2;
                        bitzero = 0;
                    }
                }

                ans += (tot_subArray - subArray) * (long)Math.Pow(2, i);
                ans %= 1000000007;
            }
            return (int)ans;
        }


        // Min XOR value
        public static int minx(List<int> a, int bit)
        {
            int n = a.Count;
            if (bit < 0 || n < 2)
                return int.MaxValue;

            if (n == 2 || a[0] == a[1])
                return a[0] ^ a[1];

            List<int> set = new List<int>();
            List<int> unset = new List<int>();

            foreach (int x in a)
            {
                if (((x >> bit) & 1) == 1) set.Add(x);
                else unset.Add(x);
            }
            int minset = minx(set, bit - 1);
            int minunset = minx(unset, bit - 1);
            return Math.Min(minset, minunset);
        }

        // Min XOR value :: 2nd aproach
        public static int findMinXor(List<int> A)
        {
            // sort the array A in ascending order
            A.Sort();
            // the answer will be the min of XOR of each adjacent elements
            int ans = A[0] ^ A[1];
            for (int i = 1; i < A.Count; i++)
            {
                ans = Math.Min(A[i] ^ A[i - 1], ans);
            }


            return ans;
        }

        public static int solve(int A, int B)
        {
            long fact = 1;
            long mod = (long)(1e9 + 7);
            // calculating factorial of B
            for (long i = 2; i <= B; i += 1)
            {
                fact = (fact * i) % (mod - 1);      // (mod-1) is used accoring to Fermat Little theorem.
            }
            int ans = fast_power(A, fact, mod);     // calculating power by divide and conquer
            return ans;
        }

        private static int fast_power(long A, long B, long mod)
        {
            long ans = 1;
            while (B > 0)
            {
                if ((B & 1) == 1)
                {
                    ans = (ans * A) % mod;
                }
                A = (A % mod * A % mod) % mod;
                B = B >> 1;
            }

            return (int)(ans % mod);
        }

        //the formula which guides this questions is A+B = A^B + 2*(A&B).
        //if A+B = A^B, then 2*(A&B) = 0 or A & B =0
        //for greatest smaller number
        //idea is to find the countOfBits and then make the exact reverse of the number so that
        // the bitwise And gives 0.
        // for example if A=5 (in bits 101), the greatest smaller number to give bitwise and as zero is 010.
        public static int StrangeEqualityScaler(int A)
        {
            int bit = 0, x = 0;
            // x is equal to the summation of unset bits in A
            while (A != 0)
            {
                if (A % 2 == 0)
                {
                    x = x | (1 << bit);
                }
                A /= 2;
                bit++;
            }
            // y equals the power of 2 just greater than A
            int y = (1 << bit);
            return x ^ y;
        }


        public static bool checkBit(int A, int i)
        {
            if ((A & (1 << i)) != 0)
                return true;
            else
                return false;
        }

        public static int StrangeEquality(int A)
        {
            int n1 = 0;
            int n2 = 0;
        
            int lastOneBit = 0;
            for (int i = 0; i < 32; i++)
            {
                if (checkBit(A, i))
                {
                    lastOneBit = i;
                }
            }

            int countOfBits = lastOneBit + 1;

            for (int i = 0; i < countOfBits; i++)
            {
                if (!checkBit(A, i))
                {
                    n1 = n1 + (1 << i);
                }
            }

            //for smallest greater number
            // the smallest number greater than number to give an bitwise and as zero is 2^countOfBits.
            // for example if A=5 (in bits 101), the smallest greater number to give bitwise and as zero is 1000.
            n2 = (1 << countOfBits);

            return n1 ^ n2;
        }
    }
}
