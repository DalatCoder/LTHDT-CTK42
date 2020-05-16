namespace Lab09
{
    interface IODatabase
    {
        void Doc(string FileName);
        void Xuat(string FileName);
        string Data { get; }
    }
}
