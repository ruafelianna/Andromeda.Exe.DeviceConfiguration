using Avalonia;
using Avalonia.ReactiveUI;
using System;

namespace Andromeda.Exe.DeviceConfiguration.Server.Configurator
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace()
                .UseReactiveUI();
    }
}
