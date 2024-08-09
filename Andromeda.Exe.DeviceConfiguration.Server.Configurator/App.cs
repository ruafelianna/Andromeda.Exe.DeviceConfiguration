using Andromeda.Exe.DeviceConfiguration.Server.Configurator.ViewModels;
using Andromeda.Exe.DeviceConfiguration.Server.Configurator.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;

namespace Andromeda.Exe.DeviceConfiguration.Server.Configurator
{
    internal class App : Application
    {
        public override void Initialize()
        {
            base.Initialize();

            DataTemplates.Add(new ViewLocator());
            Styles.Add(new FluentTheme());
            RequestedThemeVariant = ThemeVariant.Dark;
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime cdsal)
            {
                cdsal.MainWindow = new MainView()
                {
                    DataContext = new MainViewModel(),
                };
            }
        }
    }
}
