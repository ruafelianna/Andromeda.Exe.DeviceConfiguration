using Andromeda.Exe.DeviceConfiguration.Server.Configurator.ViewModels;
using Andromeda.Exe.DeviceConfiguration.Server.Configurator.Views;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;

namespace Andromeda.Exe.DeviceConfiguration.Server.Configurator
{
    internal class ViewLocator : IDataTemplate
    {
        public Control? Build(object? data)
            => (Control?)Activator.CreateInstance(
                data is null
                    ? typeof(ViewModelIsNull)
                    : data.GetType().Name switch
                    {
                        nameof(MainViewModel) => typeof(MainView),
                        _ => typeof(ViewNotFound),
                    }
            );

        public bool Match(object? data)
            => data is ViewModelBase;
    }
}
