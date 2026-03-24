using Microsoft.Extensions.DependencyInjection;

namespace Test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Application.Current.UserAppTheme = AppTheme.Light;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            UserAppTheme = AppTheme.Light;
            //return new Window(new DemoPage());
            return new Window(new AppShell());
        }
    }
}