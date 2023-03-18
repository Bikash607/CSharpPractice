using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class Stack1
    {
        public static int BalancedParanthesis(string A)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> s = new Dictionary<char, char>();
            s.Add('}', '{');
            s.Add(')', '(');
            s.Add(']', '[');
            foreach (char c in A)
            {
                if (s.ContainsKey(c))
                {
                    if (stack.Count == 0 || stack.Peek() != s[c])
                    {
                        return 0;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            if (stack.Count > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static int evalRPN(List<string> A)
        {
            Stack<string> stack = new Stack<string>();
            if (A.Count == 1)
            {
                return int.Parse(A[0]);
            }
            else if (A.Count < 3)
            {
                return 0;
            }

            foreach (string c in A)
            {
                int s1 = 0;
                int s2 = 0;
                int res = 0;
                if (c == "+" || c == "-" || c == "*" || c == "/")
                {
                    s1 = int.Parse(stack.Pop());
                    s2 = int.Parse(stack.Pop());
                    if (c == "+")
                    {
                        res = s2 + s1;
                        stack.Push(res.ToString());
                    }
                    else if (c == "-")
                    {
                        res = s2 - s1;
                        stack.Push(res.ToString());
                    }
                    else if (c == "*")
                    {
                        res = s2 * s1;
                        stack.Push(res.ToString());
                    }
                    else if (c == "/")
                    {
                        res = s2 / s1;
                        stack.Push(res.ToString());
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            return int.Parse(stack.Pop());
        }

        public static string RemoveConsecutiveDuplicate(string A)
        {
            Stack<char> s = new Stack<char>();
            foreach (char ch in A)
            {
                if (s.Count > 0 && s.Peek() == ch)
                {
                    s.Pop();
                }
                else
                {
                    s.Push(ch);
                }
            }

            System.Text.StringBuilder sb = new StringBuilder();
            int count = s.Count;
            for (int i = 0; i < count; i++)
            {
                sb.Insert(0, s.Pop());
            }

            return sb.ToString();
        }
    }
}
