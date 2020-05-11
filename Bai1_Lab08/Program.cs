using System;

namespace Bai1_Lab08
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Nhap vao 1 so thap phan: ");
                var dec1 = Convert.ToInt32(Console.ReadLine());
                var bin1 = new NhiPhan(dec1);
                Console.WriteLine("Chuoi nhi phan tuong ung: ");
                Console.WriteLine(bin1);

                Console.WriteLine("Nhap vao so thap phan thu hai: ");
                var dec2 = Convert.ToInt32(Console.ReadLine());
                var bin2 = new NhiPhan(dec2);
                Console.WriteLine("Chuoi nhi phan tuong ung: ");
                Console.WriteLine(bin2);

                var sum = bin1 + bin2;
                Console.WriteLine($"{bin1} + {bin2} = {sum}");
                Console.WriteLine($"Gia tri thap phan tuong ung: {sum.GetDecimal()}");

                var sub = bin1 - bin2;
                Console.WriteLine($"{bin1} - {bin2} = {bin1 - bin2}");
                Console.WriteLine($"Gia tri thap phan tuong ung: {sub.GetDecimal()}");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Co loi xay ra! {0}", ex.Message);
            }
        }
    }
}
