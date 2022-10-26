using System.Drawing;
using System.Runtime.InteropServices;

namespace TeleCOM.NET.API.Interops.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Message
    {
        public IntPtr Handle { get; set; }
        public uint MessageData { get; set; }
        public IntPtr WParam { get; set; }
        public IntPtr LParam { get; set; }
        public uint Time { get; set; }

        public Message(IntPtr handle, uint messageData, IntPtr wParam, IntPtr lParam, uint time) 
        {
            Handle = handle;
            MessageData = messageData;
            WParam = wParam;
            LParam = lParam;
            Time = time;
        }
    }
}
