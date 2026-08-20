using System;
using System.Collections.Generic;
using System.Web;

namespace L2_LD_18
{
    /// <summary>
    /// Car linked list
    /// </summary>
    public sealed class LListCar
    {
        /// <summary>
        /// Car node in linked list
        /// </summary>
        private sealed class Node
        {
            public Car Value { get; set; }  ///Car node
            public Node Next { get; set; }  ///Reference to the next node

            /// <summary>
            /// Node constructor
            /// </summary>
            /// <param name="data">Car object node</param>
            /// <param name="link">Reference to the next node in the list</param>
            public Node(Car data, Node link)
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
        public LListCar()
        {
            tail = new Node(new Car(), null);
            head = new Node(new Car(), null);
            headFifo = head;
            d = null;
        }

        /// <summary>
        /// Adds a new car to the end of the linked list
        /// </summary>
        /// <param name="car">Car object to add</param>
        public void Append(Car car)
        {
            headFifo.Next = new Node(car, tail);
            headFifo = headFifo.Next;
        }

        /// <summary>
        /// Moves the internal pointer to the beginning of the list
        /// </summary>
        public void Begin() {
            previous = head;
            d = head.Next;
        }

        /// <summary>
        /// Moves the internal pointer to the next node in the list
        /// </summary>
        public void Next() {
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
        /// Gets the car stored in the current node
        /// </summary>
        /// <returns>the car stored in the current node</returns>
        public Car GetCar()
        {
            return d.Value;
        }

        /// <summary>
        /// Removes the current node from the linked list
        /// </summary>
        public void Remove() {
            previous.Next = d.Next;
            d = previous.Next;
        }
    }
}