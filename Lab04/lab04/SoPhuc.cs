using System.Text;

namespace lab04
{
  public class SoPhuc
  {
    private readonly int _thuc;
    private readonly int _ao;

    public int PhanThuc { get => _thuc; }
    public int PhanAo { get => _ao; }

    public SoPhuc() { }
    public SoPhuc(int thuc, int ao)
    {
      this._thuc = thuc;
      this._ao = ao;
    }

    public bool LaSoThuanAo { get => this._thuc == 0; }
    public bool LaSoThuc { get => this._ao == 0; }

    public static SoPhuc TaoSoPhucTuBanPhim()
    {
      int thuc = TienIch.NhapSoNguyen("Nhap gia tri phan thuc: ");
      int ao = TienIch.NhapSoNguyen("Nhap gia tri phan ao: ");
      return new SoPhuc(thuc, ao);
    }

    public static SoPhuc operator +(SoPhuc sp1, SoPhuc sp2)
      => new SoPhuc(sp1._thuc + sp2._thuc, sp1._ao + sp2._ao);

    public static SoPhuc operator -(SoPhuc sp1, SoPhuc sp2)
      => new SoPhuc(sp1._thuc - sp2._thuc, sp1._ao - sp2._ao);

    public static SoPhuc operator *(SoPhuc sp1, SoPhuc sp2)
      => new SoPhuc(sp1._thuc * sp2._thuc - sp1._ao * sp2._ao, sp1._thuc * sp2._ao + sp1._ao * sp2._thuc);

    public static SoPhuc operator /(SoPhuc sp1, SoPhuc sp2)
    {
      // (a + bi) / (c + di) = ((a + bi) * (c – di)) / (c2 + d2)
      SoPhuc TuSo = sp1 * new SoPhuc(sp2._thuc, -sp2._ao);
      int mauSo = sp2._thuc * 2 + sp2._ao * 2;

      return new SoPhuc(TuSo._thuc / mauSo, TuSo._ao / mauSo);
    }

    public static bool operator ==(SoPhuc sp1, SoPhuc sp2)
      => (sp1._thuc == sp2._thuc) && (sp1._ao == sp2._ao);

    public static bool operator !=(SoPhuc sp1, SoPhuc sp2)
      => !(sp1 == sp2);

    public override string ToString()
    {
      var str = new StringBuilder("");

      if (_thuc != 0)
        str = str.Append($"{_thuc}");

      if (_ao != 0)
        str = (_ao < 0) ? str.Append($" - {-(_ao)}i") : str.Append($" + {_ao}i");

      if (str.Length == 0) return "0";
      return "(" + str.ToString() + ")";
    }
  }
}
