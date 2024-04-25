using Avalonia.Controls;
using FinalYearProjectDesktop.ViewModels;

namespace FinalYearProjectDesktop.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Logout_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            Login.LoggedIn = false;
        }
    }
}