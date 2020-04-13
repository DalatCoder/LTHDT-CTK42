using System;
using System.Text;

namespace Lab03
{
  public class TamThuc
  {
    private int a;
    private int b;
    private int c;

    public int A { get => a; }
    public int B { get => b; }
    public int C { get => c; }

    public TamThuc() { }
    public TamThuc(int a, int b, int c)
    {
      this.a = a;
      this.b = b;
      this.c = c;
    }
    public TamThuc(TamThuc tamthuc)
    {
      this.a = tamthuc.a;
      this.b = tamthuc.b;
      this.c = tamthuc.c;
    }

    public void NhapTamThucTuBanPhim()
    {
      this.a = TienIch.NhapSoNguyen("Nhap he so a (x^2) >> ");
      this.b = TienIch.NhapSoNguyen("Nhap he so b (x)   >> ");
      this.c = TienIch.NhapSoNguyen("Nhap he so c       >> ");
    }

    public static TamThuc operator +(TamThuc tt1, TamThuc tt2)
      => new TamThuc(tt1.a + tt2.a, tt1.b + tt2.b, tt1.c + tt2.c);

    public static TamThuc operator -(TamThuc tt1, TamThuc tt2)
      => new TamThuc(tt1.a - tt2.a, tt1.b - tt2.b, tt1.c - tt2.c);

    public static TamThuc operator *(TamThuc tt1, int num)
      => new TamThuc(tt1.a * num, tt1.b * num, tt1.c * num);
    public static TamThuc operator *(int num, TamThuc tt1)
      => new TamThuc(num * tt1.a, num * tt1.b, num * tt1.c);

    public static TamThuc operator ++(TamThuc tt1)
    {
      tt1.c += 1;
      return tt1;
    }

    public static bool operator ==(TamThuc tt1, TamThuc tt2)
    {
      var tt1_rutGon = TamThuc.RutGonTamThuc(tt1);
      var tt2_rutGon = TamThuc.RutGonTamThuc(tt2);

      return
        tt1_rutGon.a == tt2_rutGon.a &&
        tt1_rutGon.b == tt2_rutGon.b &&
        tt1_rutGon.c == tt2_rutGon.c;
    }

    public static bool operator !=(TamThuc tt1, TamThuc tt2)
      => !(tt1 == tt2);



    public static explicit operator bool(TamThuc tamThuc)
      => (Math.Pow(tamThuc.b, 2) - (4 * tamThuc.a * tamThuc.c)) >= 0;

    public static implicit operator TamThuc(int num)
    {
      if (num < 0)
        throw new ArgumentException("So nguyen phai lon hon 0 de tien hanh ep kieu!", nameof(num));
      if (num < 100 || num > 999)
        throw new ArgumentException("So nguyen phai co 3 chu so!", nameof(num));

      int c = num % 10;
      num /= 10;
      int b = num % 10;
      num /= 10;
      int a = num % 10;

      return new TamThuc(a, b, c);
    }

    public static TamThuc RutGonTamThuc(TamThuc tamthuc)
    {
      var ucln = TienIch.Tim_USCLN(TienIch.Tim_USCLN(tamthuc.a, tamthuc.b), tamthuc.c);
      return new TamThuc(tamthuc.a / ucln, tamthuc.b / ucln, tamthuc.c / ucln);
    }

    public override string ToString()
    {
      var str = new StringBuilder("");
      if (a != 0)
        str = str.Append($"{a}x^2");
      if (b != 0)
        str = b < 0 ? str.Append($" - {-b}x") : str.Append($" + {b}x");
      if (c != 0)
        str = c < 0 ? str.Append($" - {-c}") : str.Append($" + {c}");

      if (str.Length == 0) return "0";
      return str.ToString();
    }
  }
}
