using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.MVVM.Models.StudentList;
using StudentManagement.Services.StudentList;

namespace StudentManagement.MVVM.ViewModels.StudentList
{
    /// <summary>
    /// Manages the student list page: exposes the live collection from the service
    /// and handles Edit / Delete commands. No mock data lives here.
    /// </summary>
    public partial class StudentListViewModel : ObservableObject
    {
        private readonly IStudentService _studentService;

        // The collection comes directly from the service so Add/Remove/Replace
        // on the service side are reflected in the UI without extra wiring.
        public ObservableCollection<StudentDTO> Students { get; }

        // ── Events ─────────────────────────────────────────────────────────────

        /// <summary>Raised when the user requests to edit a student (passes Id).</summary>
        public event Action<int>? EditRequested;

        /// <summary>Raised when the user clicks Add (no argument needed).</summary>
        public event Action? AddRequested;

        // ── Constructor ────────────────────────────────────────────────────────

        public StudentListViewModel(IStudentService studentService)
        {
            _studentService = studentService;
            Students = _studentService.GetAll();  // live reference — no copy
        }

        // ── Commands ───────────────────────────────────────────────────────────

        [RelayCommand]
        private void AddStudent() => AddRequested?.Invoke();

        [RelayCommand]
        private void EditStudent(StudentDTO student)
        {
            if (student is null) return;
            EditRequested?.Invoke(student.Id);
        }

        [RelayCommand]
        private void DeleteStudent(StudentDTO student)
        {
            if (student is null) return;
            // Raise a request to the View (which owns the UI/dialog thread)
            DeleteRequested?.Invoke(student);
        }

        /// <summary>
        /// Raised when the VM wants the View to confirm and perform a delete.
        /// The View calls ConfirmDelete() after the user confirms.
        /// </summary>
        public event Action<StudentDTO>? DeleteRequested;

        /// <summary>Called from the View after the user confirms deletion.</summary>
        public void ConfirmDelete(StudentDTO student) =>
            _studentService.Delete(student.Id);
    }
}
