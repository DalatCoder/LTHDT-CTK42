using System;

namespace Lab06_Bai02
{
    public class TienIch
    {
        public static int NhapMotSoTuBanPhim(string thongBaoChoNguoiDung)
        {
            int so;

            do
            {
                Console.Write(thongBaoChoNguoiDung);
                bool valid = int.TryParse(Console.ReadLine(), out so);
                if (valid) break;
            } while (true);

            return so;
        }
    }
    
    public class DaThuc
    {
        private int n; // bac da thuc
        private int[] array; // luu tru cac he so cua da thuc

        public DaThuc(int bacDaThuc)
        {
            n = bacDaThuc;
            array = new int[n+1];
        }

       public void NhapDaThuc()
        {
            n = TienIch.NhapMotSoTuBanPhim("Nhap bac cua da thuc: ");
            for (int i = n; i >= 0; i--)
            {
                array[i] = TienIch.NhapMotSoTuBanPhim($"Nhap he so x^{i}: ");
            }
        }
        
        public void XuatDaThuc()
        {
            for (int i = n; i> 0; i--)
            {
                Console.Write("{0}x^{1} + ", array[i], i);
            }
            Console.WriteLine(array[0]);
            
        }

        public DaThuc Cong(DaThuc dt2)
        {
            int bacCaoHon = this.n > dt2.n ? this.n : dt2.n;
            int bacThapHon = this.n < dt2.n ? this.n : dt2.n;

            DaThuc dt_tong = new DaThuc(bacCaoHon);

            for (int i = 0; i <= bacThapHon; i++)
                dt_tong.array[i] = this.array[i] + dt2.array[i];

            if (this.n == bacThapHon)
            {
                for (int i = bacThapHon + 1; i <= dt2.n; i++)
                    dt_tong.array[i] = dt2.array[i];
            }
            else
            {
                for (int i = bacThapHon + 1; i <= this.n; i++)
                    dt_tong.array[i] = this.array[i];
            }

            return dt_tong;
        }

        public DaThuc Tru(DaThuc dt2)
        {
            int bacCaoHon = this.n > dt2.n ? this.n : dt2.n;
            int bacThapHon = this.n < dt2.n ? this.n : dt2.n;

            DaThuc dt_tong = new DaThuc(bacCaoHon);

            for (int i = 0; i <= bacThapHon; i++)
                dt_tong.array[i] = this.array[i] - dt2.array[i];

            if (this.n == bacThapHon)
            {
                for (int i = bacThapHon + 1; i <= dt2.n; i++)
                    dt_tong.array[i] = dt2.array[i];
            }
            else
            {
                for (int i = bacThapHon + 1; i <= this.n; i++)
                    dt_tong.array[i] = this.array[i];
            }

            return dt_tong;
        }

        public static DaThuc operator +(DaThuc dt1, DaThuc dt2)
        {
            int bacCaoHon = dt1.n > dt2.n ? dt1.n : dt2.n;
            int bacThapHon = dt1.n < dt2.n ? dt1.n : dt2.n;

            DaThuc dt_tong = new DaThuc(bacCaoHon);

            for (int i = 0; i <= bacThapHon; i++)
                dt_tong.array[i] = dt1.array[i] + dt2.array[i];

            if (dt1.n == bacThapHon)
            {
                for (int i = bacThapHon + 1; i <= dt2.n; i++)
                    dt_tong.array[i] = dt2.array[i];
            }
            else
            {
                for (int i = bacThapHon + 1; i <= dt1.n; i++)
                    dt_tong.array[i] = dt1.array[i];
            }

            return dt_tong;

        }

        public static DaThuc operator -(DaThuc dt1, DaThuc dt2)
        {
            int bacCaoHon = dt1.n > dt2.n ? dt1.n : dt2.n;
            int bacThapHon = dt1.n < dt2.n ? dt1.n : dt2.n;

            DaThuc dt_tong = new DaThuc(bacCaoHon);

            for (int i = 0; i <= bacThapHon; i++)
                dt_tong.array[i] = dt1.array[i] - dt2.array[i];

            if (dt1.n == bacThapHon)
            {
                for (int i = bacThapHon + 1; i <= dt2.n; i++)
                    dt_tong.array[i] = dt2.array[i];
            }
            else
            {
                for (int i = bacThapHon + 1; i <= dt1.n; i++)
                    dt_tong.array[i] = dt1.array[i];
            }

            return dt_tong;

        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var dathuc_1 = new DaThuc(3);
            dathuc_1.NhapDaThuc();
            dathuc_1.XuatDaThuc();

            var dathuc_2 = new DaThuc(3);
            dathuc_2.NhapDaThuc();
            dathuc_2.XuatDaThuc();

            Console.WriteLine();

            Console.WriteLine("Da thuc 1 + Da thuc 2 = ");
            var dathuc_tong = dathuc_1 + dathuc_2;
            dathuc_tong.XuatDaThuc();
            var tong_2 = dathuc_1.Cong(dathuc_2);
            tong_2.XuatDaThuc();

            Console.WriteLine();
            Console.WriteLine("Da thuc 1 - Da thuc 2 = ");
            var dathuc_hieu = dathuc_1 - dathuc_2;
            dathuc_hieu.XuatDaThuc();
            var hieu_2 = dathuc_1.Tru(dathuc_2);
            hieu_2.XuatDaThuc();

            Console.ReadLine();
        }
    }
}
