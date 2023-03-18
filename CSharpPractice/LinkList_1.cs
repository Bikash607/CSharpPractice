using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            this.val = x; this.next = null;
        }
    }

    public class LinkList_1
    {
        public void PrintLinkList(ListNode A)
        {
            ListNode temp = A;
            while (temp != null)
            {
                Console.Write(temp.val + " ");
                temp = temp.next;
            }

            Console.WriteLine();
        }
        public ListNode InsertLinkList(ListNode A, int B, int C)
        {
            if (C == 0)
            {
                ListNode temp = new ListNode(B);
                temp.next = A;
                return temp;
            }
            else
            {
                int count = 0;
                ListNode temp = A;
                while (count != C - 1 && temp.next != null)
                {
                    temp = temp.next;
                    count++;
                }

                ListNode n = new ListNode(B);
                n.next = temp.next;
                temp.next = n;
                return A;
            }
        }

        public int solve(ListNode A, int B)
        {
            if (B == 0)
            {
                return B;
            }

            ListNode temp = A;
            int count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.next;
                if (count == B)
                {
                    return count;
                }
            }

            return B;
        }
    }
}
