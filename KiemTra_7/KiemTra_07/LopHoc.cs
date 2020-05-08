using System;
using System.IO;
using System.Text;

namespace KiemTra_07
{
    public class LopHoc : IDatabase, IEncyptable
    {
        private SinhVien[] danhSachSV;
        private int siSo;
        private int MAX;

        public int SiSo { get => siSo; }

        public LopHoc()
        {
            MAX = 100;
            siSo = 0;
            danhSachSV = new SinhVien[MAX];
        }

        public void NhapThongTinLopHoc()
        {
            Console.Write("Nhap so luong sinh vien: ");
            siSo = int.Parse(Console.ReadLine());

            for (int i = 0; i < siSo; i++)
            {
                Console.WriteLine("Nhap thong tin sinh vien thu {0}", i + 1);
                Console.Write("Nhap Ho va ten dem: ");
                var hoDem = Console.ReadLine();

                Console.Write("Nhap ten: ");
                var ten = Console.ReadLine();

                Console.Write("Nhap so CMND: ");
                var CMND = Console.ReadLine();

                Console.Write("Nhap MSSV: ");
                var mssv = Console.ReadLine();

                Console.Write("Nhap lop hoc: ");
                var lop = Console.ReadLine();

                var sv = new SinhVien(hoDem, ten, CMND, mssv, lop);

                danhSachSV[i] = sv;
            }
        }

        public void Xuat_1_SV(SinhVien sv)
        {
            Console.WriteLine("| {0,-8} | {1,-15} | {2,-8} | {3,-8} | {4,-7} |", sv.MaSo, sv.HoDem, sv.Ten, sv.MSSV, sv.Lop);
        }
        private void XuatDongKe(int n)
        {
            Console.Write("+");
            for (int i = 0; i < n-2; i++)
                Console.Write("-");
            Console.Write("+");
            Console.WriteLine(); 
        }
        public void XuatDanhSachSV()
        {
            XuatDongKe(62);
            Console.WriteLine("| {0,-8} | {1,-15} | {2,-8} | {3,-8} | {4,-7} |", "Ma So", "Ho dem", "Ten", "MSSV", "Lop");
            XuatDongKe(62);
            for (int i = 0; i < siSo; i++)
            {
                Xuat_1_SV(danhSachSV[i]);
            }
            XuatDongKe(62);
        }

        public SinhVien TimKiem_HoTen(string hoDem, string ten)
        {
            for (int i = 0; i < siSo; i++)
            {
                var sv = danhSachSV[i];
                if (sv.HoDem == hoDem && sv.Ten == ten)
                    return sv;
            }

            return null;
        }

        public void TimKiem_TatCa_Ten(string ten)
        {
            Console.WriteLine("Ket qua: ");
            int dem = 0;
            for (int i = 0; i < siSo; i++)
            {
                var sv = danhSachSV[i];
                if (sv.Ten.ToLower() == ten.ToLower())
                {
                    dem++;
                    Xuat_1_SV(sv);
                }
            }

            if (dem == 0) Console.WriteLine("Khong tim thay ket qua!");
        }

        public SinhVien TimKiem_MSSV(string mssv)
        {
            for (int i = 0; i < siSo; i++)
            {
                var sv = danhSachSV[i];
                if (sv.MSSV == mssv)
                    return sv;
            }

            return null;
        }

        public void Read(string fileName)
        {
            using (var reader = File.OpenText(fileName))
            {
                Console.WriteLine("Bat dau doc du lieu tu tap tin...");
                Console.WriteLine("Xong.");

                var line = reader.ReadLine();
                line = Descrypt(line);

                siSo = int.Parse(line);

                for (int i = 0; i < siSo; i++)
                {
                    line = reader.ReadLine();
                    line = Descrypt(line);

                    var parts = line.Split(" ");

                    var hoDem = parts[1];
                    var ten = parts[2];
                    var cmnd = parts[0];                    
                    var mssv = parts[3];
                    var lop = parts[4];

                    var sv = new SinhVien(hoDem, ten, cmnd, mssv, lop);
                    danhSachSV[i] = sv;
                }

                Console.WriteLine("Bat dau giai ma du lieu ...");
                Console.WriteLine("Xong.");
            }
        }

        public void Write(string filename)
        {
            var data = new StringBuilder("");
            data.AppendLine(Encrypt(siSo.ToString()));

            for (int i = 0; i < siSo; i++)
            {
                var sv = danhSachSV[i];
                var line = $"{sv.MaSo} {sv.HoDem} {sv.Ten} {sv.MSSV} {sv.Lop}";
                var encrypedLine = Encrypt(line);
                data.AppendLine(encrypedLine);
            }

            Console.WriteLine("Ma hoa du lieu ...");
            Console.WriteLine("Xong.");

            File.WriteAllText(filename, data.ToString());

            Console.WriteLine("Ghi du lieu vao tap tin...");
            Console.WriteLine("Xong.");
        }

        public string Encrypt(string text)
        {
            string encryped = "";
            foreach(var ch in text)
            {
                encryped += (char)((int)ch + 100);
            }
            return encryped;
        }

        public string Descrypt(string text)
        {
            string descrypted = "";
            foreach (var ch in text)
            {
                descrypted += (char)((int)ch - 100);
            }
            return descrypted;
        }
    }
}
