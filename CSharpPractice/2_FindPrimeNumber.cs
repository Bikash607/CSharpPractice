using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class FindPrimeNumber
    {
        public static int IsPrime(int n)
        {
            int result = 1;
            int count = 0;
            int iterator = (int)Math.Sqrt(n);
            if(n == 1)
                return 0;
            for(int i = 2; i <= iterator; i++)
            {
                if(i != n / i)
                {
                    count += 2;
                }
                else
                {
                    count++;
                }

                if(count >= 2)
                {
                    result = 0;
                    break;
                }
            }

            return result;
        }

        public static int FindPrimeNumberCountBetweenRange(int A)
        {
            int count = 0;
            bool[] primeNumbers = new bool[A+1];
            for (int i = 2; i * i <= A; i++)
            {
                if (primeNumbers[i])
                    continue;
                for (int j = i * i; j <= A; j += i)
                {
                    primeNumbers[j] = true;
                }
            }

            for (int i = 2; i <= A; i++)
            {
                if (!primeNumbers[i])
                    count++;
            }
            return count;
        }
    }
}
