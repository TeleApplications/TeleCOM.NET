using System.IO.Ports;
using TeleCOM.NET.API.Attributes;
using TeleCOM.NET.API.Interfaces;
using TeleCOM.NET.API.Ports;

namespace TeleCOM.NET.API.PortManager.Ports
{
    [Port(0, nameof(KeyboardPort))]
    public sealed class KeyboardPort : IPortType
    {
        public void SendData(PortData data, SerialPort port) 
        {
        }

        public ReadOnlyMemory<byte> RecieveData(SerialPort port) 
        {
            int bytesCount = port.BytesToRead;
            byte[] bytes = new byte[bytesCount];

            port.Read(bytes, 0, bytesCount);
            return bytes;
        }
    }
}
