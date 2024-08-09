using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive.Linq;

namespace Andromeda.Exe.DeviceConfiguration.Server.Configurator.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _appIdsSource = new SourceCache<string, string>(x => x);

            var appIdsDisposable = _appIdsSource
                .Connect()
                .SortBy(x => x)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _appIds)
                .Subscribe();

            SecretsPath = DefaultSecretsPath.LocalPath;

            this.WhenAnyValue(x => x.SecretsPath)
                .Subscribe(x => UpdateAppIds());

            this.WhenAnyValue(x => x.AppId)
                .Subscribe(x => SecretsFile = AppId is null
                    ? null
                    :  File.ReadAllText(_secretsPath)
                );
        }

        static MainViewModel()
        {
            DefaultSecretsPath = new(
                OperatingSystem.IsAndroid()
                || OperatingSystem.IsLinux()
                || OperatingSystem.IsFreeBSD()
                || OperatingSystem.IsIOS()
                    ? _secretsPathUnix!
                    : OperatingSystem.IsWindows()
                        ? _secretsPathWindows!
                        : throw new NotSupportedException()
            );
        }

        /*
        * ******************************
        * *** WARNING FROM MICROSOFT ***
        * ******************************
        * Don't write code that depends on the location
        * or format of data saved with the Secret Manager tool.
        * These implementation details may change.
        * For example, the secret values aren't encrypted,
        * but could be in the future.
        */

        private readonly SourceCache<string, string> _appIdsSource;
        private readonly ReadOnlyObservableCollection<string> _appIds;
        public ReadOnlyObservableCollection<string> AppIds => _appIds;

        [Reactive]
        public string SecretsPath { get; private set; }

        [Reactive]
        public string? AppId { get; set; }

        [Reactive]
        public string? SecretsFile { get; set; }

        public void SaveSecrets()
            => File.WriteAllText(_secretsPath, SecretsFile);

        private string _secretsPath => Path.Combine(
            SecretsPath,
            AppId!,
            _secretFile
        );

        private static readonly Uri DefaultSecretsPath;

        private static readonly string _secretsPathWindows
            = Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData
            ) + @"\Microsoft\UserSecrets";

        private const string _secretsPathUnix
            = @"~/.microsoft/usersecrets";

        private const string _secretFile
            = @"secrets.json";

        private void UpdateAppIds()
        {
            var dirs = Directory.GetDirectories(SecretsPath)
                .Select(dir => Path.GetFileName(dir));
            _appIdsSource.RemoveKeys(_appIdsSource.Keys.Except(dirs));
            _appIdsSource.AddOrUpdate(dirs);
        }
    }
}
