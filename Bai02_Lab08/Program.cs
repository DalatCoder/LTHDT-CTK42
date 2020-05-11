using System;
using System.Collections.Specialized;
using System.Drawing;

namespace Bai02_Lab08
{
    class Program
    {
        public class cosothaplucphan
        {
            private int[] _arr = new int[16];
            private int[] arr { get { return _arr; } set { _arr = value; } }

            public cosothaplucphan(int x)
            {
                int c = 15;

                if (x < 0)
                {
                    arr[0] = 1;
                }
                else
                {
                    arr[0] = 0;
                }

                while (c != 1)
                {
                    arr[c] = x % 16;
                    x = x / 16;
                    c--;
                }
            }

            public void output()
            {
                Console.Write("day nhi phan : ");
                for (int i = 0; i < 16; i++)
                {
                    string ch = "";
                    switch (arr[i])
                    {
                        case 10: 
                            ch = "A"; 
                            break;
                        case 11:
                            ch = "B";
                            break;
                        case 12:
                            ch = "C";
                            break;
                        case 13:
                            ch = "D";
                            break;
                        case 14:
                            ch = "E";
                            break;
                        case 15:
                            ch = "F";
                            break;
                        default:
                            ch = arr[i].ToString();
                            break;
                    }
                    Console.Write(ch);
                }
            }
        }
        public class cosonhiphan
        {
            private int[] _ar = new int[8];
            public int[] ar { get { return _ar; } set { _ar = value; } }
            public cosonhiphan(int x)
            {
                int c = 7;
                if (x > 0)
                {
                    ar[0] = 1;
                }
                else
                {
                    ar[0] = 0;
                }
                while (c != 1)
                {
                    ar[c] = x % 2;
                    x = x / 2;
                    c--;
                }

            }
            public void input()
            {
                int kq;
                Console.WriteLine("nhap vao mot so nguyen: ");
                kq = Int32.Parse(Console.ReadLine());
                int c = 7;
                if (kq > 0)
                {
                    ar[0] = 1;
                }
                else
                {
                    ar[0] = 0;
                }
                while (c != 1)
                {
                    ar[c] = kq % 2;
                    kq = kq / 2;
                    c--;
                }
            }
            public void output()
            {
                Console.Write("day nhi phan : ");
                for (int i = 0; i < 8; i++)
                {
                    Console.Write("{0} ", ar[i]);
                }
            }
        }



        static void Main(string[] args)
        {
            var test = new cosothaplucphan(255);
            test.output();

            Console.ReadLine();
        }
    }
}
