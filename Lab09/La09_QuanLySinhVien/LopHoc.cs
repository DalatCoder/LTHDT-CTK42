using System;
using System.IO;

namespace Lab09
{
    public class LopHoc : IODatabase
    {
        private SinhVien[] _dssv;
        private int _siSo;
        private int max;
        private string _data;

        public LopHoc()
        {
            max = 100;
            _siSo = 0;
            _dssv = new SinhVien[max];
        }

        public int SiSo { get => _siSo; }
        public string Data { get => _data; }

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

        public void Doc(string FileName)
        {
            using(var fileReader = new StreamReader(FileName))
            {
                _siSo = int.Parse(fileReader.ReadLine());
                _dssv = new SinhVien[_siSo];

                for (int i = 0; i < _siSo; i++)
                {
                    _dssv[i].MSSV = fileReader.ReadLine();
                    _dssv[i].HoDem = fileReader.ReadLine();
                    _dssv[i].Ten = fileReader.ReadLine();
                }
            }
        }

        public void Xuat(string FileName)
        {
            using (var fileWriter = File.AppendText(FileName))
            {
                fileWriter.WriteLine(_data);
            }
        }
    }
}
