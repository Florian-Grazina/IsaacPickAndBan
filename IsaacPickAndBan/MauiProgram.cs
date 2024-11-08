using IsaacPickAndBan.ViewModels;
using Microsoft.Extensions.Logging;

namespace IsaacPickAndBan
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font_soulsV2_Body-Regular", "IsaacFont");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "SolidFA");
                });

            // pages
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
