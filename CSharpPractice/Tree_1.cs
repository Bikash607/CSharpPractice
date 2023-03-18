namespace CSharpPractice
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int x) { val = x; left = null;  right = null; }

    }
    public static class Tree_1
    {
        //Recursive Approach
        public static List<int> InorderTraversal(TreeNode A)
        {
            TreeNode root = A;
            List<int> ans = new List<int>();
            InOrder(root, ans);
            return ans;
        }

        public static void InOrder(TreeNode? root, List<int> ans)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.left, ans);
            ans.Add(root.val);
            InOrder(root.right, ans);
        }

        //Iterative Approach using stack
        public static List<int> InorderTraversal_Iterative(TreeNode? A)
        {
            TreeNode? root = A;
            List<int> ans = new List<int>();
            Stack<TreeNode> nodes = new Stack<TreeNode>();
            while (true)
            {
                if (root != null)
                {
                    nodes.Push(root);
                    root = root.left;
                }
                else
                {
                    if (nodes == null || nodes.Count <= 0)
                    {
                        break;
                    }

                    root = nodes.Pop();
                    ans.Add(root.val);
                    root = root.right;
                }
            }

            return ans;
        }

        // Preorder Traversal Recursive
        public static void PreOrder(TreeNode? root, List<int> ans)
        {
            if (root == null)
            {
                return;
            }

            ans.Add(root.val);
            PreOrder(root.left, ans);
            PreOrder(root.right, ans);
        }

        public static List<int> PreOrderTraversal_Iterative(TreeNode? A)
        {
            List<int> ans = new List<int>();
            TreeNode root = A;
            Stack<TreeNode> nodes = new Stack<TreeNode>();
            while(true)
            {
                if(root != null)
                {
                    ans.Add(root.val);
                    nodes.Push(root);
                    root = root.left;
                }
                else
                {
                    if(nodes == null || nodes.Count ==0)
                    {
                        break;
                    }
                    else
                    {
                        root = nodes.Pop();
                        root = root.right;
                    }
                }
            }
            return ans;
        }
    }
}
