using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class _1_Sqrt_of_Number
    {
        public static int SquareRootOfPerfectSquareNumber(int N)
        {
            int result = -1;
            for(int i = 1; i <= N; i++)
            {
                if(N%i == 0 && i == N/i)
                {
                    result = i;
                    break;
                }

                if (i * i > N)
                    break;
            }

            return result;
        }

        public static long SQRTOfPerfectSquareNumber_Optimized(int X)
        {
            long low = 1;
            long high = X;
            long ans = -1;
            while (low <= high)
            {
                long mid = (low + high) / 2;
                long sqrt = mid * mid;
                if (sqrt == X)
                {
                    return mid;
                }
                else if (sqrt < X)
                {
                    ans = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }

        // A is a perfect number if sum of all factors is equal to A
        // 6 factors are 1,2,3 :: 6 == 1 + 2 + 3 (6 is a perfect number)
        public static int  PerfectNumber(int A)
        {
            int noOfItoration = (int)Math.Sqrt(A);
            int sum = 0;
            for (int i = 1; i <= noOfItoration; i++)
            {
                if (A % i == 0)
                {
                    if (i != A / i)
                    {
                        sum = sum + i + (A / i);
                    }
                    else
                    {
                        sum = sum + i;
                    }
                }
            }

            if ((sum-A) == A)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
