using MauiLoginApp.demo;
using Microsoft.Extensions.DependencyInjection;

namespace MauiLoginApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		//return new Window(new NewPage1());
		return new Window(new AppShell());
	}
}