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
                    fonts.AddFont("Font_soulsV2_Body-Regular.ttf", "IsaacFont");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "SolidFA");
                });

            // pages
            builder.Services.AddSingleton<Data>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();

            builder.Services.AddTransient<CardsArchiveManager>();
            builder.Services.AddTransient<CardsArchiveViewModel>();

            builder.Services.AddTransient<PickAndBanManager>();
            builder.Services.AddTransient<PickAndBanManagerViewModel>();

            builder.Services.AddTransient<FiltersContentView>();
            builder.Services.AddTransient<FiltersContentViewModel>();

            return builder.Build();
        }
    }
}
