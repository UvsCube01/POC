using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiLoginApp.ViewModels;

[QueryProperty(nameof(Username), "Username")]
public partial class HomeViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _username;

    public HomeViewModel()
    {
        Title = "Home";
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
       await Shell.Current.GoToAsync("//LoginView");
    }
}
