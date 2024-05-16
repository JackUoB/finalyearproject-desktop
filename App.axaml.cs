using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using FinalYearProjectDesktop.ViewModels;
using FinalYearProjectDesktop.Views;
using System.Threading.Tasks;

namespace FinalYearProjectDesktop
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override async void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Shows splash screen when application is first loaded up
                var splashScreenVm = new SplashScreenViewModel();
                var splashScreen = new SplashScreen
                {
                    DataContext = splashScreenVm
                };
                desktop.MainWindow = splashScreen;
                splashScreen.Show();

                // Adds loading message to splash screen
                try
                {
                    splashScreenVm.LoadingMessage = "Warming up...";
                    await Task.Delay(1250, splashScreenVm.CancellationToken);
                    splashScreenVm.LoadingMessage = "Lacing up boots...";
                    await Task.Delay(1250, splashScreenVm.CancellationToken);
                    splashScreenVm.LoadingMessage = "Talking tactics...";
                    await Task.Delay(250, splashScreenVm.CancellationToken);
                }
                catch (TaskCanceledException)
                {
                    splashScreen.Close(); // Closes splash screen if cancelled
                    return;
                }

                // Shows the application and closes the splash screen
                var mainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel()
                };
                desktop.MainWindow = mainWindow;
                mainWindow.Show();
                splashScreen.Close();
            }
        }
    }
}