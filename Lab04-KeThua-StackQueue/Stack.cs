using System;

namespace NamespaceS
{
    public class Stack : NamespaceSQ.SQ
    {
        private int length;

        public Stack() : base()
        {
            length = 0;
        }
        public Stack(int max) : base(max)
        {
            length = 0;
        }

        public new bool IsFull()
        {
            if (length == max)
                return true;
            else
                return false;
        }
        public new bool IsEmpty()
        {
            if (length == 0)
                return true;
            else
                return false;
        }

        public new void Push(double number)
        {
            if (IsFull() == true)
            {
                Console.WriteLine("Stack day!");
                return;
            }

            array[length] = number;
            length += 1;
        }

        public new double Pop()
        {
            if (IsEmpty() == true)
            {
                Console.WriteLine("Stack rong!");
                return -1;
            }

            double number = array[length - 1];

            length = length - 1;

            return number;
        }

        public new double Top()
        {
            if (IsEmpty() == true)
            {
                Console.WriteLine("Stack rong!");
                return -1;
            }

            return array[0];
        }
    }
}
