using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FinalYearProjectDesktop.ViewModels;
using System;

namespace FinalYearProjectDesktop.Views;

public partial class HomePageView : UserControl
{
    public HomePageView()
    {
        InitializeComponent();
    }

    private void Logout_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        Login.LoggedIn = false;
    }
}