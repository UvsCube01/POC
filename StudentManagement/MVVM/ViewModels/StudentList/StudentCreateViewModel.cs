using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.MVVM.Models.StudentList;
using StudentManagement.Services.StudentList;

namespace StudentManagement.MVVM.ViewModels.StudentList
{
    /// <summary>
    /// Drives the StudentCreatePopup for both Add and Edit flows.
    /// No business logic belongs in the popup's code-behind.
    /// </summary>
    public partial class StudentCreateViewModel : ObservableObject
    {
        private readonly IStudentService _studentService;

        // ── Bound Properties ───────────────────────────────────────────────────

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _email = string.Empty;

        [ObservableProperty]
        private string _department = string.Empty;

        /// <summary>Null in Add mode; holds the existing student in Edit mode.</summary>
        private Student? _editingStudent;

        public bool IsEditMode => _editingStudent is not null;
        public string Title => IsEditMode ? "Edit Student" : "Add New Student";

        // ── Events ─────────────────────────────────────────────────────────────

        /// <summary>Raised when the popup should close (after Save or Cancel).</summary>
        public event Action? CloseRequested;

        // ── Constructor ────────────────────────────────────────────────────────

        public StudentCreateViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // ── Public API ─────────────────────────────────────────────────────────

        /// <summary>Call before showing the popup to pre-fill fields for editing.</summary>
        public void LoadForEdit(int studentId)
        {
            _editingStudent = _studentService.GetById(studentId);
            if (_editingStudent is null) return;

            Name       = _editingStudent.Name;
            Email      = _editingStudent.Email;
            Department = _editingStudent.Department;

            OnPropertyChanged(nameof(IsEditMode));
            OnPropertyChanged(nameof(Title));
        }

        /// <summary>Resets all state so the VM can be reused for a fresh Add.</summary>
        public void ResetForAdd()
        {
            _editingStudent = null;
            Name       = string.Empty;
            Email      = string.Empty;
            Department = string.Empty;

            OnPropertyChanged(nameof(IsEditMode));
            OnPropertyChanged(nameof(Title));
        }

        // ── Commands ───────────────────────────────────────────────────────────

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
                return;

            if (IsEditMode)
            {
                _editingStudent!.Name       = Name;
                _editingStudent!.Email      = Email;
                _editingStudent!.Department = Department;
                _studentService.Update(_editingStudent!);
            }
            else
            {
                _studentService.Add(new Student
                {
                    Name       = Name,
                    Email      = Email,
                    Department = Department
                });
            }

            CloseRequested?.Invoke();
        }

        [RelayCommand]
        private void Cancel() => CloseRequested?.Invoke();
    }
}
