﻿
using TeleCOM.NET.API.Interops.Enums;

namespace TeleCOM.NET.API.Interfaces
{
    public interface IPortSender
    {
        public WindowMessages PortMessage { get; }

        public PortData Recieve(uint wParam);
    }
}
