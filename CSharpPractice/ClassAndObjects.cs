using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class Fraction
    {
        int numerator, denominator;

        // Define constructor here
        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        Fraction add(Fraction a)
        {
            // Complete the function
            int dnom = denominator * a.denominator;
            int num = numerator * a.denominator + denominator * a.numerator;
            int temp = gcd(Math.Abs(num), Math.Abs(dnom));
            num /= temp;
            dnom /= temp;
            return new Fraction(num, dnom);
        }

        Fraction subtract(Fraction a)
        {
            // Complete the function
            int dnom = denominator * a.denominator;
            int num = numerator * a.denominator - denominator * a.numerator;
            int temp = gcd(Math.Abs(num), Math.Abs(dnom));
            num /= temp;
            dnom /= temp;
            return new Fraction(num, dnom);
        }

        Fraction multiply(Fraction a)
        {
            // Complete the function
            int num = numerator * a.numerator;
            int dnom = denominator * a.denominator;
            int temp = gcd(Math.Abs(num), Math.Abs(dnom));
            num /= temp;
            dnom /= temp;
            return new Fraction(num, dnom);
        }

        public int gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return gcd(b, a % b);
        }
    }
}
