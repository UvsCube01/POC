using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLoginApp.Services;
using MauiLoginApp.Views;

namespace MauiLoginApp.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly AuthService _authService;

    [ObservableProperty]
    private string _username;

    [ObservableProperty]
    private string _password;

    public LoginViewModel(AuthService authService)
    {
        _authService = authService;
        Title = "Login";
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (IsBusy) return;

        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            await Shell.Current.DisplayAlert("Error", "Username and Password are required", "OK");
            return;
        }

        IsBusy = true;
        var user = await _authService.Login(Username, Password);
        IsBusy = false;

        if (user != null)
        {
            // Successfully logged in
            await Shell.Current.GoToAsync($"//{nameof(HomeView)}?Username={user.Username}");
        }
        else
        {
             await Shell.Current.DisplayAlert("Error", "Invalid username or password", "OK");
        }
    }

    [RelayCommand]
    private async Task GoToRegisterAsync()
    {
       await Shell.Current.GoToAsync(nameof(RegisterView));
    }
}
