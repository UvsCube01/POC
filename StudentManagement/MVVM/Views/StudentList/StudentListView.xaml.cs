using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Extensions;
using StudentManagement.MVVM.ViewModels.StudentList;

namespace StudentManagement.MVVM.Views.StudentList;

public partial class StudentListView : ContentPage
{
    public StudentListView(StudentListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is StudentListViewModel vm)
        {
            vm.RequestShowPopup -= Vm_RequestShowPopup;
            vm.RequestShowPopup += Vm_RequestShowPopup;

            await vm.Initialize();
        }
    }

    private async void Vm_RequestShowPopup(object? sender, Popup popup)
    {
        await this.ShowPopupAsync(popup);
    }
}