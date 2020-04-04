namespace Lab02
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
  }
}
