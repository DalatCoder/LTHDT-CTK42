using System;

namespace KiemTra_CC
{
    class Program
    {
        static void Main(string[] args)
        {
            // string path = @"C:\Users\Trong Hieu\DEV\LTHDT-CTK42\KiemTra_CuoiCung\KiemTra_CC\data.txt";
            // Lưu file ở trong tập tin có tên data.txt trong ổ đĩa D, thư mục data
            string path = @"D:\data\data.txt";

            QuanLyGV quanLy = new QuanLyGV();

            quanLy.NhapDSGV();
            // quanLy.Read(path); // chỉ đọc khi nào đã có file mã hoá
            quanLy.XuatDSGV();
            quanLy.Write(path);

            Console.WriteLine("Ghi du lieu thanh cong!");

            Console.Write("Nhap vao ten de tim kiem: ");
            var ten = Console.ReadLine();
            quanLy.TK_TatCa_Ten(ten);

            Console.Write("Nhap vao ma so de tim kiem: ");
            var ms = Console.ReadLine();
            var gv = quanLy.TK_1_maSo(ms);
            if (gv is null)
                Console.WriteLine("Khong tim thay giao vien co ma so '{0}'", ms);
            else
                quanLy.Xuat_1_GV(gv);

            Console.Write("Nhap vao ho dem de tim kiem: ");
            var hoDem = Console.ReadLine();
            Console.Write("Nhap vao ten de tim kiem: ");
            ten = Console.ReadLine();
            gv = quanLy.TK_1_HoTen(hoDem, ten);
            if (gv is null)
                Console.WriteLine("Khong tim thay giao vien co ho va ten '{0} {1}'", hoDem, ten);
            else
                quanLy.Xuat_1_GV(gv);

            Console.ReadLine();
        }
    }
}
