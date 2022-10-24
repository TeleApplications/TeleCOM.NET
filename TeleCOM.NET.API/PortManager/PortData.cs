namespace TeleCOM.NET.API.Ports
{
    public readonly struct PortData
    {
        public int PortId { get; }
        public ReadOnlyMemory<byte> Data { get; }

        public PortData(int portId, ReadOnlyMemory<byte> data) 
        {
            PortId = portId;
            Data = data;
        }
    }
}
