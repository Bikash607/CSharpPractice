using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class Array_2
    {
        public static List<int> solve(List<List<int>> A, List<int> B, List<int> C, List<int> D, List<int> E)
        {
            int rows = A.Count;
            int col = A[0].Count;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        A[i][j] = A[i][j];
                    }
                    else if ((i == 0) && (j != 0))
                    {
                        A[i][j] = A[i][j] + A[i][j - 1];
                    }
                    else if ((i != 0) && (j == 0))
                    {
                        A[i][j] = A[i][j] + A[i - 1][j];
                    }
                    else
                    {
                        A[i][j] = A[i][j] + A[i - 1][j] + A[i][j - 1] - A[i - 1][j - 1];
                    }

                    A[i][j] = (A[i][j] % 1000000007 + 1000000007) % 1000000007;
                }
            }

            int[] ans = new int[B.Count];
            for (int i = 0; i < B.Count; i++)
            {
                int sx = B[i] - 1;
                int sy = C[i] - 1;
                int ex = D[i] - 1;
                int ey = E[i] - 1;

                if ((sx == 0) && (sy == 0))
                {
                    ans[i] = A[ex][ey];
                }
                else if ((sx == 0) && (sy != 0))
                {
                    ans[i] = A[ex][ey] - A[ex][sy - 1];
                }
                else if ((sx != 0) && (sy == 0))
                {
                    ans[i] = A[ex][ey] - A[sx - 1][ey];
                }
                else
                {
                    ans[i] = A[ex][ey] - A[sx - 1][ey] - A[ex][sy - 1] + A[sx - 1][sy - 1];
                }

                ans[i] = (ans[i] % 1000000007 + 1000000007) % 1000000007;
            }
            return ans.ToList();
        }

        public static int MaxArea(int[] height)
        {
            int l = 0;
            int r = height.Length - 1;
            int maxArea = 0;
            while (l < r)
            {
                int area = Math.Min(height[l], height[r]) * (r - l + 1);
                maxArea = Math.Max(maxArea, area);
                if (height[l] < height[r])
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }

            return maxArea;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            int tgt = 0;
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int v1 = nums[i];
                    tgt = -nums[i];
                    int s = i + 1;
                    int e = nums.Length - 1;
                    while (s < e)
                    {
                        if (tgt == (nums[s] + nums[e]))
                        {
                            var ans = new List<int>() { v1, nums[s], nums[e] };
                            res.Add(ans);
                            while (s < e && nums[s] == nums[s + 1]) s++;
                            while (s < e && nums[e] == nums[e - 1]) e--;
                            s++;
                            e--;
                        }
                        else if (tgt > (nums[s] + nums[e]))
                        {
                            s++;
                        }
                        else
                        {
                            e--;
                        }
                    }
                }
            }

            return res;
        }
    }
}
