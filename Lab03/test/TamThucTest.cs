using System;
using Xunit;
using Lab03;

namespace test
{
  public class TamThucTest
  {
    [Fact]
    public void RutGonTamThuc_TonTaiUCLN_TraVeTamThucRutGon()
    {
      //Given
      var tamThuc = new TamThuc(3, 6, 15);
      var expected = new TamThuc(1, 2, 5);

      //When
      var actual = TamThuc.RutGonTamThuc(tamThuc);

      //Then
      Assert.True(expected == actual);
    }

    [Fact]
    public void RutGonTamThuc_KhongTonTaiUCLN_TraVeTamThucRutGon()
    {
      //Given
      var tamThuc = new TamThuc(3, 7, 15);
      var expected = new TamThuc(3, 7, 15);

      //When
      var actual = TamThuc.RutGonTamThuc(tamThuc);

      //Then
      Assert.True(expected == actual);
    }

    [Fact]
    public void Cong_2TamThuc_TraVeTamThucTong()
    {
      //Given
      var tt1 = new TamThuc(1, 2, 3);
      var tt2 = new TamThuc(-1, 3, 4);

      var expected = new TamThuc(0, 5, 7);

      //When
      var actual = tt1 + tt2;

      //Then
      Assert.True(expected == actual);
    }

    [Fact]
    public void Cong_2TamThuc_TraVeTamThucHieu()
    {
      //Given
      var tt1 = new TamThuc(1, 2, 3);
      var tt2 = new TamThuc(-1, 3, 4);

      var expected = new TamThuc(2, -1, -1);

      //When
      var actual = tt1 - tt2;

      //Then
      Assert.True(expected == actual);
    }

    [Fact]
    public void Nhan_1TamThucVoi1So_TraVeTamThucTich()
    {
      //Given
      var tt1 = new TamThuc(1, 2, 3);
      var k = 3;

      var expected = new TamThuc(3, 6, 9);

      //When
      var actual = tt1 * k;

      //Then
      Assert.True(expected == actual);
    }

    [Fact]
    public void ToanTuCongThem1_TraVePhuongThucDaCong()
    {
      //Given
      var tamThuc = new TamThuc(1, 2, 3);
      var expected = new TamThuc(1, 2, 4);

      //When
      ++tamThuc;

      //Then
      Assert.True(expected == tamThuc);
    }

    [Fact]
    public void EpKieuTuongMinh_TamThucCoNghiem_TraVeTrue()
    {
      //Given
      var tamThuc = new TamThuc(1, -9, 14);

      //When

      //Then
      Assert.True((bool)tamThuc);
    }

    [Fact]
    public void EpKieuTuongMinh_TamThucKhongCoNghiem_TraVeTrue()
    {
      //Given
      var tamThuc = new TamThuc(1, 2, 3);

      //When

      //Then
      Assert.False((bool)tamThuc);
    }
    [Fact]
    public void EpKieuNgamDinh_ValidNumber_TraVeTamThuc()
    {
      //Given
      var number = 123;
      var expected = new TamThuc(1, 2, 3);

      //When
      TamThuc actual = number;

      //Then
      Assert.True(expected == actual);
    }
  }
}
