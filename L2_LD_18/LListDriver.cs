using System;
using System.Collections.Generic;
using System.Web;

namespace L2_LD_18
{
    /// <summary>
    /// Driver linked list
    /// </summary>
    public class LListDriver
    {
        /// <summary>
        /// Driver node in linked list
        /// </summary>
        private sealed class Node
        {
            public Driver Value { get; set; }       ///Driver node
            public Node Next { get; set; }          ///Reference to the next node

            /// <summary>
            /// Node constructor
            /// </summary>
            /// <param name="data">Driver object node</param>
            /// <param name="link">Reference to the next node in the list</param>
            public Node(Driver data, Node link)
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
        public LListDriver()
        {
            tail = new Node(new Driver(), null);
            head = new Node(new Driver(), null);
            headFifo = head;
            d = null;
        }

        /// <summary>
        /// Adds a new driver to the end of the linked list
        /// </summary>
        /// <param name="driver">Driver object to add</param>
        public void Append(Driver driver)
        {
            headFifo.Next = new Node(driver, tail);
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
        /// Gets the driver stored in the current node
        /// </summary>
        /// <returns>the driver stored in the current node</returns>
        public Driver GetDriver()
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
    }
}