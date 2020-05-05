namespace Lab09
{
    public class SinhVien
    {
        private string _hoDem;
        private string _ten;
        private string _mssv;

        public SinhVien() { }
        public SinhVien(string hoDem, string ten, string mssv)
        {
            _hoDem = hoDem;
            _ten = ten;
            _mssv = mssv;
        }

        public string HoDem 
        {
            get { return _hoDem; }
            set { _hoDem = value; }
        }
        public string Ten { get { return _ten; } set { _ten = value; } }
        public string MSSV { get { return _mssv; } set { _mssv = value; } }

        public string HoTen { get { return _hoDem + " " + _ten; } }
        public string Hoten()
        {
            return _hoDem + " " + _ten;
        }
    }
}
