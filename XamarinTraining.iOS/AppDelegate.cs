using Foundation;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using UIKit;
using XamarinTraining.Core.Services;
using XamarinTraining.Core.ViewModels;
using XamarinTraining.iOS.Services;
using XamarinTraining.iOS.ViewControllers;

namespace XamarinTraining.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = new UINavigationController(new HomeViewController());
            Window.MakeKeyAndVisible();

            SimpleIoc.Default.Register<Core.Services.INavigationService>(() =>
            {
                Services.NavigationService navigationService = new Services.NavigationService();
                navigationService.Initialize((UINavigationController)Window.RootViewController);
                navigationService.Configure(nameof(HomeViewModel), typeof(HomeViewController));
                navigationService.Configure(nameof(CharactersViewModel), typeof(CharactersViewController));
                return navigationService;
            });

            SimpleIoc.Default.Register<IDataService, DataService>();
            SimpleIoc.Default.Register<IToastService>(() => new ToastService(Window.RootViewController));
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<CharactersViewModel>();

            return true;
        }
    }
}