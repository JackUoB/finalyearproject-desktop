using Avalonia.Controls;
using Avalonia.Interactivity;
using FinalYearProjectDesktop.ViewModels;
using System;
using System.Diagnostics;

namespace FinalYearProjectDesktop.Views;

public partial class LoginPageView : UserControl
{

    public LoginPageView()
    {
        Debug.WriteLine("initialised");
        InitializeComponent();
    }

    private void Button_Click(object? sender, RoutedEventArgs e)
    {
        Debug.WriteLine("btnclicked");
        Debug.WriteLine($"{Login.LoggedIn}");
        Login.LoggedIn = true;
        Debug.WriteLine($"{Login.LoggedIn}");

        if (Login.LoggedIn)
        {
            Debug.WriteLine("check");
        }
    }
}