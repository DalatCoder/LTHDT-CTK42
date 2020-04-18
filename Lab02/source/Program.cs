using System;

namespace Lab02
{
  class Program
  {
    static void Main(string[] args)
    {
      TestPhanSo();

      return;
    }

    public static void TestPhanSo()
    {
      var ps1 = new PhanSo();
      var ps2 = new PhanSo();

      Console.WriteLine("Nhap vao phan so thu nhat");
      ps1.NhapTuBanPhim();
      Console.WriteLine("Nhap vao phan so thu hai");
      ps2.NhapTuBanPhim();

      Console.WriteLine($"Phan so dau tien: {ps1}");
      Console.WriteLine($"Phan so thu hai:  {ps2}");

      Console.WriteLine($"{ps1} + {ps2} = {ps1 + ps2}");
    }
  }
}
