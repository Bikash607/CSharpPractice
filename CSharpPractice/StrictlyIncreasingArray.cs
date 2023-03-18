using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public static class StrictlyIncreasingArray
    {
        public static bool Strictly_Increasing_Array()
        {
            int[] nums = { 1, 6, 4, 3,10 };
            bool strctlyIncreacing = true;
            int count = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if(nums[i] <= nums[i-1])
                {
                    count++;
                    nums[i - 1] = nums[i];
                    if(i > 1)
                        i = i - 1;
                }

                if(count == 2)
                {
                    strctlyIncreacing = false;
                    break;
                }                 
            }

            return strctlyIncreacing;
        }
    }
}
