using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public class RandomListNode
    {
        public int label;
        public RandomListNode next;
        public RandomListNode random;
        public RandomListNode(int x) { this.label = x; }

    };

    //Create Linked List Data structure
    public class LL
    {
        public int value;
        public LL pointer;
        public LL(int value)
        {
            this.value = value;
            pointer = null;
        }
    }
    public class LinkedList_1
    {
        //Initialize head pointer…
        static LL head = null;

        //Function to get the size of linkedlist
        static int size(LL head)
        {
            int cnt = 0;
            while (head != null)
            {
                cnt++;
                head = head.pointer;
            }
            return cnt;
        }

        public static void insert_node(int position, int value)
        {
            // @params position, integer
            // @params value, integer
            LL newNode = new LL(value);
            LL ptr = head;

            if (position == 1)
            {
                newNode.pointer = ptr;
                head = newNode;
            }
            else
            {
                for (int i = 1; i < position - 1; i++)
                {
                    ptr = ptr.pointer;
                }
                newNode.pointer = ptr.pointer;
                ptr.pointer = newNode;
            }
        }

        public static void delete_node(int position)
        {
            // @params position, integer
            LL ptr = head;
            LL temp = head;

            //Check the position whether it is in linked list or not
            if (position <= size(temp))
            {
                if (position == 1)
                {
                    head = head.pointer;
                }
                else
                {
                    for (int i = 1; i < position - 1; i++)
                    {
                        ptr = ptr.pointer;
                    }
                    ptr.pointer = ptr.pointer.pointer;
                }
            }
        }

        public static void print_ll()
        {
            // Output each element followed by a space
            LL ptr = head;
            while (ptr.pointer != null)
            {
                Console.Write($"{ptr.value}");

                ptr = ptr.pointer;
            }
            Console.Write($"{ptr.value}");
        }

        public RandomListNode copyRandomList(RandomListNode head)
        {
            // code here
            RandomListNode cur = head;
            while (cur != null)
            {
                RandomListNode temp = cur.next;
                cur.next = new RandomListNode(cur.label);
                cur.next.next = temp;
                cur = temp;
            }

            cur = head;

            while (cur != null)
            {
                if (cur.next != null)
                {
                    cur.next.random = cur.random != null ? cur.random.next : null;
                }

                cur = cur.next.next;
            }

            RandomListNode org = head;
            RandomListNode copy = head.next;
            RandomListNode tmp = copy;
            while (org != null)
            {
                org.next = org.next.next;
                copy.next = copy.next.next;
                org = org.next;
                copy = copy.next;
            }

            return tmp;
        }
    }
}
