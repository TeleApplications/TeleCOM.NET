using System.Runtime.InteropServices;
using TeleCOM.NET.API.Interops.Structs;

namespace TeleCOM.NET.API.Interops
{
    internal static class InteropManager
    {
        [DllImport("User32.dll")]
        public static extern int GetMessage(ref Message lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("User32.dll")]
        public static extern int TranslateMessage(ref Message lpMsg);

        [DllImport("User32.dll")]
        public static extern int DispatchMessage(ref Message lpMsg);
    }
}
