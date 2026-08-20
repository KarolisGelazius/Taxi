using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2_LD_18
{
    /// <summary>
    /// Taxi linked list
    /// </summary>
    public class LListTaxi
    {
        /// <summary>
        /// Taxi node in linked list
        /// </summary>
        private sealed class Node
        {
            public Taxi Value { get; set; }     ///Taxi node
            public Node Next { get; set; }      ///Reference to the next node

            /// <summary>
            /// Node constructor
            /// </summary>
            /// <param name="data">Taxi object node</param>
            /// <param name="link">Reference to the next node in the list</param>
            public Node(Taxi data, Node link)
            {
                this.Value = data;
                this.Next = link;
            }
        }

        private Node head;      ///Reference to the beginning of the list
        private Node tail;      ///Reference to the end marker of the list
        private Node previous;  ///Reference to the previous node during iteration
        private Node headFifo;  ///Reference used for adding new nodes to the end of the list
        private Node d;         ///Reference to the current node during traversal

        /// <summary>
        /// Linked list contructor
        /// </summary>
        public LListTaxi()
        {
            tail = new Node(new Taxi(), null);
            head = new Node(new Taxi(), tail);
            headFifo = head;
            d = null;
        }

        /// <summary>
        /// Adds a new taxi to the end of the linked list
        /// </summary>
        /// <param name="taxi">Taxi object to add</param>
        public void Append(Taxi taxi)
        {
            headFifo.Next = new Node(taxi, tail);
            headFifo = headFifo.Next;
        }

        /// <summary>
        /// Moves the internal pointer to the beginning of the list
        /// </summary>
        public void Begin()
        {
            previous = head;
            d = head.Next;
        }

        /// <summary>
        /// Moves the internal pointer to the next node in the list
        /// </summary>
        public void Next()
        {
            previous = d;
            d = d.Next;
        }

        /// <summary>
        /// Checks whether the current node exists in the list
        /// </summary>
        /// <returns>True if the current node is not the tail marker; otherwise false</returns>
        public bool Exist()
        {
            return d != tail;
        }

        /// <summary>
        /// Gets the taxi stored in the current node
        /// </summary>
        /// <returns>the taxi stored in the current node</returns>
        public Taxi GetTaxi()
        {
            return d.Value;
        }

        /// <summary>
        /// Removes the current node from the linked list
        /// </summary>
        public void Remove()
        {
            previous.Next = d.Next;
            d = previous.Next;
        }

        /// <summary>
        /// Sorts the linked list
        /// </summary>
        public void Sort()
        {
            for (Node d1 = head.Next; d1 != tail; d1 = d1.Next)
            {
                Node min = d1;
                for (Node d2 = d1.Next; d2 != tail; d2 = d2.Next)
                {
                    if (d2.Value.CompareTo(min.Value) < 0)
                    {
                        min = d2;
                    }
                }

                (d1.Value, min.Value) = (min.Value, d1.Value);
            }
        }
    }
}