using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doublelinklist
{
    class cNode
    {
        int V;
        cNode Prev, Next;
        cNode(int v) { V = v; }


        static cNode H, T;
        /// <summary>
        /// make node with x and y
        /// put node in right place in ordered list by value x
        /// </summary>
        /// <algo>
        /// if therre is no list then H=N and T=N
        /// else
        /// put node behind T ( set 2 adresses and adjust T)
        /// or before H (set 2 adresses and adjust H)
        /// or betweeen H and T (search right place from begin, set 4 adresses)
        /// </algo>

        public static void AddToList(int x)
        {
            cNode n = new cNode(x);
            if (H == null)
            {
                H = n;
                T = n;
            }
            else
            {
                if (n.V > T.V)
                {
                    n.Prev = T;
                    T.Next = n;
                    T = n;
                }
                else
                {
                    if (n.V <= H.V)
                    {
                        n.Next = H;
                        H.Prev = n;
                        H = n;
                    }
                    else
                    {
                        cNode curr = H;
                        while (n.V > curr.V)
                        {
                            curr = curr.Next;
                        }
                        n.Prev = curr.Prev;
                        n.Next = curr;
                        curr.Prev.Next = n;
                        curr.Prev = n;
                    }
                }
            }
        }
        
        /// <summary>
        /// Get the array back in a list
        /// </summary>
        /// <algorithm>
        /// Create an int and cNode. If the current is not null, current is current.Next.
        /// </algorithm>
        public static int[] getList()
        {
            int counting = 0;
            cNode current = H;
            while (current != null)
            {
                current = current.Next;
                counting++;
            }
            int[] arr = new int[counting];
            current = H;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = current.V;
                current = current.Next;
            }
            return arr;
        }
    }
}
