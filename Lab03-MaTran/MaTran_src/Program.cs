using System;

namespace MaTran_src
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Console.WriteLine("\nTao ma tran dau tien ngau nhien");
        var maTran_1 = MaTran.TaoMaTranNgauNhien();
        Console.WriteLine("Thong tin ma tran dau tien");
        maTran_1.Show();

        Console.WriteLine("\nTao ma tran thu hai ngau nhien");
        var maTran_2 = MaTran.TaoMaTranNgauNhien();
        Console.WriteLine("Thong tin ma tran thu hai");
        maTran_2.Show();

        Console.WriteLine("\nMa tran 1 + Ma tran 2");
        var tong = maTran_1 + maTran_2;
        tong.Show();

        Console.WriteLine("\nMa tran 1 - Ma tran 2");
        var hieu = maTran_1 - maTran_2;
        hieu.Show();

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
