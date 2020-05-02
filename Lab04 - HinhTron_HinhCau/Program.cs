using System;

namespace Lab04___HinhTron_HinhCau
{
    public class HinhTron
    {
        protected int banKinh;
        public HinhTron(int banKinh)
        {
            this.banKinh = banKinh;
        }

        public double DienTich()
        {
            return Math.PI * Math.Pow(banKinh, 2);
        }
    }


    public class HinhCau : HinhTron
    {
        public HinhCau(int banKinh) : base(banKinh) { }
        public new double DienTich()
        {
            return 4 * Math.PI * Math.Pow(banKinh, 2);
        }
        public double TheTich()
        {
            return (4 / 3) * Math.PI * Math.Pow(banKinh, 3);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HinhTron tron = new HinhTron(4);
            Console.WriteLine("Dien tich hinh tron voi ban kinh 4 = {0}", tron.DienTich());

            HinhCau cau = new HinhCau(4);
            Console.WriteLine("Dien tich hinh cau voi ban kinh 4 = {0}", cau.DienTich());
            Console.WriteLine("The tich hinh cau voi ban kinh 4 = {0}", cau.TheTich());

            Console.ReadLine();
        }
    }
}
