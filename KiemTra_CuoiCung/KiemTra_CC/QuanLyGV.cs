using System;
using System.IO;

namespace KiemTra_CC
{
    public class QuanLyGV : IODatabase, IBaoMat
    {
        private GiaoVien[] danhSachGV;
        private int tongSo;
        private int MAX = 100;

        public QuanLyGV()
        {
            tongSo = 0;
            danhSachGV = new GiaoVien[MAX];
        }

        public void NhapDSGV()
        {
            while (true)
            {
                Console.Write("Nhap vao tong so giao vien: ");
                bool isValid = int.TryParse(Console.ReadLine(), out tongSo);
                if (isValid) break;
            }
            
            for (int i = 0; i < tongSo; i++)
            {
                Console.WriteLine("Nhap thong tin giao vien thu {0}", i + 1);
                Console.Write("Nhap vao ma so: "); var maSo = Console.ReadLine();
                Console.Write("Nhap vao ho dem: "); var hoDem = Console.ReadLine();
                Console.Write("Nhap vao ten: "); var ten = Console.ReadLine();
                Console.Write("Nhap vao mon hoc: "); var monHoc = Console.ReadLine();

                danhSachGV[i] = new GiaoVien(hoDem, ten, maSo, monHoc);
            }
        }

        public void Xuat_1_GV(GiaoVien gv)
        {
            Console.WriteLine("| {0,5} | {1,7} | {2,20} | {3,10} | {4,10} |", gv.ID, gv.MaSo, gv.HoDem, gv.Ten, gv.TenBoMon);
        }

        public void XuatDSGV()
        {
            Console.WriteLine("Tong so giao vien trong danh sach: {0}", tongSo);
            Console.WriteLine("| {0,5} | {1,7} | {2,20} | {3,10} | {4,10} |", "ID", "Ma so", "Ho dem", "Ten", "Ten bo mon");
            for (int i = 0; i < tongSo; i++)
                Xuat_1_GV(danhSachGV[i]);
            Console.WriteLine();
        }

        public GiaoVien TK_1_HoTen(string hodem, string ten)
        {
            for (int i = 0; i < tongSo; i++)
                if (danhSachGV[i].HoDem == hodem && danhSachGV[i].Ten == ten)
                    return danhSachGV[i];
            return null;
        }
        public GiaoVien TK_1_maSo(string maso)
        {
            for (int i = 0; i < tongSo; i++)
                if (danhSachGV[i].MaSo == maso)
                    return danhSachGV[i];
            return null;
        }
        public void TK_TatCa_Ten(string ten)
        {
            Console.WriteLine("Ket qua: ");
            int dem = 0;

            for (int i = 0; i < tongSo; i++)
                if (danhSachGV[i].Ten == ten)
                {
                    Xuat_1_GV(danhSachGV[i]);
                    dem++;
                }

            if (dem == 0)
                Console.WriteLine("Khong tim thay giao vien nao!");
        }
      
        public void Read(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader reader = new StreamReader(fs);

            tongSo = int.Parse(GiaiMa(reader.ReadLine()));

            for (int i = 0; i < tongSo; i++)
            {
                var id = GiaiMa(reader.ReadLine());
                var maSo = GiaiMa(reader.ReadLine());
                var hodem = GiaiMa(reader.ReadLine());
                var ten = GiaiMa(reader.ReadLine());
                var tenBM = GiaiMa(reader.ReadLine());

                danhSachGV[i] = new GiaoVien(hodem, ten, maSo, tenBM);
            }

            reader.Close();
            fs.Close();
        }

        public void Write(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine(MaHoa(tongSo.ToString()));

            for (int i = 0; i < tongSo; i++)
            {
                var gv = danhSachGV[i];
                writer.WriteLine(MaHoa(gv.ID));
                writer.WriteLine(MaHoa(gv.MaSo));
                writer.WriteLine(MaHoa(gv.HoDem));
                writer.WriteLine(MaHoa(gv.Ten));
                writer.WriteLine(MaHoa(gv.TenBoMon));
            }

            writer.Close();
            fs.Close();
        }

        public string MaHoa(string data)
        {
            string chuoiMaHoa = "";

            for (int i = 0; i < data.Length; i++)
            {
                int ascii = (int)data[i];
                ascii = ascii + 5;
                chuoiMaHoa += (char)ascii;
            }

            return  chuoiMaHoa;
        }

        public string GiaiMa(string data)
        {
            string chuoiGiaiMa = "";

            for (int i = 0; i < data.Length; i++)
            {
                int ascii = (int)data[i];
                ascii = ascii - 5;
                chuoiGiaiMa += (char)ascii;
            }

            return chuoiGiaiMa;
        }
    }
}
