using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class Shorting_2
    {

        public static List<int> CountSort(List<int> A)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int max = int.MinValue;
            for (int i = 0; i <A.Count;i++)
            {
                if (A[i] > max)
                {
                    max = A[i];
                }

                if (dict.ContainsKey(A[i]))
                {
                    dict[A[i]]+=1;
                }
                else
                {
                    dict[A[i]] =1;
                }
            }

            int k = 0;
            for(int i=0; i<max+1;i++)
            {
                if(dict.ContainsKey(i))
                {
                    for(int j = 0; j < dict[i]; j++)
                    {
                        A[k] = i; 
                        k++;
                    }
                }
            }

            return A;
        }
        public static string largestNumber(List<int> A)
        {
            int zeroCount = 0;
            foreach(int i in A)
            {
                if(i==0)
                {
                    zeroCount++;
                }
            }

            if(zeroCount == A.Count)
            {
                return "0";
            }

            A.Sort((x,y) =>
            {
                string m = x + "" + y;
                string n = y + "" + x;
                return string.Compare(m, n);
            });

            System.Text.StringBuilder sb = new StringBuilder();
            foreach(int i in A)
            {
                sb.Append(i);
            }

            return sb.ToString();
        }
    }
}
