using System;
using System.Text;

namespace Lab02
{
  public class PhanSo
  {
    private uint _tuSo;
    private uint _mauSo;

    // Dấu = true => Phân số dương
    // Dấu = false => Phân số âm
    private bool _dau;

    public uint TuSo { get => _tuSo; }
    public uint MauSo { get => _mauSo; }
    public string Dau { get => _dau == true ? "" : "-"; }

    public PhanSo() : this(0, 1) { }

    public PhanSo(int tuSo) : this(tuSo, 1) { }

    public PhanSo(int tuSo, int mauSo)
    {
      if (mauSo == 0)
        throw new ArgumentException("Mau so khong the bang 0.", nameof(mauSo));

      _dau = true;

      // Xác định dấu của phân số
      if (tuSo < 0)
      {
        if (mauSo < 0) _dau = true; // dấu dương
        else _dau = false; // dấu âm}
      }
      else
      {
        if (mauSo < 0) _dau = false;
        else _dau = true;
      }

      tuSo = Math.Abs(tuSo);
      mauSo = Math.Abs(mauSo);

      this._tuSo = (uint)tuSo;
      this._mauSo = (uint)mauSo;
    }

    public PhanSo(PhanSo ps)
    {
      this._tuSo = ps.TuSo;
      this._mauSo = ps.MauSo;
      this._dau = ps._dau;
    }

    public void NhapTuBanPhim()
    {
      int tuSo, mauSo;

      tuSo = TienIch.NhapSoNguyen("Nhap vao tu so: ");

      do
      {
        mauSo = TienIch.NhapSoNguyen("Nhap vo mau so: ");
        if (mauSo == 0)
          Console.WriteLine("Mau so khong the bang 0!");
      } while (mauSo == 0);

      var phanSo = new PhanSo(tuSo, mauSo);

      this._tuSo = phanSo.TuSo;
      this._mauSo = phanSo.MauSo;
      this._dau = phanSo._dau;
    }

    public static PhanSo operator +(PhanSo ps1, PhanSo ps2)
    {
      // Gắn dấu tương ứng vào để tính toán
      int ts_1 = (int)(ps1._dau ? ps1.TuSo : ps1.TuSo * -1);
      int ms_1 = (int)ps1.MauSo;

      int ts_2 = (int)(ps2._dau ? ps2.TuSo : ps2.TuSo * -1);
      int ms_2 = (int)ps2.MauSo;

      int tuSo = ts_1 * ms_2 + ts_2 * ms_1;
      int mauSo = ms_1 * ms_2;

      return PhanSo.RutGonPhanSo(new PhanSo(tuSo, mauSo));
    }

    public static PhanSo RutGonPhanSo(PhanSo ps)
    {
      int ucln = TienIch.Tim_USCLN((int)ps.TuSo, (int)ps.MauSo);
      if (ps.Dau == "-")
        return new PhanSo((int)(-ps.TuSo / ucln), (int)(ps.MauSo / ucln));

      return new PhanSo((int)(ps.TuSo / ucln), (int)(ps.MauSo / ucln));
    }

    public override string ToString()
    {
      if (TuSo == 0) return "0";

      if (MauSo == 1) return $"{this.Dau}{this.TuSo}";
      return $"({this.Dau}{this.TuSo}/{this.MauSo})";
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
