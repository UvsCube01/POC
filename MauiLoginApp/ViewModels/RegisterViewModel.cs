using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiLoginApp.Services;

namespace MauiLoginApp.ViewModels;

public partial class RegisterViewModel : BaseViewModel
{
    private readonly AuthService _authService;

    [ObservableProperty]
    private string _username;

    [ObservableProperty]
    private string _password;

    [ObservableProperty]
    private string _email;

    public RegisterViewModel(AuthService authService)
    {
        _authService = authService;
        Title = "Register";
    }

    [RelayCommand]
    private async Task RegisterAsync()
    {
        if (IsBusy) return;

        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email))
        {
            await Shell.Current.DisplayAlert("Error", "All fields are required", "OK");
            return;
        }

        IsBusy = true;
        var success = await _authService.Register(Username, Password, Email);
        IsBusy = false;

        if (success)
        {
             await Shell.Current.DisplayAlert("Success", "Registration successful", "OK");
             await Shell.Current.GoToAsync("..");
        }
        else
        {
             await Shell.Current.DisplayAlert("Error", "Registration failed. User already exists.", "OK");
        }
    }
}
