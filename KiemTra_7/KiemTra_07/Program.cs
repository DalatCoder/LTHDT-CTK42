using System;
using System.IO;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace KiemTra_07
{
    public class Nguoi
    {
        protected string _hoDem;
        protected string _ten;
        protected string _maSo;

        public string HoDem { get => _hoDem; set => _hoDem = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public string MaSo { get => _maSo; set => _maSo = value; }

        public Nguoi(string hoDem, string ten, string maso)
        {
            _hoDem = hoDem;
            _ten = ten;
            _maSo = maso;
        }
    }

    public class SinhVien : Nguoi
    {
        private string _mssv;
        private string _lop;

        public SinhVien(string hoDem, string ten, string maSo, string mssv, string lop)
            : base(hoDem, ten, maSo)
        {
            _mssv = mssv;
            _lop = lop;
        }

        public string MSSV { get => _mssv; set => _mssv = value; }
        public string Lop { get => _lop; set => _lop = value; }
    }

    interface IDatabase
    {
        void Read(string fileName);
        void Write(string filename);
    }

    interface IEncyptable
    {
        string Encrypt(string text);
        string Descrypt(string text);
    }

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

        private void Xuat_1_SV(SinhVien sv)
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
                var line = reader.ReadLine();
                line = Descrypt(line);

                siSo = int.Parse(line);

                Console.WriteLine("Bat dau giai ma du lieu ...");

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

                Console.WriteLine("Giai ma du lieu thanh cong!");
                Console.WriteLine("Doc du lieu tu tap tin thanh cong!");
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
            Console.WriteLine("Ma hoa xong!");

            File.WriteAllText(filename, data.ToString());

            Console.WriteLine("Ghi du lieu vao tap tin...");
            Console.WriteLine("Ghi du lieu thanh cong!");
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

    class Program
    {
        static void Main(string[] args)
        {
            string openPath = @"C:\Users\Trong Hieu\DEV\LTHDT-CTK42\KiemTra_7\KiemTra_07\data_encrypted.txt";
            string writePath = @"C:\Users\Trong Hieu\DEV\LTHDT-CTK42\KiemTra_7\KiemTra_07\data_encrypted.txt";
            var lop = new LopHoc();
            lop.Read(openPath);

            Console.WriteLine();
            Console.WriteLine("DANH SACH LOP");
            Console.WriteLine($"Si so: {lop.SiSo}\n");
            lop.XuatDanhSachSV();

            lop.Write(writePath);
            
            Console.ReadLine();
        }
    }
}
