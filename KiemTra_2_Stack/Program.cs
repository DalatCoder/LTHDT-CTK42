using System;

namespace KiemTra_2_Stack
{
    public class TienIch
    {
        public static int NhapSoNguyenTuBanPhim(string thongBaoChoNguoiDung)
        {
            int ketQua;
            while (true)
            {
                Console.Write(thongBaoChoNguoiDung);
                bool valid = int.TryParse(Console.ReadLine(), out ketQua);
                if (valid) break;
            }
            return ketQua;
        }
    }
    public class Stack
    {
        private int max; // => Luu so phan tu toi da cua stack
        private int[] array; // => Mang luu tru cac gia tri
        private uint length; // => Chieu dai hien tai cua stack

        public Stack()
        {
            max = 100; // => Mac dinh stack c0 100 phan tu
            array = new int[max];
            length = 0;
        }

        public Stack(int max)
        {
            this.max = max;
            array = new int[max];
            length = 0;
        }

        public void Reset()
        {
            length = 0;
        }

        public bool IsEmpty()
        {
            bool ketQua;

            if (length == 0)
                ketQua = true; // mang rong
            else
                ketQua = false;

            return ketQua;
        }
        public bool IsFull()
        {
            return length == max;
        }

        public void Push(int number)
        {
            if (IsFull())
            {
                // Stack full
                throw new InvalidOperationException("Stack day! Khong the them!");
            }

            array[length] = number;
            length = length + 1; 
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack rong! Khong the tra ve phan tu!");


            int number = array[length - 1]; // phan tu cuoi cung

            length = length - 1;

            return number;
        }
        public int Top()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack rong! Khong the tra ve phan tu!");

            return array[length - 1];
        }

        public void NhapTuBanPhim()
        {

            max = TienIch.NhapSoNguyenTuBanPhim("Nhap so phan tu toi da cua stack: ");

            array = new int[max];

            int number;
            for (int i = 0; i < max; i++)
            {
                number = TienIch.NhapSoNguyenTuBanPhim($"Nhap phan tu thu {i + 1}: ");
                Push(number);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var stack = new Stack();
                stack.NhapTuBanPhim();

                Console.WriteLine("Stack");


                while (!stack.IsEmpty())
                {
                    Console.WriteLine("{0}", stack.Pop());
                }

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Co loi xay ra! {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Co loi xay ra! {0}", ex.Message);
            }



            finally
            {
                // Dung chuong trinh
                Console.WriteLine("Bam phim bat ki de tiep tuc...");
                Console.ReadLine();
            }
        }
    }
}
