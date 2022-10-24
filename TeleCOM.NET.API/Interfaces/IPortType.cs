using System.IO.Ports;
using TeleCOM.NET.API.Ports;

namespace TeleCOM.NET.API.Interfaces
{
    internal interface IPortType
    {
        public void SendData(PortData data, SerialPort port);
        public ReadOnlyMemory<byte> RecieveData(SerialPort port);
    }
}
