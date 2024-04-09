using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FinalYearProjectDesktop.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace FinalYearProjectDesktop.ViewModels;


public static class Login
{
    public static event EventHandler OnLogin;

    private static bool _loggedIn = false;
    public static Boolean LoggedIn
    {
        get => _loggedIn;
        set
        {
            _loggedIn = value;
            OnLogin?.Invoke(null, EventArgs.Empty);
        }
    }
}

public partial class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    [ObservableProperty]
    private bool _isUserLoggedIn = Login.LoggedIn;

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

    private void Login_OnLogin(object? sender, EventArgs e)
    {
        IsUserLoggedIn = Login.LoggedIn;
        if (Login.LoggedIn)
        {
            CurrentPage = new HomePageViewModel();
        } else
        {
            CurrentPage = new LoginPageViewModel();
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