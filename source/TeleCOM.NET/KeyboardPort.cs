using TeleCOM.NET.API;
using TeleCOM.NET.API.Interfaces;
using TeleCOM.NET.API.Interops.Enums;

namespace TeleCOM.NET.Client
{
    internal sealed class KeyboardPort : IPortReciever
    {
        public WindowMessages PortMessage => WindowMessages.WM_KEYDOWN;

        public PortData Recieve(uint wParam) => new((uint)PortMessage, wParam);
    }
}
