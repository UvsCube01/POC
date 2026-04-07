using BindingDemo.ViewModel;

namespace BindingDemo.View;

public partial class StudentView : ContentPage
{
	public StudentView(StudentViewModel studentViewModel)
	{
		InitializeComponent();
		BindingContext = studentViewModel;
    }
}