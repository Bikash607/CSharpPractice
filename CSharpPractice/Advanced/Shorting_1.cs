using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Advanced
{
    public static class Shorting_1
    {

        // Kth smallest element in the Array
        // Default implementation of priority queue is mean heap
        public static int kthsmallestElement(List<int> A, int B)
        {
            PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(new InMaxCompare());
            for (int i=0; i<B;i++)
            {
                maxHeap.Enqueue(A[i], A[i]);
            }

            for(int i=B;i<A.Count;i++)
            {
                if (maxHeap.Peek() > A[i])
                {
                    maxHeap.Dequeue();
                    maxHeap.Enqueue(A[i], A[i]);
                }
            }

            return maxHeap.Peek();
        }

        // kth Largest element int the array
        public static int kthLargestElement(List<int> A, int B)
        {
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>(new InMinCompare());
            for (int i = 0; i < B; i++)
            {
                minHeap.Enqueue(A[i], A[i]);
            }

            for (int i = B; i < A.Count; i++)
            {
                if (minHeap.Peek() < A[i])
                {
                    minHeap.Dequeue();
                    minHeap.Enqueue(A[i], A[i]);
                }
            }

            return minHeap.Peek();
        }

        // kth smallest element using selection sort
        public static int kthsmallest(List<int> A, int B)
        {
            int n = A.Count;
            for(int i=0; i<n;i++)
            {
                int min = int.MaxValue;
                int minIndex = i;
                for(int j =i;j<n; j++)
                {
                    if (A[j] < min)
                    {
                        min = A[j];
                        minIndex = j;
                    }
                }

                //swaping of element;
                int temp = A[i];
                A[i] = A[minIndex];
                A[minIndex] = temp;
            }

            return A[B - 1];
        }
    }

    public class InMaxCompare: IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }


    public class InMinCompare : IComparer<int>
    {
        public int Compare(int x, int y) => x.CompareTo(y);
    }

}
