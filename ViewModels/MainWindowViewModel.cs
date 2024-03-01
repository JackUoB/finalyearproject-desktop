using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FinalYearProjectDesktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    [ObservableProperty]
    private bool _isPaneOpen = true;

    [ObservableProperty]
    private ViewModelBase _currentPage = new HomePageViewModel();

    [ObservableProperty]
    private ListItemTemplate? _selectedListItem;

    // Makes selected menu button become the active page
    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value is null) return;
        var selected = Activator.CreateInstance(value.ModelType);
        if (selected is null) return;
        CurrentPage = (ViewModelBase)selected;
    }

    // Dynamic list of all meny options
    public ObservableCollection<ListItemTemplate> Items { get; } = new()
    {
        new ListItemTemplate(typeof(HomePageViewModel)),
        new ListItemTemplate(typeof(FixturesPageViewModel)),
    };

    // Minimises the menu when button is clicked
    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }

}

// Formats name of the class before appearing in the menu
public class ListItemTemplate
{
    public ListItemTemplate(Type type)
    {
        ModelType = type;
        Label = type.Name.Replace("PageViewModel", "");
    }

    public string Label { get; }
    public Type ModelType { get; }
}