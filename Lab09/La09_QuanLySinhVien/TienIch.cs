using System;

namespace Lab09
{
  public static class TienIch
  {
    public static long TinhLuyThua(int coso, int somu)
    {
      long kq = 1;

      for (int i = 0; i < somu; i += 1)
        kq *= coso;

      return kq;
    }

    public static int Tim_USCLN(int a, int b)
    {
      if (a == 0 || b == 0) return 1;

      // UCLN luon la so duong
      a = a < 0 ? Math.Abs(a) : a;
      b = b < 0 ? Math.Abs(b) : b;

      while (a != b)
      {
        if (a > b) a = a - b;
        else b = b - a;
      }

      return a;
    }

    public static int Tim_BCNN(int a, int b)
    {
      return (a * b) / Tim_USCLN(a, b);
    }

    public static void HoanVi(ref int a, ref int b)
    {
      int t = a;
      a = b;
      b = t;
    }

    public static int NhapSoNguyen(string msg)
    {
      int kq;
      /*
      while (true)
      {
        Console.Write(msg);
        bool isValid = int.TryParse(Console.ReadLine(), out kq);
        if (isValid) break;
      }
      */

      bool isValid = true;
      do
      {
        Console.Write(msg);
        isValid = int.TryParse(Console.ReadLine(), out kq);
      } while (!isValid);

      return kq;
    }

    public static double NhapSoThuc(string msg)
    {
      double kq;

      while (true)
      {
        Console.Write(msg);
        bool isValid = double.TryParse(Console.ReadLine(), out kq);
        if (isValid) break;
      }

      return kq;
    }
  }
}
