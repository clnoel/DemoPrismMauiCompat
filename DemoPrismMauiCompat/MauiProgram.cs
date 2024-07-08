#define BROKEN
//#define NOPRISM
//#define WORKAROUND

using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace DemoPrismMauiCompat
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCompatibility()
#if BROKEN || WORKAROUND
                .UsePrism(ConfigurePrism)
#endif
        .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static void SetMainPage(App theApp)
        {
#if NOPRISM
            theApp.MainPage = new AppShell();
#endif

        }

        public static void ConfigurePrism(PrismAppBuilder builder)
        {
            builder
                .RegisterTypes(containerRegistry =>
                {
#if WORKAROUND
                    containerRegistry.Register<Microsoft.UI.Xaml.Window>((provider)=>null);
#endif

                    containerRegistry.RegisterForNavigation<MainPage>();
                })
                .CreateWindow("MainPage");

        }

    }
}
