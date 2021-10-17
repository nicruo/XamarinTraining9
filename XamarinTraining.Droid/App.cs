using Android.App;
using Android.Runtime;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using XamarinTraining.Core.Services;
using XamarinTraining.Core.ViewModels;
using XamarinTraining.Droid.Activities;
using XamarinTraining.Droid.Services;

namespace XamarinTraining.Droid
{
    [Application(UsesCleartextTraffic = true)]
    public class App : Application
    {
        public App()
        {
        }

        protected App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            SimpleIoc.Default.Register<Core.Services.INavigationService>(() =>
            {
                Services.NavigationService navigationService = new Services.NavigationService();
                navigationService.Configure(nameof(HomeViewModel), typeof(HomeActivity));
                navigationService.Configure(nameof(CharactersViewModel), typeof(CharactersActivity));
                return navigationService;
            });

            SimpleIoc.Default.Register<IDataService, DataService>();
            SimpleIoc.Default.Register<IToastService>(() => new ToastService(ApplicationContext));
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<CharactersViewModel>();
        }
    }
}