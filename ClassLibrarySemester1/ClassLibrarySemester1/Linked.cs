using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1
{
    public class ListNodeInt
    {
        private int data;
        // Singly linked list only knows the next.
        private ListNodeInt next;
        // Doubly linked list also knows the previous.
        // private ListNode prev;

        public ListNodeInt(int data, ListNodeInt next = null)
        {
            this.data = data;
            this.next = next;
        }

        public int getData()
        {
            return data;
        }

        public ListNodeInt getNext()
        {
            return next;
        }

        internal void setNext(ListNodeInt next)
        {
            this.next = next;
        }

        internal void setData(int data)
        {
            this.data = data;
        }

        public int getSize()
        {
            if (next != null)
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
            for (ListNodeInt i = this; i != null; i = i.getNext())
            {
                if (result.Length != 0)
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

    public class LinkedListInt
    {
        private ListNodeInt first = null;

        public LinkedListInt(params int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                add(numbers[i]);
            }
        }

        public ListNodeInt getFirst()
        {
            return this.first;
        }

        public ListNodeInt getLast()
        {
            ListNodeInt result = first;
            // While this node still contains a next node...
            while (result.getNext()!=null)
            {
                // Switch to the next node...
                result = result.getNext();
            }
            // Return the node without a next node.
            return result;
        }

        public int getSize()
        {
            return this.first.getSize();
        }

        public void add(int value)
        {
            append(value);
        }

        public bool isEmpty()
        {
            return (first == null);
        }

        /// <summary>
        /// Adds a new listNode at the end of the list.
        /// </summary>
        /// <param name="value">The value to store in de last node.</param>
        internal void append(int value)
        {
            ListNodeInt newNode = new ListNodeInt(value);
            if (isEmpty())
            {
                first = newNode;
            }
            else
            {
                // Create a next node for the last element.
                getLast().setNext(newNode);
            }
        }

        /// <summary>
        /// Adds a new node at the beginning of the list.
        /// </summary>
        /// <param name="value">The value to store in de first node.</param>
        internal void prepend(int value)
        {
            first = new ListNodeInt(value, first);
        }

        public override string ToString()
        {
            return "[ " + first.ToString() + " ]";
        }
    }

    public class ListNodeObj
    {
        private IComparable data;
        private ListNodeObj next;
        // Doubly linked list also knows the previous.
        // private ListNode prev;

        public ListNodeObj(IComparable data, ListNodeObj next = null)
        {
            this.data = data;
            this.next = next;
        }

        public IComparable getData()
        {
            return data;
        }

        public ListNodeObj getNext()
        {
            return next;
        }

        internal void setNext(ListNodeObj next)
        {
            this.next = next;
        }

        internal void setData(IComparable data)
        {
            this.data = data;
        }

        public int getSize()
        {
            if (next != null)
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
            for (ListNodeObj i = this; i != null; i = i.getNext())
            {
                if (result.Length != 0)
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

    public class LinkedListObj
    {
        private ListNodeObj first = null;
        private ListNodeObj last = null;

        public LinkedListObj(params IComparable[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
//                Console.WriteLine(this);
                add(data[i]);
            }
//            Console.WriteLine(this);
        }

        public ListNodeObj getFirst()
        {
            return this.first;
        }

        public ListNodeObj getLast()
        {
            return this.last;
        }

        public int getSize()
        {
            return this.first.getSize();
        }

        public virtual void add(IComparable value)
        {
            append(value);
        }

        public bool isEmpty()
        {
            return (first == null);
        }

        /// <summary>
        /// Adds a new listNode at the end of the list.
        /// </summary>
        /// <param name="value">The value to store in de last node.</param>
        internal void append(IComparable value)
        {
            ListNodeObj newNode = new ListNodeObj(value);
            if (isEmpty())
            {
                first = newNode;
            }
            else
            {
                // Create a next node for the last element.
                getLast().setNext(newNode);
            }
            // Store the new last node.
            last = newNode;
        }

        /// <summary>
        /// Adds a new node at the beginning of the list.
        /// </summary>
        /// <param name="value">The value to store in de first node.</param>
        internal void prepend(IComparable value)
        {
            first = new ListNodeObj(value, first);
            if (first.getNext()==null)
            {
                last = first;
            }
        }

        public override string ToString()
        {
            return "[ " + ((first==null)?"":first.ToString()) + " ]";
        }
    }

    public class OrderedListObj : LinkedListObj
    {
        public OrderedListObj(params IComparable[] data) : base(data)
        {
        }

        public override void add(IComparable value)
        {
            // If there is no data yet.
            if (isEmpty())
            {
                // Simply use the prepend function.
                // That always works for the first node.
                prepend(value);
            }
            // IF the new data goes BEFORE all current data.
            else if (value.CompareTo(getFirst().getData())<0)
            {
                // Add a new node at the beginning.
                prepend(value);
            }
            // IF the new data goes AFTER all current data...
            else if (value.CompareTo(getLast().getData())>=0)
            {
                // THEN add a new node at the end.
                append(value);
            }
            else
            {
                // Look for the node that comes before the new one.
                ListNodeObj current = getFirst();
                while (current.getNext().getData().CompareTo(value) < 0)
                {
                    // Skip to the next node.
                    current = current.getNext();
                }
                // Store the next node.
                ListNodeObj after = current.getNext();
                // Create a new node.
                // It holds the new data and the node that comes after it.
                ListNodeObj newNode = new ListNodeObj(value, after);
                // Replace the next node of the current node...
                current.setNext(newNode);
            }
        }
    }
}
