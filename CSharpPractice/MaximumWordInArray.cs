using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class MaximumWordInArray
    {
        public static int Maximum_Number_Of_Word_In_Sentence_Array()
        {
            int n = 0;
            string[] arr = { "please wait", "continue to fight", "continue to win" };
            for (int i = 0; i < arr.Length; i++)
            {
                int wordCount = arr[i].Split().Count();
                if (wordCount > n)
                    n = wordCount;
            }
            return n;
        }
    }
}
