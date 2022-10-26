using System.Collections.Immutable;
using System.Numerics;
using TeleCOM.NET.API.Interfaces;
using TeleCOM.NET.API.Interops;
using TeleCOM.NET.API.Interops.Enums;

namespace TeleCOM.NET.API
{
    public abstract class PortListener : IDisposable
    {
        private static readonly ImmutableArray<IPortReciever> portRecievers =
            ImmutableArray.CreateRange(GetAssemblyRecievers());
        private IntPtr windowHandle;

        public bool IsRunning { get; protected set; } = true;
        public virtual ImmutableArray<IPortReciever> PortRecievers => portRecievers;

        public PortListener(IntPtr handle) 
        {
            windowHandle = handle;
        }

        public async Task StartRecievingAsync() 
        {
            await Task.Run(async() =>
            {
                while (IsRunning)
                {
                    var messageState = InteropManager.GetMessage(out var message, windowHandle, (uint)WindowMessages.WM_KEYDOWN, (uint)WindowMessages.WM_MOVING);
                    if (messageState != 0) 
                    {
                        InteropManager.TranslateMessage(ref message);
                        var port = GetCurrentPort(message.WParam);
                        PortData data = port.Recieve(message.WParam);

                        await OnRecieve(data);
                    }
                }
            });
        }

        public abstract Task OnRecieve(PortData data);

        protected IPortReciever GetCurrentPort(uint wParam) 
        {
            var vectorParameter = new Vector<uint>(wParam);
            var vectorSize = Vector<uint>.Count;

            int difference = PortRecievers.Length - vectorSize;
            for (int i = 0; i < difference; i+=vectorSize)
            {
                IPortReciever currentPort = PortRecievers[i];
                var portParameter = new Vector<uint>((uint)currentPort.PortMessage);
                if (Vector.EqualsAll(vectorParameter, portParameter))
                    return currentPort;
            }

            for (int j = difference; j < PortRecievers.Length; j++)
            {
                IPortReciever currentPort = PortRecievers[j];
                uint portParameter = (uint)currentPort.PortMessage;
                if (wParam == portParameter)
                    return currentPort;
            }
            return null!;
        }

        private static IEnumerable<IPortReciever> GetAssemblyRecievers() 
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(n => n.GetTypes())
                .Where(n => typeof(IPortReciever).IsAssignableFrom(n) && n.IsClass).ToArray();

            for (int i = 0; i < types.Length; i++)
            {
                var instance = Activator.CreateInstance(types[i]);
                yield return (IPortReciever)instance!;
            }
        }

        public void Dispose() 
        {
            IsRunning = false;
        }
   }
}
