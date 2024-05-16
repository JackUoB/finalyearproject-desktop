using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalYearProjectDesktop.ViewModels;

public partial class SplashScreenViewModel: ViewModelBase
{
    [ObservableProperty]
    private string? _loadingMessage;

    public void Cancel()
    {
        LoadingMessage = "Closing...";
        _cts.Cancel();
    }

    public readonly CancellationTokenSource _cts = new CancellationTokenSource();
    public CancellationToken CancellationToken => _cts.Token;
}
