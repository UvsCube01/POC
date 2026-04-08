using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.MVVM.Models.StudentList;
using StudentManagement.Services.StudentList;

namespace StudentManagement.MVVM.ViewModels.StudentList
{
    public partial class StudentListViewModel : ObservableObject
    {
        private readonly IStudentService _studentService;
        private readonly StudentCreateViewModel _createViewModel;
        private readonly Views.StudentList.StudentCreatePopup _popup;

        [ObservableProperty]
        public ObservableCollection<Student> _students;

        public event EventHandler<Popup>? RequestShowPopup;

        public StudentListViewModel(
            IStudentService studentService,
            StudentCreateViewModel createViewModel,
            Views.StudentList.StudentCreatePopup popup)
        {
            _studentService = studentService;
            _createViewModel = createViewModel;
            _popup = popup;
            //Students = _studentService.GetAll();
            Initialize();
        }

        private void Initialize()
        {
            _students = _studentService.GetAll();
        }
        public Task OnPageAppearingAsync()
        {
            return Task.CompletedTask;
        }

        [RelayCommand]
        private void AddStudent()
        {
            _createViewModel.ResetForAdd();
            RequestShowPopup?.Invoke(this, _popup);
        }

        [RelayCommand]
        private void EditStudent(Student student)
        {
            if (student is null) return;
            _createViewModel.LoadForEdit(student.Id);
            RequestShowPopup?.Invoke(this, _popup);
        }

        [RelayCommand]
        private async Task DeleteStudent(Student student)
        {
            if (student is null) return;

            // Moved logic into ViewModel entirely. Display alert for Delete.
            if (Application.Current?.MainPage != null)
            {
                bool confirmed = await Application.Current.MainPage.DisplayAlert(
                    "Delete Student",
                    $"Are you sure you want to delete \"{student.Name}\"?",
                    "Yes, Delete",
                    "Cancel");

                if (confirmed)
                {
                    _studentService.Delete(student.Id);
                }
            }
        }
    }
}
