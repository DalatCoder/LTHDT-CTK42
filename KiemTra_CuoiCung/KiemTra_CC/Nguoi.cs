namespace KiemTra_CC
{
    public class Nguoi
    {
        protected string _hoDem;
        protected string _ten;
        protected string _maSo;

        public string HoDem { get { return _hoDem; } set { _hoDem = value; } }
        public string Ten { get { return _ten; } set { _ten = value; } }
        public string MaSo { get { return _maSo; } set { _maSo = value; } }

        public Nguoi() { }
        public Nguoi(string hoDem, string ten, string ms)
        {
            _hoDem = hoDem;
            _ten = ten;
            _maSo = ms;
        }
    }
}
