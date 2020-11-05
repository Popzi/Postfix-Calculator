using System;
using System.Text;

namespace ADTStack
{
    interface ADTStack<T>
    {
        void Push(T value);
        T Pop();
        T Peek();
        void Display();
        int Count();
        string ToString();
        T[] ToArray();
        void Clear();

    }
    public class NodeStack<T> : ADTStack<T>
    {
        private class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }

            public Node(T item)
            {
                this.Item = item;
                this.Next = null;
            }

            public Node(T item, Node next)
            {
                this.Item = item;
                this.Next = next;
            }
        }

        private Node top;
        private int count;

        public NodeStack()
        {
            this.top = null;
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        int ADTStack<T>.Count() {
            return this.Count;
        }

        public void Display()
        {
            Node currentNode = this.top;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Item.ToString());
                currentNode = currentNode.Next;
            }
        }

        public T Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return this.top.Item;
        }

        public T Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            T result = this.top.Item;
            this.top = this.top.Next;
            this.count--;

            return result;
        }

        public void Push(T item)
        {
            if (this.top == null)
            {
                this.top = new Node(item);
            }
            else
            {
                Node newNode = new Node(item, this.top);
                this.top = newNode;
            }

            this.count++;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            Node currentNode = this.top;
            while (currentNode != null)
            {
                result.Append(currentNode.Item.ToString());
                currentNode = currentNode.Next;
            }

            return result.ToString();
        }

        public T[] ToArray()
        {
            T[] result = new T[this.count];

            Node currentNode = this.top;
            for (int i = 0; i < this.count; i++)
            {
                result[i] = currentNode.Item;
                currentNode = currentNode.Next;
            }

            return result;
        }

        public void Clear()
        {
            this.top = null;
            this.count = 0;
        }
    }
}
