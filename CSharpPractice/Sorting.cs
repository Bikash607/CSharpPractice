using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class Sorting1
    {
        public static int NobleInteger(List<int> A)
        {
            A = A.OrderByDescending(x => x).ToList();
            int count = 0;
            for(int i=0;i<A.Count; i++)
            {
                if (i ==0 || A[i] != A[i-1])
                    count = i;
                if (A[i] == count)
                    return 1;
            }
            return -1;
        }

        public static string MinimumCostElementsRemoval(List<int> A)
        {
            A = A.OrderByDescending(x => x).ToList();
            return String.Join("", A);
        }

        public static List<int> Factorssort(List<int> A)
        {
            A.Sort((x, y) => {
                var a = NoOfFactors(x);
                var b = NoOfFactors(y);

                if (a == b)
                    return x - y;
                else
                    return a - b;
            });

            return A;
        }

        public static string LargestNumber(List<int> A)
        {
            A.Sort((x, y) => {
                var a = string.Concat(x, y);
                var b = string.Concat(y, x);
                return string.Compare(a, b);
            });

            return String.Join("", A);
        }

        public static int ArithmeticProgression(List<int> A)
        {
            A.Sort();
            for(int i =1; i<A.Count-1; i++)
            {
                if (A[i] - A[i-1] != A[i+1] - A[i])
                {
                    return 0;
                }
            }

            return 1;
        }

        public static List<int> TensDigitSorting(List<int> A)
        {
            A.Sort((x, y) => {
                var a = (x/10)%10;

                var b = (y / 10) % 1;
                if(a == b)
                {
                    return y-x;
                }
                else
                {
                    return a-b;
                }
            });

            return A;
        }

        public static List<int> SortbyColor(List<int> A)
        {
            List<int> count = new List<int>();
            count.Add(0);
            count.Add(0);
            count.Add(0);
            for (int i = 0; i < A.Count; i++)
            {
                count[A[i]]++;
            }

            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                while (count[i] > 0)
                {
                    A[k] = i;
                    k++;
                    count[i]--;
                }
            }

            return A;
        }


        private static int NoOfFactors(int A)
        {
            int count = 0;
            int noOfIteration = (int)Math.Floor(Math.Sqrt(A));
            for (int i = 1; i <= noOfIteration; i++)
            {
                if (A % i == 0)
                {
                    if (i != A / i)
                    {
                        count += 2;
                    }
                    else
                    {
                        count += 1;
                    }
                }
            }

            return count;
        }
    }
}
