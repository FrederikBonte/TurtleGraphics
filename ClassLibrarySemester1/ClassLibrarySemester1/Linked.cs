using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1
{
    public class ListNode
    {
        private int data;
        // Singly linked list only knows the next.
        private ListNode next;
        // Doubly linked list also knows the previous.
        // private ListNode prev;

        public ListNode(int data, ListNode next = null)
        {
            this.data = data;
            this.next = next;
        }

        public int getData()
        {
            return data;
        }

        public ListNode getNext()
        {
            return next;
        }

        internal void setNext(ListNode next)
        {
            this.next = next;
        }

        internal void setData(int data)
        {
            this.data = data;
        }

        public int getSize()
        {
            if (next!=null)
            {
                return next.getSize() + 1;
            }
            else
            {
                return 1;
            }
        }

        public override string ToString()
        {
            // Print this nodes data.
            string result = "";

            // Loop through all elements of the node.
            for (ListNode i = this; i != null; i = i.getNext())
            {
                if (result.Length!=0)
                {
                    result += ", ";
                }
                // Add the data of the curent node.
                result += i.getData().ToString();
            }

            // Return the string representation of this list.
            return result;
        }
    }

    public class LinkedList
    {
        private ListNode first = null;
        private ListNode last = null;

        public LinkedList(params int[] numbers)
        {
            first = createListNodes(numbers);
            last = first;
            if (last!=null)
            {
                // Find the last node...
                while (last.getNext()!=null)
                {
                    // Store the next node...
                    last = last.getNext();
                }
            }
        }

        public ListNode getFirst()
        {
            return this.first;
        }

        public ListNode getLast()
        {
            return this.last;
        }

        public int getSize()
        {
            return this.first.getSize();
        }

        /// <summary>
        /// Adds a new listNode at the end of the list.
        /// </summary>
        /// <param name="value">The value to store in de last node.</param>
        public void append(int value)
        {
            // Create a next node for the last element.
            getLast().setNext(new ListNode(value));
            // Store the new last node.
            last = getLast().getNext();
        }

        /// <summary>
        /// Adds a new node at the beginning of the list.
        /// </summary>
        /// <param name="value">The value to store in de first node.</param>
        public void prepend(int value)
        {
            first = new ListNode(value, first);
        }

        public override string ToString()
        {
            return "[ "+first.ToString()+" ]";
        }

        private static ListNode createListNodes(params int[] numbers)
        {
            ListNode first = null;

            for (int i = numbers.Length-1; i >= 0; i--)
            {
                // Create a new first node.
                // That points to the previous first node.
                ListNode newNode = new ListNode(numbers[i], first);
                // New node becomes the first node.
                first = newNode;
            }

            // Return the first node of the list.
            return first;
        }
    }
}
