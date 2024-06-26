﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FinalYearProjectDesktop.ViewModels;

public static class DatabaseInfo
{
    //static string dbPath = Directory.GetCurrentDirectory().Replace(@"finalyearproject-desktop\bin\Debug\net6.0", @"sqlite\test.db");
    static string server = "localhost";
    static string database = "test";
    static string username = "root";
    static string password = "";
    public static string connString = $"SERVER={server};DATABASE={database};UID={username};PASSWORD={password};";
}

public static class Login
{
    public static event EventHandler? OnLogin;

    private static bool _loggedIn = false;
    private static string _userLoggedIn = "user name";
    private static bool _isManagerLoggedIn = false;

    public static Boolean LoggedIn
    {
        get => _loggedIn;
        set
        {
            _loggedIn = value;
            OnLogin?.Invoke(null, EventArgs.Empty);
        }
    }

    public static string UserLoggedIn
    {
        get => _userLoggedIn;
        set
        {
            _userLoggedIn = value;
            OnLogin?.Invoke(null, EventArgs.Empty);
        }
    }

    public static Boolean IsManagerLoggedIn
    {
        get => _isManagerLoggedIn;
        set
        {
            _isManagerLoggedIn = value;
            OnLogin?.Invoke(null, EventArgs.Empty);
        }
    }
}

public partial class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    [ObservableProperty]
    private bool _isUserLoggedIn = Login.LoggedIn;

    [ObservableProperty]
    private string _userLoggedIn = Login.UserLoggedIn;

    [ObservableProperty]
    private string _userLoggedInInitial = $"{Login.UserLoggedIn.ToUpper().Split()[0][0]}{Login.UserLoggedIn.ToUpper().Split()[1][0]}";

    [ObservableProperty]
    private bool _isManagerLoggedIn = Login.IsManagerLoggedIn;

    [ObservableProperty]
    private bool _isPaneOpen = false;

    [ObservableProperty]
    private ViewModelBase _currentPage = new LoginPageViewModel();

    [ObservableProperty]
    private ListItemTemplate? _selectedListItem;

    public MainWindowViewModel() : base()
    {
        Login.OnLogin += Login_OnLogin;
    }

    // When user is logged in or logged out
    private void Login_OnLogin(object? sender, EventArgs e)
    {
        IsUserLoggedIn = Login.LoggedIn;
        UserLoggedIn = Login.UserLoggedIn;
        UserLoggedInInitial = $"{Login.UserLoggedIn.ToUpper().Split()[0][0]}{Login.UserLoggedIn.ToUpper().Split()[1][0]}";

        if (Login.LoggedIn)
        {
            CurrentPage = new HomePageViewModel();
        } 
        else
        {
            IsPaneOpen = false;
            CurrentPage = new LoginPageViewModel();

            if (Login.IsManagerLoggedIn)
            {
                IsManagerLoggedIn = false;
            }
        }
    }

    // Makes selected menu option become the active page
    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value is null) return;
        var selected = Activator.CreateInstance(value.ModelType);
        if (selected is null) return;
        CurrentPage = (ViewModelBase)selected;
    }

    // List of all menu options
    public ObservableCollection<ListItemTemplate> Items { get; } = new()
    {
        new ListItemTemplate(typeof(HomePageViewModel)),
        new ListItemTemplate(typeof(SquadPageViewModel)),
        new ListItemTemplate(typeof(FixturesPageViewModel)),
        new ListItemTemplate(typeof(LeagueTablePageViewModel)),
    };

    // Minimises the menu when button is clicked
    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
}

// Gets and formats name of the class before appearing in the menu
public class ListItemTemplate
{
    public ListItemTemplate(Type type)
    {
        ModelType = type;
        Label = type.Name.Replace("PageViewModel", "");

        // Inserts spaces into any menu options that need it
        for (int i = 0; i < Label.Length; i++)
        {
            string c = Label[i].ToString();
            if (c.Equals(c.ToUpper()))
            {
                Label = Label.Insert(i, " ").Trim();
                i++;
            }
        }
    }

    public string Label { get; }
    public Type ModelType { get; }
}