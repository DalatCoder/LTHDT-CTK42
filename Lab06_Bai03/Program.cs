using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dathuc
{
    class Program
    {
        struct Sohang
        {
            public int Hs;
            public int Mu;
        };
        public class Dathuc
        {
            int Sopt;
            Sohang[] DT;

            public Dathuc()
            {
                Sopt = 0;
                DT = new Sohang[100];
            }
            public void ThemSohang(int Heso, int Somu)
            {
                DT[Sopt].Hs = Heso;
                DT[Sopt].Mu = Somu;
                Sopt++;
            }
            public void NhapDaThuc()
            {
                int Heso;
                int Somu;

                while (true)
                {
                    Console.WriteLine("Nhap vao he so va so mu , khi ket thuc nhap hs =0");
                    Console.Write("Nhap he so: ");
                    Heso = Int32.Parse(Console.ReadLine());
                    if (Heso == 0) break;

                    Console.Write("Nhap so mu: ");
                    Somu = Int32.Parse(Console.ReadLine());

                    ThemSohang(Heso, Somu);
                }
            }

            public void XuatDaThuc()
            {
                SapGiamDanTheoSoMu();
                RutGonDaThuc();

                Console.WriteLine("Da Thuc :");
                for (int i = 0; i < Sopt - 1; i++)
                    Console.Write("{0}X^{1} + ", DT[i].Hs, DT[i].Mu);
                Console.WriteLine("{0}X^{1}", DT[Sopt - 1].Hs, DT[Sopt - 1].Mu);

            }

            private void HoanVi(ref Sohang sh1, ref Sohang sh2)
            {
                Sohang sh3 = sh1;
                sh1 = sh2;
                sh2 = sh3;
            }
            private void SapGiamDanTheoSoMu()
            {
                for (int i = 0; i < Sopt - 1; i++)
                    for (int j = i + 1; j < Sopt; j++)
                        if (DT[i].Mu < DT[j].Mu)
                            HoanVi(ref DT[i], ref DT[j]);
            }
            
            private void RutGonDaThuc()
            {
                for (int i = 0; i < Sopt-1; i++)
                {
                    if (DT[i].Mu == DT[i+1].Mu)
                    {
                        DT[i].Hs += DT[i + 1].Hs;

                        for (int j = i + 1; j < Sopt - 1; j++)
                            DT[j] = DT[j + 1];

                        Sopt--;
                        i--;
                    }
                }
            }


            public static Dathuc operator +(Dathuc dt1, Dathuc dt2)
            {
                Dathuc dt_tong = new Dathuc();

                for (int i = 0; i < dt1.Sopt; i++)
                    dt_tong.ThemSohang(dt1.DT[i].Hs, dt1.DT[i].Mu);

                for (int i = 0; i < dt2.Sopt; i++)
                    dt_tong.ThemSohang(dt2.DT[i].Hs, dt2.DT[i].Mu);

                dt_tong.SapGiamDanTheoSoMu();
                dt_tong.RutGonDaThuc();

                return dt_tong;
            }

            public static Dathuc operator -(Dathuc dt1, Dathuc dt2)
            {
                Dathuc dt_tong = new Dathuc();

                for (int i = 0; i < dt1.Sopt; i++)
                    dt_tong.ThemSohang(dt1.DT[i].Hs, dt1.DT[i].Mu);

                for (int i = 0; i < dt2.Sopt; i++)
                    dt_tong.ThemSohang(dt2.DT[i].Hs, dt2.DT[i].Mu);

                dt_tong.SapGiamDanTheoSoMu();

                for (int i = 0; i < dt_tong.Sopt - 1; i++)
                {
                    if (dt_tong.DT[i].Mu == dt_tong.DT[i + 1].Mu)
                    {
                        dt_tong.DT[i].Hs -= dt_tong.DT[i + 1].Hs;

                        for (int j = i + 1; j < dt_tong.Sopt - 1; j++)
                            dt_tong.DT[j] = dt_tong.DT[j + 1];

                        dt_tong.Sopt--;
                        i--;
                    }
                }

                return dt_tong;
            }

        }

        static void Main(string[] args)
        {
            Dathuc T1 = new Dathuc();

            T1.NhapDaThuc();
            T1.XuatDaThuc();

            Dathuc T2 = new Dathuc();
            T2.NhapDaThuc();
            T2.XuatDaThuc();

            Console.WriteLine("T1 + T2 = ");
            Dathuc Tong = T1 + T2;
            Tong.XuatDaThuc();

            Console.WriteLine("T1 - T2 = ");
            Dathuc Hieu = T1 - T2;
            Hieu.XuatDaThuc();

            Console.ReadLine();
        }
    }
}



