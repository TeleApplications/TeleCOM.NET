using TeleCOM.NET.API;

namespace TeleCOM.NET.Client
{
    internal sealed class KeyboardListener : PortListener
    {
        public KeyboardListener() : base() 
        {
        }

        public override async Task OnRecieve(PortData data)
        {
            uint keyValue = data.WParam;
        }
    }
}
