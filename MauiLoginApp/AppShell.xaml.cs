using MauiLoginApp.Views;

namespace MauiLoginApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(RegisterView), typeof(RegisterView));
        Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
	}
}

