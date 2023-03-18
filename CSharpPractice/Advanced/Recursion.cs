using System.Text;

namespace CSharpPractice.Advanced
{
    public static class Recursion
    {
        public static List<string> GenerateParenthesis(int A)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            List<string> res = new List<string>();
            Generate(sb, 0, 0, res, A);
            return res;
        }

        private static void Generate(StringBuilder sb, int open, int close, List<string> res, int A)
        {
            if (open == A && close == A)
            {
                res.Add(sb.ToString());
            }

            if (open < A)
            {
                sb.Append('(');
                Generate(sb, open + 1, close, res, A);
                sb.Remove(sb.Length - 1, 1);
            }

            if (close < A && close < open)
            {
                sb.Append(')');
                Generate(sb, open, close + 1, res, A);
                sb.Remove(sb.Length - 1, 1);
            }
        }

        //Tower of Hanoi
        public static List<List<int>> towerOfHanoi(int A)
        {
            List<List<int>> ans = new List<List<int>>();
            TOH(A, 1, 2, 3, ref ans);
            return ans;
        }

        private static void TOH(int n, int src, int t, int dest, ref List<List<int>> lst)
        {
            if (n == 0) 
                return;
            TOH(n - 1, src, dest, t, ref lst);
            List<int> tmp = new List<int>();
            tmp.Add(n);
            tmp.Add(src);
            tmp.Add(dest);
            lst.Add(tmp);
            TOH(n - 1, t, src, dest, ref lst);
        }
    }
}
