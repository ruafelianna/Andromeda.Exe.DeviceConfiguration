using Andromeda.Configuration.Abstractions;
using Andromeda.Exe.DeviceConfiguration.Client.Properties;
using System;

namespace Andromeda.Exe.DeviceConfiguration.Client.Settings.Abstractions
{
    public interface IAppSettings : IBaseApplicationSettings
    {
        Guid AppGuid { get; set; }

        AvailableLanguages Language { get; set; }
    }
}
