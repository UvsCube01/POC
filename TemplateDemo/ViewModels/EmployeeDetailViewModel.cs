using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TemplateDemo.Models;

namespace TemplateDemo.ViewModels;

public partial class EmployeeDetailViewModel : ObservableObject
{
    [ObservableProperty]
    private string _firstName = string.Empty;

    [ObservableProperty]
    private string _lastName = string.Empty;

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string _department = string.Empty;

    [ObservableProperty]
    private string _designation = string.Empty;

    public ObservableCollection<Employee> SavedEmployees { get; set; } = new ObservableCollection<Employee>();

    [RelayCommand]
    private async Task SaveEmployeeAsync()
    {
        // Simple validation
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please enter at least First and Last Name", "OK");
            return;
        }

        // Create new employee and add to the list
        var newEmployee = new Employee
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            Email = this.Email,
            Department = this.Department,
            Designation = this.Designation
        };
        
        SavedEmployees.Add(newEmployee);

        // Clear form
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Department = string.Empty;
        Designation = string.Empty;

        // Show success
        await App.Current.MainPage.DisplayAlert("Success", "Employee Saved Successfully!", "OK");
    }
}
