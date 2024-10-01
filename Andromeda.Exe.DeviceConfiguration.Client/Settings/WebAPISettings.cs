using Andromeda.Configuration;
using Andromeda.Exe.DeviceConfiguration.Client.Settings.Abstractions;
using System;
using System.Configuration;

namespace Andromeda.Exe.DeviceConfiguration.Client.Settings
{
    public class WebAPISettings :
        BaseApplicationSettings,
        IWebAPISettings
    {
        private WebAPISettings() { }

        public static WebAPISettings Instance
            => (WebAPISettings)Synchronized(new WebAPISettings());

        [UserScopedSetting]
        [DefaultSettingValue("https://localhost:7131/api/")]
        public string WebAPIServerAddress
        {
            get => (string)this[nameof(WebAPIServerAddress)];
            set => this[nameof(WebAPIServerAddress)] = value;
        }

        [UserScopedSetting]
        [DefaultSettingValue("00:00:30")]
        public TimeSpan RefreshOnlineDelay
        {
            get => (TimeSpan)this[nameof(RefreshOnlineDelay)];
            set => this[nameof(RefreshOnlineDelay)] = value;
        }
    }
}
