using IsaacPickAndBan.Database;
using IsaacPickAndBan.ViewModels;
using IsaacPickAndBan.Views;
using IsaacPickAndBan.Views.PickAndBan;

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
            builder.Services.AddSingleton<Data>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();

            builder.Services.AddTransient<CardsArchive>();
            builder.Services.AddTransient<CardsArchiveViewModel>();

            builder.Services.AddTransient<PickAndBanManager>();
            builder.Services.AddTransient<PickAndBanManagerViewModel>();

            return builder.Build();
        }
    }
}
