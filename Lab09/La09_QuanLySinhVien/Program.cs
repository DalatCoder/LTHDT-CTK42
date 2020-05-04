using System;

namespace La09_QuanLySinhVien
{
    public class SinhVien
    {
        private string _hoDem;
        private string _ten;
        private string _mssv;

        public SinhVien() { }
        public SinhVien(string hoDem, string ten, string mssv)
        {
            _hoDem = hoDem;
            _ten = ten;
            _mssv = mssv;
        }

        public string HoDem 
        {
            get { return _hoDem; }
            set { _hoDem = value; }
        }
        public string Ten { get { return _ten; } set { _ten = value; } }
        public string MSSV { get { return _mssv; } set { _mssv = value; } }

        public string HoTen { get { return _hoDem + " " + _ten; } }
        public string Hoten()
        {
            return _hoDem + " " + _ten;
        }
    }
    
    public class LopHoc
    {
        private SinhVien[] _dssv;
        private int _siSo;
        private int max;

        public LopHoc()
        {
            max = 100;
            _siSo = 0;
            _dssv = new SinhVien[max];
        }

        public int SiSo { get => _siSo; }

        public void Them_1_SV()
        {
            Console.Write("Nhap vao ho dem: ");
            var hoDem = Console.ReadLine();

            Console.Write("Nhap vao ten: ");
            var ten = Console.ReadLine();

            string mssv;
            do
            {
                Console.Write("Nhap vao mssv: ");
                mssv = Console.ReadLine();
            } while (mssv.Length != 7);

            var sv = new SinhVien(hoDem, ten, mssv);
            _dssv[_siSo] = sv;

            _siSo += 1;
        }

        public void Xuat_DSSV()
        {
            for (int i = 0; i < _siSo; i++)
                Console.WriteLine("{0}: {1}", _dssv[i].MSSV, _dssv[i].HoTen);
            Console.WriteLine();
        }
        public void TK_HoTen(string hoTen)
        {
            int dem = 0;
            Console.WriteLine("Ket qua:");
            for (int i = 0; i < _siSo; i++)
                if (hoTen == _dssv[i].HoTen)
                {
                    dem++;
                    Console.WriteLine("{0}: {1}", _dssv[i].MSSV, _dssv[i].HoTen);
                }

            if (dem == 0)
                Console.WriteLine($"Khong tim thay sinh vien co ho ten: '{hoTen}'");
        }

        public void TK_Ten(string ten)
        {
            int dem = 0;
            
            Console.WriteLine("Ket qua:");
            for (int i = 0; i < _siSo; i++)
                if (ten == _dssv[i].Ten)
                {
                    dem++;
                    Console.WriteLine("{0}: {1}", _dssv[i].MSSV, _dssv[i].HoTen);
                }

            if (dem == 0)
                Console.WriteLine($"Khong tim thay sinh vien co ten: '{ten}'");
        }

        public SinhVien TK_MSSV(string mssv)
        {
            for (int i = 0; i < _siSo; i++)
                if (mssv == _dssv[i].MSSV)
                    return _dssv[i];

            return null;
        }

        public void Xoa_1_SV(string mssv)
        {
            // Tìm chỉ số của sv cần xóa
            var sv = TK_MSSV(mssv);
            if (sv == null)
            {
                Console.WriteLine("Khong tim thay sinh vien co MSSV: {0}", mssv);
                return;
            }

            int i = 0;
            for (i = 0; i < _siSo; i++)
            {
                if (_dssv[i].MSSV == mssv)
                    break;
            }

            // Xóa sinh viên
            for (int j = i; j < _siSo - 1; j++)
                _dssv[j] = _dssv[j + 1];

            _siSo -= 1;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            LopHoc ctk42 = new LopHoc();

            int siSo = 0;
            Console.Write("Nhap vao so luong sinh vien: ");
            siSo = int.Parse(Console.ReadLine());

            for (int i = 0; i < siSo; i++)
            {
                Console.WriteLine("Nhap vao thong tin sinh vien {0}:", i+1);
                ctk42.Them_1_SV();
            }
            Console.WriteLine("------------------------------\n");

            Console.WriteLine("Danh sach sinh vien hien tai:");
            ctk42.Xuat_DSSV();
            Console.WriteLine("------------------------------\n");

            Console.Write("Nhap vao ten sinh vien de tim kiem: ");
            var ten = Console.ReadLine();

            ctk42.TK_Ten(ten);
            Console.WriteLine("------------------------------\n");

            Console.Write("Nhap vao mssv de xoa: ");
            var mssv = Console.ReadLine();

            ctk42.Xoa_1_SV(mssv);
            Console.WriteLine("------------------------------\n");

            Console.WriteLine("Danh sach lop hoc cuoi cung: ");
            ctk42.Xuat_DSSV();

            Console.ReadLine();
        }
    }
}
