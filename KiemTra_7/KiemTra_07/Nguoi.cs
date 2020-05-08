namespace KiemTra_07
{
    public class Nguoi
    {
        protected string _hoDem;
        protected string _ten;
        protected string _maSo;

        public string HoDem { get => _hoDem; set => _hoDem = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public string MaSo { get => _maSo; set => _maSo = value; }

        public Nguoi(string hoDem, string ten, string maso)
        {
            _hoDem = hoDem;
            _ten = ten;
            _maSo = maso;
        }
    }
}
