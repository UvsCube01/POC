using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using StudentManagement.MVVM.ViewModels.StudentList;
using StudentManagement.MVVM.Views.StudentList;
using StudentManagement.Services.StudentList;

namespace StudentManagement
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf",   "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf",  "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // ── Services ──────────────────────────────────────────────────────
            // Singleton so the same in-memory collection is shared across all consumers.
            builder.Services.AddSingleton<IStudentService, MockStudentService>();

            // ── ViewModels ────────────────────────────────────────────────────
            builder.Services.AddTransient<StudentListViewModel>();
            // Singleton so the popup can be opened multiple times without losing state.
            builder.Services.AddSingleton<StudentCreateViewModel>();

            // ── Views ─────────────────────────────────────────────────────────
            builder.Services.AddTransient<StudentListView>();
            // Singleton popup instance reused across Add and Edit flows.
            builder.Services.AddSingleton<StudentCreatePopup>();

            return builder.Build();
        }
    }
}
