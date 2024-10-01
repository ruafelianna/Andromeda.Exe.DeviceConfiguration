using Andromeda.Configuration.Abstractions;
using System;

namespace Andromeda.Exe.DeviceConfiguration.Client.Settings.Abstractions
{
    public interface IWebAPISettings : IBaseApplicationSettings
    {
        string WebAPIServerAddress { get; }

        TimeSpan RefreshOnlineDelay { get; }
    }
}
