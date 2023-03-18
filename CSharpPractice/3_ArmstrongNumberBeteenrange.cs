using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class _3_ArmstrongNumberBeteenrange
    {

        // if cube of sum of all digt of number = number then number is called as armstrongnumber
        //  153 = (1*1*1) +(5*5*5)+ (3*3*3) ->so 153 is armstrongnumber 
        public static List<int> ArmstrongNumberBeteenrange(int A)
        {
            var numberList = new List<int>();
            for(int i = 1; i < A; i++)
            {
                int temp = i;
                int sum = 0;
                while(temp > 0)
                {
                    int digit = temp % 10;
                    sum = sum + digit * digit * digit;
                    temp = temp / 10;
                }

                if(sum == i)
                {
                    numberList.Add(i);
                }
            }

            return numberList;
        }
    }
}
