using System.Diagnostics;
using TeleCOM.NET.API;

namespace TeleCOM.NET.Client
{
    internal sealed class RawInputListener : PortListener
    {
        public RawInputListener(Form currentForm) : base((uint)currentForm.Handle, currentForm.GetType().Module)
        {
        }

        public override async Task OnRecieve(PortData data)
        {
            Debug.WriteLine($"Current key: {(Keys)data.WParam}");
        }
    }
}
