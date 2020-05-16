namespace KiemTra_CC
{
    public class GiaoVien : Nguoi
    {
        private string _id;
        private string _tenBoMon;

        public string ID { get { return _id; } }
        public string TenBoMon { get { return _tenBoMon; } set { _tenBoMon = value; } }

        public GiaoVien() { _id = "GV"; }
        public GiaoVien(string hoDem, string ten, string ms, string tenBoMon)
            : base(hoDem, ten, ms)
        {
            _id = "GV";
            _tenBoMon = tenBoMon;
        }
    }
}
