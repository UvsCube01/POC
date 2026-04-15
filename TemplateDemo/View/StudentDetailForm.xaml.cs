using TemplateDemo.ViewModels;

namespace TemplateDemo.View;

public partial class StudentDetailForm : ContentPage
{
    public StudentDetailForm(StudentDetailViewModel studentDetailViewModel)
    {
        InitializeComponent();
        BindingContext = studentDetailViewModel;
    }
}
