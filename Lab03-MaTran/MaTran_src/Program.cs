using System;

namespace MaTran_src
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Console.WriteLine("Nhap thong tin ma tran dau tien: ");
        var maTran_1 = MaTran.TaoMaTranTuBanPhim();
        Console.WriteLine("Nhap thong tin ma tran thu hai: ");
        var maTran_2 = MaTran.TaoMaTranTuBanPhim();

        Console.WriteLine("\nMa tran dau tien:");
        maTran_1.Show();
        Console.WriteLine("\nMa tran thu hai:");
        maTran_2.Show();

        Console.WriteLine("\nMa tran 1 == Ma tran 2 ? {0}", maTran_1 == maTran_2);
        Console.WriteLine("Ma tran 1 != Ma tran 2 ? {0}", maTran_1 != maTran_2);

        Console.WriteLine("\nNhap thong tin ma tran vuong:");
        var maTranVuong = MaTran.TaoMaTranTuBanPhim();
        Console.WriteLine("Ma tran vua nhap:");
        maTranVuong.Show();

        Console.WriteLine("Tong duong cheo chinh cua ma tran: {0}", maTranVuong.TinhTongDuongCheoChinh());
        if (maTranVuong.LaMaTranDoiXung())
          Console.WriteLine("Ma tran vua nhap vao doi xung!");
        else
          Console.WriteLine("Ma tran vua nhap vao khong doi xung!");
      }
      catch (InvalidOperationException ex)
      {
        Console.WriteLine("Co loi xay ra! {0}", ex.Message);
      }
      finally
      {
        Console.ReadLine();
      }
    }

    private static void TestCacPhuongThucTrenMaTran()
    {
      try
      {
        Console.WriteLine("\nTao ma tran dau tien ngau nhien");
        var maTran_1 = MaTran.TaoMaTranTuBanPhim();
        Console.WriteLine("Thong tin ma tran dau tien");
        maTran_1.Show();

        Console.WriteLine("\nTao ma tran thu hai ngau nhien");
        var maTran_2 = MaTran.TaoMaTranTuBanPhim();
        Console.WriteLine("Thong tin ma tran thu hai");
        maTran_2.Show();

        // Console.WriteLine("\nMa tran 1 + Ma tran 2");
        // var tong = maTran_1 + maTran_2;
        // tong.Show();

        // Console.WriteLine("\nMa tran 1 - Ma tran 2");
        // var hieu = maTran_1 - maTran_2;
        // hieu.Show();

        Console.WriteLine("\nMa tran 1 * Ma tran 2");
        var tich = maTran_1 * maTran_2;
        tich.Show();

        Console.WriteLine("\nMa tran 1 chuyen vi");
        var maTran_1_chuyenVi = MaTran.ChuyenViMaTran(maTran_1);
        maTran_1_chuyenVi.Show();
      }
      catch (InvalidOperationException ex)
      {
        Console.WriteLine($"Co loi xay ra! {ex.Message}");
      }
      finally
      {
        Console.ReadLine();
      }
    }
  }
}
