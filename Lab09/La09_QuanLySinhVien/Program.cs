using System;

namespace Lab09
{
    class Program
    {
        static void Main(string[] args)
        {
            LopHoc ctk42 = new LopHoc();

            int siSo = TienIch.NhapSoNguyen("Nhap vao so luong sinh vien: ");

            for (int i = 0; i < siSo; i++)
            {
                Console.WriteLine("Nhap vao thong tin sinh vien {0}:", i+1);
                ctk42.Them_1_SV();
            }
            Console.WriteLine("------------------------------\n");

            Console.WriteLine("Danh sach sinh vien hien tai:");
            Console.WriteLine("So luong sinh vien: {0}", ctk42.SiSo);
            ctk42.Xuat_DSSV();
            Console.WriteLine("------------------------------\n");

            Console.Write("Nhap vao ten sinh vien de tim kiem: ");
            var ten = Console.ReadLine();

            ctk42.TK_Ten(ten);
            Console.WriteLine("------------------------------\n");

            string mssv;
            do
            {
                Console.Write("Nhap vao mssv de xoa: ");
                mssv = Console.ReadLine();
            } while (mssv.Length != 7);

            ctk42.Xoa_1_SV(mssv);
            Console.WriteLine("------------------------------\n");

            Console.WriteLine("Danh sach lop hoc: ");
            Console.WriteLine("Tong so sinh vien: {0}", ctk42.SiSo);
            ctk42.Xuat_DSSV();

            Console.ReadLine();
        }
    }
}
