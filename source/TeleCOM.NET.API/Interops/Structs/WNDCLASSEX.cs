
namespace TeleCOM.NET.API.Interops.Structs
{
    internal struct WNDCLASSEX
    {
        public int cbSize { get; set; }
        public int style { get; set; }
        public IntPtr lpfnWndProc { get; set; }
        public int cbClsExtra { get; set; }
        public int cbWndExtra { get; set; }
        public IntPtr hInstance { get; set; }
        public IntPtr hIcon { get; set; }
        public IntPtr hCursor { get; set; }
        public IntPtr hbrBackground { get; set; }
        public string lpszMenuName { get; set; }
        public string lpszClassName { get; set; }
        public IntPtr hIconSm { get; set; }
    }
}
