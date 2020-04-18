using System;

namespace lab04
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Nhap so phuc dau tien:");
      var sp1 = SoPhuc.TaoSoPhucTuBanPhim();

      Console.WriteLine("Nhap so phuc thu hai:");
      var sp2 = SoPhuc.TaoSoPhucTuBanPhim();

      Console.WriteLine($"So phuc 1: {sp1}");
      Console.WriteLine($"So phuc 2: {sp2}");

      Console.WriteLine($"{sp1} + {sp2} == {sp1 + sp2}");
      Console.WriteLine($"{sp1} - {sp2} == {sp1 - sp2}");
      Console.WriteLine($"{sp1} * {sp2} == {sp1 * sp2}");
      Console.WriteLine($"{sp1} / {sp2} == {sp1 / sp2}");

      Console.WriteLine($"{sp1} == {sp2} ? {sp1 == sp2}");
      Console.WriteLine($"{sp1} != {sp2} ? {sp1 != sp2}");

      Console.ReadLine();
    }
  }
}
