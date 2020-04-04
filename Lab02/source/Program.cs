using System;

namespace Lab02
{
  class Program
  {
    static void Main(string[] args)
    {
      TestStaticField();
      TestTime();
      TestPhanSo();

      return;
    }

    public static void TestStaticField()
    {
      var obj1 = new TetsStaticField();
      var obj2 = new TetsStaticField();

      obj1.I = 10;
      Console.WriteLine($"Gia tri I cua obj1: {obj1.I}");
      Console.WriteLine($"Gia tri I cua obj2: {obj2.I}");

      /*
      *   Bởi vì i là 1 trường static được tạo ra trước cả khi có bất kì đối tượng nào (obj1, obj2)
      *   Phạm vi truy cập của i gắn với chính bản thân class khai báo nó
      */
    }

    public static void TestTime()
    {
      DateTime current = System.DateTime.Now;
      Time time = new Time(current);

      // Current systen datetime
      Console.WriteLine($"Thoi gian hien tai: {time}");

      // Get time with ref
      int hour = 0;
      int minute = 0;
      int second = 0;
      time.GetTime(ref hour, ref minute, ref second);
      Console.WriteLine($"Thoi gian hien tai GetTime_Ref: {hour}:{minute}:{second}");

      // Get time with out
      int out_hour;
      int out_minute;
      int out_second;
      time.GetTime_Out(out out_hour, out out_minute, out out_second);
      Console.WriteLine($"Thoi gian hien tai GetTime_Out: {out_hour}:{out_minute}:{out_second}");
      /*
      *   Dùng ref yêu cầu biến phải được khởi tạo giá trị trước khi được truyền vào
      *   Dùng out không yêu cầu biến phải khởi tạo giá trị
      */
    }

    public static void TestPhanSo()
    {
      var ps1 = new PhanSo(5, 4);
      var ps2 = new PhanSo(1, 2);

      Console.WriteLine(-ps1);   // output: -5 / 4
      Console.WriteLine($"{ps1} + {ps2} = {ps1 + ps2}");  // output: 14 / 8 = 7 / 4
      Console.WriteLine($"{ps1} - {ps2} = {ps1 - ps2}");  // output: 6 / 8 = 3 / 4
      Console.WriteLine($"{ps1} * {ps2} = {ps1 * ps2}");  // output: 5 / 8
      Console.WriteLine($"{ps1} / {ps2} = {ps1 / ps2}");  // output: 10 / 4 = 5 / 2
      Console.WriteLine($"++{ps1} = {++ps1}");
      Console.WriteLine($"{ps1} == {ps2} ? {ps1 == ps2}");
      Console.WriteLine($"{ps1} != {ps2} ? {ps1 != ps2}");
    }
  }
}
