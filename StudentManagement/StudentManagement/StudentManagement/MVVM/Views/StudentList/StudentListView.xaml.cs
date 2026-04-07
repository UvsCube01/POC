using CommunityToolkit.Maui.Extensions;
using StudentManagement.MVVM.Models.StudentList;
using StudentManagement.MVVM.ViewModels.StudentList;

namespace StudentManagement.MVVM.Views.StudentList;

/// <summary>
/// Minimal code-behind. Only UI-framework concerns live here:
///   - Opening the popup (requires a Page reference)
///   - Showing the confirmation dialog (requires a Page reference)
/// All business decisions (what to save, whether to delete) remain in ViewModels.
/// </summary>
public partial class StudentListView : ContentPage
{
    private readonly StudentListViewModel _viewModel;
    private readonly StudentCreateViewModel _createViewModel;
    private readonly StudentCreatePopup _popup;

    public StudentListView(
        StudentListViewModel viewModel,
        StudentCreateViewModel createViewModel,
        StudentCreatePopup popup)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
        _createViewModel = createViewModel;
        _popup = popup;

        // Subscribe to VM events that require UI involvement
        _viewModel.AddRequested    += OnAddRequested;
        _viewModel.EditRequested   += OnEditRequested;
        _viewModel.DeleteRequested += OnDeleteRequested;
    }

    // ── Event Handlers ──────────────────────────────────────────────────────────

    private async void OnAddRequested()
    {
        _createViewModel.ResetForAdd();
        await this.ShowPopupAsync(_popup);
    }

    private async void OnEditRequested(int studentId)
    {
        _createViewModel.LoadForEdit(studentId);
        await this.ShowPopupAsync(_popup);
    }

    private async void OnDeleteRequested(StudentDTO student)
    {
        bool confirmed = await DisplayAlert(
            title  : "Delete Student",
            message: $"Are you sure you want to delete \"{student.Name}\"?",
            accept : "Yes, Delete",
            cancel : "Cancel");

        if (confirmed)
            _viewModel.ConfirmDelete(student);
    }
}