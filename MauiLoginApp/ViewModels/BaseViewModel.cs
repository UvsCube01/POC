using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiLoginApp.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _title;
}
