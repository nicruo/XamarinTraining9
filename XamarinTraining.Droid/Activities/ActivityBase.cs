using Android.App;
using AndroidX.AppCompat.App;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.Generic;

namespace XamarinTraining.Droid.Activities
{
    public class ActivityBase<T> : ActivityBase where T : ViewModelBase
    {
        private T viewModel;
        public T ViewModel => viewModel ??= SimpleIoc.Default.GetInstance<T>();
    }

    public class ActivityBase : AppCompatActivity
    {
        protected List<Binding> bindings = new List<Binding>();

        /// <summary>
        /// The activity that is currently in the foreground.
        /// </summary>
        public static ActivityBase CurrentActivity
        {
            get;
            private set;
        }

        internal string ActivityKey
        {
            get;
            private set;
        }

        internal static string NextPageKey
        {
            get;
            set;
        }

        /// <summary>
        /// If possible, discards the current page and displays the previous page
        /// on the navigation stack.
        /// </summary>
        public static void GoBack()
        {
            if (CurrentActivity != null)
            {
                CurrentActivity.OnBackPressed();
            }
        }

        /// <summary>
        /// Overrides <see cref="Activity.OnResume"/>. If you override
        /// this method in your own Activities, make sure to call
        /// base.OnResume to allow the <see cref="NavigationService"/>
        /// to work properly.
        /// </summary>
        protected override void OnResume()
        {
            CurrentActivity = this;

            if (string.IsNullOrEmpty(ActivityKey))
            {
                ActivityKey = NextPageKey;
                NextPageKey = null;
            }

            base.OnResume();
        }
    }
}