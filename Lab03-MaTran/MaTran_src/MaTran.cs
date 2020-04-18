using System;

namespace MaTran_src
{
  public class MaTran
  {
    private readonly int _hang;
    private readonly int _cot;
    private readonly double[,] table;

    public MaTran() : this(0, 0) { }
    public MaTran(int soCap) : this(soCap, soCap) { }
    public MaTran(int hang, int cot)
    {
      _hang = hang;
      _cot = cot;
      table = new double[_hang, _cot];
    }
    protected MaTran(int hang, int cot, double[,] table)
    {
      _hang = hang;
      _cot = cot;
      this.table = table;
    }

    public int SoHang { get => _hang; }
    public int SoCot { get => _cot; }

    public void Show()
    {
      for (int i = 0; i < _hang; i++)
      {
        for (int j = 0; j < _cot; j++)
          Console.Write("{0,7:N1}", table[i, j]);
        Console.WriteLine();
      }
    }

    public static MaTran TaoMaTranTuBanPhim()
    {
      int hang = TienIch.NhapSoNguyen("Nhap so hang cua ma tran: ");
      int cot = TienIch.NhapSoNguyen("Nhap so cot cua ma tran: ");
      double[,] table = new double[hang, cot];

      for (int i = 0; i < hang; i++)
        for (int j = 0; j < cot; j++)
          table[i, j] = TienIch.NhapSoThuc($"Nhap phan tu [{i}][{j}]: ");

      return new MaTran(hang, cot, table);
    }

    public static MaTran TaoMaTranNgauNhien()
    {
      int hang = TienIch.NhapSoNguyen("Nhap so hang cua ma tran: ");
      int cot = TienIch.NhapSoNguyen("Nhap so cot cua ma tran: ");
      int number = TienIch.NhapSoNguyen("Nhap vao vung random: ");

      double[,] table = new double[hang, cot];

      var random = new Random();

      for (int i = 0; i < hang; i++)
        for (int j = 0; j < cot; j++)
          table[i, j] = random.NextDouble() * number;

      return new MaTran(hang, cot, table);
    }

    public static MaTran ChuyenViMaTran(MaTran maTran)
    {
      int hang = maTran._cot;
      int cot = maTran._hang;
      double[,] table = new double[hang, cot];

      for (int i = 0; i < maTran._hang; i++)
        for (int j = 0; j < maTran._cot; j++)
          table[j, i] = maTran.table[i, j];

      return new MaTran(hang, cot, table);
    }

    public static bool La2MaTranCungCap(MaTran mt1, MaTran mt2)
      => (mt1._hang == mt2._hang && mt1._cot == mt2._cot);

    public static MaTran operator +(MaTran mt1, MaTran mt2)
    {
      if (!MaTran.La2MaTranCungCap(mt1, mt2))
        throw new InvalidOperationException("Hai ma tran khong cung cap!");

      int hang = mt1._hang;
      int cot = mt1._cot;
      double[,] table = new double[hang, cot];

      for (int i = 0; i < hang; i++)
        for (int j = 0; j < cot; j++)
          table[i, j] = mt1.table[i, j] + mt2.table[i, j];

      return new MaTran(hang, cot, table);
    }

    public static MaTran operator -(MaTran mt1, MaTran mt2)
    {
      if (!MaTran.La2MaTranCungCap(mt1, mt2))
        throw new InvalidOperationException("Hai ma tran khong cung cap!");

      int hang = mt1._hang;
      int cot = mt1._cot;
      double[,] table = new double[hang, cot];

      for (int i = 0; i < hang; i++)
        for (int j = 0; j < cot; j++)
          table[i, j] = mt1.table[i, j] - mt2.table[i, j];

      return new MaTran(hang, cot, table);
    }
  }
}
