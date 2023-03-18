using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class NumberofGoodPairs
    {
        public static int Number_of_Good_Pairs()
        {
            int[] nums = { 1, 1, 1, 1, 1, 1 };
            int pairCount = 0;
            int[] count = new int[101];
            foreach(int i in nums)
            {
                pairCount = pairCount + count[i]++;
            }
            return pairCount;
        }
    }
}
