using TeleCOM.NET.API;

namespace TeleCOM.NET.Client
{
    internal sealed class RawInputListener : PortListener
    {
        public override async Task OnRecieve(PortData data)
        {
            MessageBox.Show($"{(Keys)data.WParam}");
        }
    }
}
