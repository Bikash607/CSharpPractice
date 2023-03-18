namespace CSharpPractice.Advanced
{
    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public static class Array_3
    {
        public static int Watertrap(List<int> A)
        {
            int n = A.Count;
            int lMax = A[0];
            int unit = 0;
            int[] rPrefixMax = new int[n];
            rPrefixMax[n - 1] = A[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                var x = A[i];
                var y = rPrefixMax[i + 1];
                rPrefixMax[i] = Math.Max(x,y);
            }

            for (int i = 1; i< n - 2; i++)
            {
                int rMax = rPrefixMax[i + 1];
                if (A[i] < lMax && A[i] < rMax)
                {
                    unit += (Math.Min(lMax, rMax) - A[i]);
                }

                lMax = Math.Max(lMax, A[i]);
            }

            return unit;
        }

        //Merge Overlapping Intervals
        public static List<Interval> MergeIntervals(List<Interval> intervals)
        {
            intervals.Sort((x, y) => { return x.start.CompareTo(y.start); });
            List<Interval> res = new List<Interval>();
            int left = intervals[0].start;
            int right = intervals[0].end;
            res.Add(new Interval() { start = left, end = right });
            for (int i = 1; i < intervals.Count; i++)
            {
                if (intervals[i].start <= right)
                {
                    right = System.Math.Max(intervals[i].end, right);
                    res[res.Count - 1].end = right;
                }
                else
                {
                    left = intervals[i].start;
                    right = intervals[i].end;
                    res.Add(new Interval() { start = left, end = right });
                }
            }

            return res;
        }

        //Merge Non Overlapping Intervals
        public static List<List<int>> MergeNonOverlappingIntervals(List<List<int>> A, int B, int C)
        {
            int left = B, right = C;
            List<List<int>> res = new List<List<int>>();
            for(int i=0; i<A.Count;i++)
            {
                if (A[i][index: 1] < left || right < A[i][0])
                {
                    if (left < A[i][0])
                    {
                        var ans1 = new List<int>();
                        ans1.Add(left);
                        ans1.Add(right);
                        res.Add(ans1);
                        left = res[i][0];
                        right = res[i][1];
                    }
                    else
                    {
                        var ans3 = new List<int>();
                        ans3.Add(left);
                        ans3.Add(right);
                        res.Add(ans3);
                    }
                }
                else
                {
                    left = System.Math.Min(left, A[i][0]);
                    right = System.Math.Max(right, A[i][1]);
                    if (A[i][0] <= right)
                    {
                        right = System.Math.Max(right, A[i][1]);
                    }
                    else
                    {
                        var ans2 = new List<int>();
                        ans2.Add(left);
                        ans2.Add(right);
                        res.Add(ans2);
                        left = System.Math.Min(left, A[i][0]);
                        right = System.Math.Max(right, A[i][1]);
                    }
                }
            }

            var ans = new List<int>();
            ans.Add(left);
            ans.Add(right);
            res.Add(ans);
            return res;
        }

        // Given a row-wise and column-wise sorted matrix A of size N * M.
        // Maximum Submatrix Sum (need to understand the logic)
        public static long MaximumSubmatrixSum(List<List<int>> A)
        {
            long[,] prefSum = new long[A.Count, A[0].Count];
            long MaxSum = int.MinValue;
            for (int i = A.Count - 1; i >= 0; i--)
            {
                for (int j = A[0].Count - 1; j >= 0; j--)
                {
                    if (j != A[0].Count - 1)
                    {
                        prefSum[i,j] = prefSum[i, j + 1] + A[i][j];
                    }
                    else
                    {
                        prefSum[i, j] = A[i][j];
                    }
                    MaxSum = Math.Max(MaxSum, prefSum[i,j]);
                }
            }

            for (int j = A[0].Count - 1; j >= 0; j--)
            {
                for (int i = A.Count - 1; i >= 0; i--)
                {
                    if (i != A.Count - 1)
                    {
                        prefSum[i,j] = prefSum[i + 1,j] + prefSum[i,j];
                    }

                    MaxSum = Math.Max(prefSum[i, j], MaxSum);
                }
            }

            return MaxSum;
        }

        public static int solve(List<int> A, List<int> B, List<int> C, List<int> D)
        {
            int[] sign = { 1, -1 };
            int ans = 0;
            for (int l = 0; l < 2; l++)
                for (int m = 0; m < 2; m++)
                    for (int n = 0; n < 2; n++)
                        for (int o = 0; o < 2; o++)
                        {
                            int max = int.MinValue;
                            int min = int.MaxValue;
                            for (int i = 0; i < A.Count; i++)
                            {
                                int sum = sign[l]*A[i] + sign[m]*B[i] + sign[n]*C[i] + sign[o]*D[i] + i;
                                max = Math.Max(max, sum);
                                min = Math.Min(min, sum);
                                ans = Math.Max((max - min), ans);
                            }

                        }
            return ans;
        }
    }
}
