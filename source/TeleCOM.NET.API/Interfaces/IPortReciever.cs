
using TeleCOM.NET.API.Interops.Enums;

namespace TeleCOM.NET.API.Interfaces
{
    public interface IPortReciever
    {
        public WindowMessages PortMessage { get; }

        public PortData Recieve(uint wParam);
    }
}
