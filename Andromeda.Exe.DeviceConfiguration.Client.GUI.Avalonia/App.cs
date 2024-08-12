using Avalonia;
using Avalonia.Themes.Fluent;

namespace Andromeda.Exe.DeviceConfiguration.Client.GUI.Avalonia
{
    public class App : Application
    {
        public override void Initialize()
        {
            Styles.Add(new FluentTheme());
        }

        public override void OnFrameworkInitializationCompleted()
        {

        }
    }
}
