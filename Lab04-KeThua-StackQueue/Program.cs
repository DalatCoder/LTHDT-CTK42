using System;
using System.Net.Http.Headers;

namespace BT1_KETHUA
{
    class Program
    {
        static void Main(string[] args)
        {
            NamespaceS.Stack stack = new NamespaceS.Stack(10);

            for (int i = 0; i < 10; i++)
                stack.Push(i);
            for (int i = 0; i < 10; i++)
                Console.WriteLine(stack.Pop());    
            Console.WriteLine();

            NamespaceQ.Queue queue = new NamespaceQ.Queue(10);
            
            for (int i = 0; i < 10; i++)
                queue.Push(i);
            for (int i = 0; i < 10; i++)
                Console.WriteLine(queue.Pop());

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
