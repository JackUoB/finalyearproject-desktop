using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace finalyearproject_desktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{

    [ObservableProperty]
    private bool _isPaneOpen = true;

    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
    

}