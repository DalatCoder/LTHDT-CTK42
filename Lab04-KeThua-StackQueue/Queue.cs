using System;

namespace NamespaceQ
{
    public class Queue : NamespaceSQ.SQ
    {
        private int front;
        private int rear;

        public Queue() : base()
        {
            front = 0;
            rear = 0;
        }
        public Queue(int max) : base(max)
        {
            front = 0;
            rear = 0;
        }

        public new bool IsFull()
        {
            if (rear == max)
                return true;
            else
                return false;
        }
        public new bool IsEmpty()
        {
            if (front == rear)
                return true;
            else
                return false;
        }
        public new void Push(double number)
        {
            if (IsFull() == true)
            {
                Console.WriteLine("Queue day!");
                return;
            }

            array[rear] = number;
            rear += 1;
        }
        public new double Pop()
        {
            if (IsEmpty() == true)
            {
                Console.WriteLine("Queue rong!");
                return -1;
            }

            double number = array[front];

            front += 1;

            return number;
        }

        public new double Top()
        {
            if (IsEmpty() == true)
            {
                Console.WriteLine("Queue rong!");
                return -1;
            }

            return array[front];
        }
    }
}
