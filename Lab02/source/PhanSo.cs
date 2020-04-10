using System;

namespace Lab02
{
  public class PhanSo
  {
    private int _tuSo;
    private int _mauSo;

    public int TuSo { get => _tuSo; }
    public int MauSo { get => _mauSo; }

    public PhanSo()
    {
      _tuSo = 0;
      _mauSo = 1;
    }

    public PhanSo(int tuSo)
    {
      this._tuSo = tuSo;
      this._mauSo = 1;
    }

    public PhanSo(int tuSo, int mauSo)
    {
      if (mauSo == 0)
        throw new ArgumentException("Mau so khong the bang 0.", nameof(mauSo));

      this._tuSo = tuSo;
      this._mauSo = mauSo;
    }

    public PhanSo(PhanSo ps)
    {
      this._tuSo = ps.TuSo;
      this._mauSo = ps.MauSo;
    }

    public void NhapTuBanPhim()
    {
      _tuSo = TienIch.NhapSoNguyen("Nhap vao tu so: ");

      do
      {
        _mauSo = TienIch.NhapSoNguyen("Nhap vo mau so: ");
        if (_mauSo == 0)
          Console.WriteLine("Mau so khong the bang 0!");
      } while (_mauSo == 0);
    }

    public static PhanSo RutGonPhanSo(PhanSo ps)
    {
      int ucln = TienIch.Tim_USCLN(ps.TuSo, ps.MauSo);
      var tuSoRutGon = ps.TuSo / ucln;
      var mauSoRutGon = ps.MauSo / ucln;

      if (tuSoRutGon < 0 && mauSoRutGon < 0)
      {
        tuSoRutGon = Math.Abs(tuSoRutGon);
        mauSoRutGon = Math.Abs(mauSoRutGon);
      }

      return new PhanSo(tuSoRutGon, mauSoRutGon);
    }

    public static PhanSo operator +(PhanSo ps1) => ps1;
    public static PhanSo operator -(PhanSo ps1) => new PhanSo(-ps1.TuSo, ps1.MauSo);

    public static PhanSo operator +(PhanSo ps1, PhanSo ps2)
    {
      PhanSo tong = new PhanSo(ps1.TuSo * ps2.MauSo + ps2.TuSo * ps1.MauSo, ps1.MauSo * ps2.MauSo);

      return PhanSo.RutGonPhanSo(tong);
    }

    public static PhanSo operator -(PhanSo ps1, PhanSo ps2)
      => PhanSo.RutGonPhanSo(ps1 + (-ps2));

    public static PhanSo operator *(PhanSo ps1, PhanSo ps2)
      => PhanSo.RutGonPhanSo(new PhanSo(ps1.TuSo * ps2.TuSo, ps1.MauSo * ps2.MauSo));

    public static PhanSo operator /(PhanSo ps1, PhanSo ps2)
    {
      if (ps2.TuSo == 0)
        throw new DivideByZeroException();

      return PhanSo.RutGonPhanSo(new PhanSo(ps1.TuSo * ps2.MauSo, ps1.MauSo * ps2.TuSo));
    }

    public static PhanSo operator ++(PhanSo ps1)
      => PhanSo.RutGonPhanSo(ps1 + ps1);

    public static bool operator ==(PhanSo ps1, PhanSo ps2)
    {
      var ps1_toiGian = PhanSo.RutGonPhanSo(ps1);
      var ps2_toiGian = PhanSo.RutGonPhanSo(ps2);

      if (ps1_toiGian.TuSo == ps2_toiGian.TuSo && ps1_toiGian.MauSo == ps2_toiGian.MauSo)
        return true;
      return false;
    }

    public static bool operator !=(PhanSo ps1, PhanSo ps2)
      => !(ps1 == ps2);

    public override string ToString()
    {
      if (TuSo == 0) return "0";
      if (MauSo == 1) return TuSo.ToString();
      return $"({this.TuSo}/{this.MauSo})";
    }

    public override bool Equals(object obj)
    {
      return obj is PhanSo so
        && _tuSo == so._tuSo
        && _mauSo == so._mauSo
        && TuSo == so.TuSo
        && MauSo == so.MauSo;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(_tuSo, _mauSo, TuSo, MauSo);
    }
  }
}
