using System.Runtime.InteropServices;

namespace TeleCOM.NET.API.Interops.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Message
    {
        public IntPtr Handle { get; set; }
        public uint MessageData { get; set; }
        public uint WParam { get; set; }
        public uint LParam { get; set; }
        public int Time { get; set; }
        public Vector2 Point { get; set; }
        public int LPrivate { get; set; }

        public Message(IntPtr handle, uint messageData, uint wParam, uint lParam, int time, Vector2 point, int lPrivate) 
        {
            Handle = handle;
            MessageData = messageData;
            WParam = wParam;
            LParam = lParam;
            Time = time;
            Point = point;
            LPrivate = lPrivate;
        }
    }
}
