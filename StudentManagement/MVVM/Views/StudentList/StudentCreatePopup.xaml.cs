using CommunityToolkit.Maui.Views;
using StudentManagement.MVVM.ViewModels.StudentList;

namespace StudentManagement.MVVM.Views.StudentList;

/// <summary>
/// Minimal code-behind. All logic lives in StudentCreateViewModel.
/// The popup simply subscribes to CloseRequested so it can dismiss itself.
/// </summary>
public partial class StudentCreatePopup : Popup
{
    public StudentCreatePopup(StudentCreateViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        // When the VM signals it's done (Save or Cancel), close the popup.
        viewModel.CloseRequested += async () => await CloseAsync();
    }
}