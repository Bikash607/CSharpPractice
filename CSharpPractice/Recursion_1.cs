using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class Recursion_1
    {
        public static void solve(int A)
        {
            printNums(A);
            Console.WriteLine("");
        }

        public static void printNums(int A)
        {
            if (A == 1)
            {
                Console.Write(1 + " ");
                return;
            }
            printNums(A - 1);
            Console.Write(A + " ");

        }

        public static int Palindrome(string A, int L, int R)
        {
            if (A[L] != A[R])
            {
                return 0;
            }

            if (L >= R)
            {
                return 1;
            }

            return Palindrome(A, L + 1, R - 1);
        }

        public static void Reverse(string A, int strIndex)
        {   
            if (strIndex < 0)
                return;
            Console.Write(A[strIndex]);
            Reverse(A, strIndex - 1);
        }

        public static int fun(int x, int n)
        {
            if(n==0)
            {
                return 1;
            }
            else if(n%2 ==0)
            {
                return fun(x*x,n/2);
            }
            else
            {
                return x * fun(x * x, (n - 1) / 2);
            }
        }

        public static int bar(int x, int y)
        {
            if (y == 0)
                return 0;
            return (x + bar(x, y-1));
        }

        public static int foo(int x, int y)
        {
            if (y == 0)
                return 1;
            return
                bar(x, foo(x, y - 1));
        }
    }
}