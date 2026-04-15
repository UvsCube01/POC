using TemplateDemo.ViewModels;

namespace TemplateDemo.View;

public partial class EmployeeDetailForm : ContentPage
{
    public EmployeeDetailForm(EmployeeDetailViewModel employeeDetailViewModel)
    {
        InitializeComponent();
        BindingContext = employeeDetailViewModel;
    }
}
