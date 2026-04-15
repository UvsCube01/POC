using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TemplateDemo;
using TemplateDemo.Models;

namespace TemplateDemo.ViewModels;

public partial class StudentDetailViewModel : ObservableObject
{
    [ObservableProperty]
    private string _firstName = string.Empty;

    [ObservableProperty]
    private string _lastName = string.Empty;

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string _course = string.Empty;

    [ObservableProperty]
    private string _studentId = string.Empty;

    public ObservableCollection<Student> SavedStudents { get; set; } = new ObservableCollection<Student>();

    [RelayCommand]
    private async Task SaveStudentAsync()
    {
        // Simple validation
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please enter at least First and Last Name", "OK");
            return;
        }

        // Create new student and add to the list
        var newStudent = new Student
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            Email = this.Email,
            Course = this.Course,
            StudentId = this.StudentId
        };
        
        SavedStudents.Add(newStudent);

        // Clear form
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Course = string.Empty;
        StudentId = string.Empty;

        // Show success
        await App.Current.MainPage.DisplayAlert("Success", "Student Saved Successfully!", "OK");
    }
}
