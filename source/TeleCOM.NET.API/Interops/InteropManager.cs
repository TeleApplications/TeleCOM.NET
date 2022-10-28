using System.Runtime.InteropServices;
using System.Text;
using TeleCOM.NET.API.Interops.Structs;

namespace TeleCOM.NET.API.Interops
{
    public delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
    public static class InteropManager
    {

        [DllImport("User32.dll")]
        public static extern IntPtr SetParent(IntPtr hWnd, IntPtr parenthWnd);

        [DllImport("User32.dll")]
        public static extern IntPtr SetWindowsHookEx(uint hookType, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("User32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
    }
}
