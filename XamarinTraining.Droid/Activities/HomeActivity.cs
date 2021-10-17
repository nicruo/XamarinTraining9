using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using System;
using XamarinTraining.Core.Services;
using XamarinTraining.Core.ViewModels;

namespace XamarinTraining.Droid.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class HomeActivity : ActivityBase<HomeViewModel>
    {
        private EditText searchEditText;
        public EditText SearchEditText => searchEditText ??= FindViewById<EditText>(Resource.Id.searchEditText);

        private Button searchButton;
        public Button SearchButton => searchButton ??= FindViewById<Button>(Resource.Id.searchButton);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_home);

            bindings.Add(this.SetBinding(() => SearchEditText.Text, () => ViewModel.SearchQuery, BindingMode.OneWay));
            bindings.Add(this.SetBinding(() => ViewModel.SearchQuery, () => SearchButton.Visibility, BindingMode.OneWay).ConvertSourceToTarget(func));
            SearchButton.SetCommand(ViewModel.NavigateToCharactersCommand);
        }

        private ViewStates func(string arg)
        {
            if(arg == "hide")
            {
                return ViewStates.Gone;
            }
            return ViewStates.Visible;
        }
    }
}