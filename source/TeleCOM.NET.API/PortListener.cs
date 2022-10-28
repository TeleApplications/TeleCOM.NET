using System.Collections.Immutable;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using TeleCOM.NET.API.Interfaces;
using TeleCOM.NET.API.Interops;
using TeleCOM.NET.API.Interops.Enums;
using TeleCOM.NET.API.Interops.Structs;

namespace TeleCOM.NET.API
{
    public abstract class PortListener : IDisposable
    {
        private static readonly ImmutableArray<IPortReciever> portRecievers =
            ImmutableArray.CreateRange(GetAssemblyRecievers());

        public Message CurrentMessage { get; set; }
        public bool IsRunning { get; protected set; } = true;
        public virtual ImmutableArray<IPortReciever> PortRecievers => portRecievers;

        protected IntPtr portProc { get; private set; }

        public PortListener(uint handle, Module windowModule)
        {
            var windowInstance = Marshal.GetHINSTANCE(windowModule);

            //Setting the threadId to 0 is for now causing a big
            //performance problem, in next update this will be fixed
            //by fast way of finding id of current window handle
            portProc = InteropManager.SetWindowsHookEx(13, OnPortHookProc, windowInstance, 0);
        }

        private IntPtr OnPortHookProc(int code, IntPtr wParam, IntPtr lParam) 
        {
            var port = GetCurrentPort((uint)wParam);
            Debug.WriteLine($"Current WM_message: {(WindowMessages)wParam}");
            if (port is not null) 
            {
                PortData data = port.Recieve((uint)CurrentMessage.WParam);
                Task.Run(async() => await OnRecieve(data));
            }

            return InteropManager.CallNextHookEx(portProc, (int)code, wParam, lParam);
        } 

        public abstract Task OnRecieve(PortData data);

        protected IPortReciever GetCurrentPort(uint wParam) 
        {
            var vectorParameter = new Vector<uint>(wParam);
            var vectorSize = Vector<uint>.Count;

            int difference = PortRecievers.Length - vectorSize;
            int vectorizationCount = 0;
            for (int i = 0; i < difference; i+=vectorSize)
            {
                IPortReciever currentPort = PortRecievers[i];
                var portParameter = new Vector<uint>((uint)currentPort.PortMessage);
                if (Vector.EqualsAll(vectorParameter, portParameter))
                    return currentPort;
                vectorizationCount = i;
            }

            for (int j = vectorizationCount; j < PortRecievers.Length; j++)
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
