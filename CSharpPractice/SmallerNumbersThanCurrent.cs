using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class SmallerNumbersThanCurrent
    {
        public static int[] Solution(int[] nums)
        {
            int n = nums.Length;
            int[] bucket = new int[101];
            for (int i = 0; i < n; i++)
            {
                bucket[nums[i]] += 1;
            }

            for (int i = 1; i < 101; i++)
            {
                bucket[i] = bucket[i] + bucket[i - 1];
            }

            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 0)
                {
                    nums[i] = 0;
                }

                nums[i] = bucket[nums[i] - 1];
            }

            return nums;
        }
    }
}
