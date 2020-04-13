using System;

namespace Lab03
{
  class Program
  {
    static void Main(string[] args)
    {
      var tamThuc_1 = new TamThuc();
      tamThuc_1.NhapTamThucTuBanPhim();
      Console.WriteLine($"Tam thuc dau tien: {tamThuc_1}");

      var tamThuc_2 = new TamThuc();
      tamThuc_2.NhapTamThucTuBanPhim();
      Console.WriteLine($"Tam thuc thu hai: {tamThuc_2}");
    }
  }
}
