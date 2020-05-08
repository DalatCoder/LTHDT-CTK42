namespace KiemTra_07
{
    public class SinhVien : Nguoi
    {
        private string _mssv;
        private string _lop;

        public SinhVien(string hoDem, string ten, string maSo, string mssv, string lop)
            : base(hoDem, ten, maSo)
        {
            _mssv = mssv;
            _lop = lop;
        }

        public string MSSV { get => _mssv; set => _mssv = value; }
        public string Lop { get => _lop; set => _lop = value; }
    }
}
