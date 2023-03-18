/*
 * Questin: 
 The intuition behind doing the problem in constant space is that we must process the original array:

  1.in-place,
  2.in a way that allows us to move the correct value (nums[nums[i]) to it's correct place (i)
  3.while also keeping the original value, (nums[i]), in-place, in some way so that we can use it when needed later.

-> We must keep nums[i] intact because if, for example, a later position in the array, say j, has a value nums[j] = i, 
   but we've overwrote the value at i (nums[i]) with nums[nums[i]] already, then we're out of luck.

-> To accomplish this task, we're going to use the fact that if we have a number of the form a = qb + r, 
   where b and r are not multiples of q and r < q, then we can extract b and r with the following:

-> b = a // q (where // is integer division) - we know that qb when divided by q will give us b, 
   however we still would need to get rid of the r // q. From our requirements though, r < q, 
   so r // q will always be 0, thus b = (qb//q) + (r//q) = b + 0 = b

-> r = a % q - we know that qb is a multiple of q, thus is divided by it cleanly and we know that r < q,
   so r is not a multiple of q, therefore the remainder when dividing a = qb + r by q is just r
   We need to find a way to transform every element of nums into the form a = qb + r.

-> At every i, nums[nums[i]] is going to be our b and the original value, nums[i] is our r.
   Now we just need a q that satisfies the r < q, for all the possible r values (all nums[i]).
   Luckily, we have such a q already, as our array values are indices into the same array. 
   q = len(nums) is always guaranteed to be greater than all nums[i] because each index is always within 
   the bounds of the array, from 0 to len(nums) - 1.
 */

namespace CSharpPractice
{
    public static class BuildArrayFromPermutation
    {
        public static int[] BuildArray(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i< n; i++)
            {
                nums[i] = nums[i] + (nums[nums[i]] % n) * n;
            }

            return nums;
        }
    }
}
