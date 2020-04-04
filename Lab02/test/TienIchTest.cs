using System;
using Xunit;
using Lab02;

namespace Lab02_Test
{
  public class TienIchTest
  {
    [Fact]
    public void TinhLuyThua_ValidArgs_TraVeLuyThua()
    {
      // Arrange
      long expected = 32; // 2^5 = 32

      // Act
      long actual = TienIch.TinhLuyThua(2, 5);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TimUCLN_TonTaiUCLN_TraVeUCLN()
    {
      //Given
      int tuSo = 15;
      int mauSo = 20;

      int expected = 5; // UCLN cua 15 va 20 la 5

      //When
      int actual = TienIch.Tim_USCLN(tuSo, mauSo);

      //Then
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TimUCLN_KhongTonTaiUCLN_TraVe1()
    {
      //Given
      int tuSo = 9;
      int mauSo = 17;

      int expected = 1; // UCLN cua 9 va 17 la 1

      //When
      int actual = TienIch.Tim_USCLN(tuSo, mauSo);

      //Then
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TimBCNN_2SoKhongChiaHet_TraVeBCNN()
    {
      //Given
      int tuSo = 3;
      int mauSo = 5;

      int expected = 15;

      //When
      int actual = TienIch.Tim_BCNN(tuSo, mauSo);

      //Then
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TimBCNN_2SoChiaHet_TraVeSoLonHon()
    {
      //Given
      int tuSo = 3;
      int mauSo = 9;

      int expected = 9;

      //When
      int actual = TienIch.Tim_BCNN(tuSo, mauSo);

      //Then
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void HoanVi_TraVe2PhanTuDaHoanVi()
    {
      //Given
      int a = 3;
      int b = 4;

      int expected_a = 4;
      int expected_b = 3;

      //When
      TienIch.HoanVi(ref a, ref b);

      //Then
      Assert.Equal(expected_a, a);
      Assert.Equal(expected_b, b);
    }
  }
}
