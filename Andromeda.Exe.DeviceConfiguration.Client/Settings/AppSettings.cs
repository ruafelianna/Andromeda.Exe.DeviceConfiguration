using Andromeda.Configuration;
using Andromeda.Exe.DeviceConfiguration.Client.Properties;
using Andromeda.Exe.DeviceConfiguration.Client.Settings.Abstractions;
using System;
using System.Configuration;

namespace Andromeda.Exe.DeviceConfiguration.Client.Settings
{
    public class AppSettings :
        BaseApplicationSettings,
        IAppSettings
    {
        private AppSettings() { }

        public static AppSettings Instance
            => (AppSettings)Synchronized(new AppSettings());

        [UserScopedSetting]
        [DefaultSettingValue("00000000-0000-0000-0000-000000000000")]
        public Guid AppGuid
        {
            get => (Guid)this[nameof(AppGuid)];
            set => this[nameof(AppGuid)] = value;
        }

        [UserScopedSetting]
        [DefaultSettingValue("1")]
        public AvailableLanguages Language
        {
            get => (AvailableLanguages)this[nameof(Language)];
            set => this[nameof(Language)] = value;
        }
    }
}
