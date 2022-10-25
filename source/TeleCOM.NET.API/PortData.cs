using System.Runtime.InteropServices;

namespace TeleCOM.NET.API
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct PortData
    {
        public uint Message { get; }
        public uint WParam { get; }

        public PortData(uint message, uint wParam) 
        {
            Message = message;
            WParam = wParam;
        }
    }
}
