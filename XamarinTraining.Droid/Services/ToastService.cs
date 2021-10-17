using Android.Content;
using Android.Widget;
using XamarinTraining.Core.Services;

namespace XamarinTraining.Droid.Services
{
    public class ToastService : IToastService
    {
        private readonly Context context;

        public ToastService(Context context)
        {
            this.context = context;
        }

        public void ShowToast(string message)
        {
            Toast.MakeText(context, message, ToastLength.Long).Show();
        }
    }
}