using System;
using Xunit;
using Lab02;

namespace Lab02_Test
{
  public class PhanSoTest
  {
    [Fact]
    public void Cong2PhanSo_DeuLaPhanSoDuong_TraVeTong()
    {
      //Given
      var ps1 = new PhanSo(1, 4);
      var ps2 = new PhanSo(2, 4);
      var expected = new PhanSo(3, 4);

      //When
      var actual = ps1 + ps2;

      //Then
      Assert.Equal(expected.TuSo, actual.TuSo);
      Assert.Equal(expected.MauSo, actual.MauSo);
    }

    [Fact]
    public void Cong2PhanSo_1Am_1Duong_TraVeTong()
    {
      //Given
      var ps1 = new PhanSo(1, 4);
      var ps2 = new PhanSo(-2, 4);
      var expected = new PhanSo(-1, 4);

      //When
      var actual = ps1 + ps2;

      //Then
      Assert.Equal(expected.TuSo, actual.TuSo);
      Assert.Equal(expected.MauSo, actual.MauSo);
      Assert.Equal(expected.Dau, actual.Dau);
    }

    [Fact]
    public void Cong2PhanSo_2PhanSoAm_TraVeTong()
    {
      //Given
      var ps1 = new PhanSo(-1, 4);
      var ps2 = new PhanSo(-2, 4);
      var expected = new PhanSo(-3, 4);

      //When
      var actual = ps1 + ps2;

      //Then
      Assert.Equal(expected.TuSo, actual.TuSo);
      Assert.Equal(expected.MauSo, actual.MauSo);
      Assert.Equal(expected.Dau, actual.Dau);
    }
  }
}
