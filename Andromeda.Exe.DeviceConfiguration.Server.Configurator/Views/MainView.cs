using Andromeda.Exe.DeviceConfiguration.Server.Configurator.ViewModels;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Media;

namespace Andromeda.Exe.DeviceConfiguration.Server.Configurator.Views
{
    internal class MainView : Window
    {
        public MainView()
        {
            Content = new StackPanel
            {
                Children =
                {
                    new TextBlock
                    {
                        [!TextBlock.TextProperty]
                            = new Binding(nameof(MainViewModel.SecretsPath)),
                    },
                    new ComboBox
                    {
                        [!ItemsControl.ItemsSourceProperty]
                            = new Binding(nameof(MainViewModel.AppIds)),
                        [!SelectingItemsControl.SelectedItemProperty]
                            = new Binding(nameof(MainViewModel.AppId)),
                    },
                    new TextBox
                    {
                        TextWrapping = TextWrapping.Wrap,
                        AcceptsReturn = false,
                        [!TextBlock.TextProperty]
                            = new Binding(nameof(MainViewModel.SecretsFile)),
                    },
                    new Button
                    {
                        Content = "Save",
                        [!Button.CommandProperty]
                            = new Binding(nameof(MainViewModel.SaveSecrets)),
                    },
                },
            };
        }
    }
}
