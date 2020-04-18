using System;
using Xunit;
using lab04;

namespace lab04_test
{
  public class SoPhucTest
  {
    [Fact]
    public void PhepTinh_Cong2SoPhuc_TraVeTong()
    {
      // --Arrange
      var sp1 = new SoPhuc(1, 2);
      var sp2 = new SoPhuc(3, 4);

      var expected = new SoPhuc(4, 6);

      // --Act
      var actual = sp1 + sp2;

      // --Assert
      Assert.True(expected == actual);
    }

    [Fact]
    public void PhepTinh_Tru2SoPhuc_TraVeHieu()
    {
      // --Arrange
      var sp1 = new SoPhuc(1, 2);
      var sp2 = new SoPhuc(3, 4);

      var expected = new SoPhuc(-2, -2);

      // --Act
      var actual = sp1 - sp2;

      // --Assert
      Assert.True(expected == actual);
    }

    [Fact]
    public void PhepTinh_Nhan2SoPhuc_TraVeTich()
    {
      // --Arrange
      var sp1 = new SoPhuc(1, 2);
      var sp2 = new SoPhuc(3, 4);

      var expected = new SoPhuc(-5, 10);

      // --Act
      var actual = sp1 * sp2;

      // --Assert
      Assert.True(expected == actual);
    }

    [Fact]
    public void KiemTraSoPhuc_LaSoThuanAo_TraVeTrue()
    {
      // --Arrange
      var sp1 = new SoPhuc(0, 2);

      // --Assert
      Assert.True(sp1.LaSoThuanAo);
    }


    [Fact]
    public void KiemTraSoPhuc_KhongLaSoThuanAo_TraVeFalse()
    {
      // --Arrange
      var sp1 = new SoPhuc(1, 2);

      // --Assert
      Assert.False(sp1.LaSoThuanAo);
    }

    [Fact]
    public void KiemTraSoPhuc_LaSoThuc_TraVeTrue()
    {
      // --Arrange
      var sp1 = new SoPhuc(2, 0);

      // --Assert
      Assert.True(sp1.LaSoThuc);
    }

    [Fact]
    public void KiemTraSoPhuc_KhongLaSoThuc_TraVeFalse()
    {
      // --Arrange
      var sp1 = new SoPhuc(2, 1);

      // --Assert
      Assert.False(sp1.LaSoThuc);
    }

    [Fact]
    public void KiemTraSoPhuc_BangNhau_TraVeTrue()
    {
      //Given
      var sp1 = new SoPhuc(1, 2);
      var sp2 = new SoPhuc(1, 2);

      Assert.True(sp1 == sp2);
    }

    [Fact]
    public void KiemTraSoPhuc_KhongBangNhau_TraVeFalse()
    {
      //Given
      var sp1 = new SoPhuc(1, 2);
      var sp2 = new SoPhuc(3, 4);

      Assert.False(sp1 == sp2);
    }

    [Fact]
    public void KiemTraSoPhuc_KhacNhau_TraVeTrue()
    {
      //Given
      var sp1 = new SoPhuc(1, 2);
      var sp2 = new SoPhuc(3, 4);

      Assert.True(sp1 != sp2);
    }
  }
}
