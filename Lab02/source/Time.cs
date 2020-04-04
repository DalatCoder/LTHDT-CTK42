namespace Lab02
{
  public class Time
  {
    private readonly int _hour;
    private readonly int _minute;
    private readonly int _second;

    public Time(System.DateTime dateTime)
    {
      this._hour = dateTime.Hour;
      this._minute = dateTime.Minute;
      this._second = dateTime.Second;
    }

    public void GetTime(ref int hour, ref int minute, ref int second)
    {
      hour = this._hour;
      minute = this._minute;
      second = this._second;
    }

    public void GetTime_Out(out int hour, out int minute, out int second)
    {
      hour = this._hour;
      minute = this._minute;
      second = this._second;
    }

    public override string ToString() => $"{this._hour}:{this._minute}:{this._second}";
  }
}
