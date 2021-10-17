using System.Threading.Tasks;
using UIKit;
using XamarinTraining.Core.Services;

namespace XamarinTraining.iOS.Services
{
    public class ToastService : IToastService
    {
        private readonly UIViewController viewController;

        public ToastService(UIViewController viewController)
        {
            this.viewController = viewController;
        }

        public async void ShowToast(string message)
        {
            UIAlertController alertController = new UIAlertController();
            alertController.Message = message;
            viewController.PresentViewController(alertController, true, null);
            await Task.Delay(2000);
            alertController.DismissViewController(true, null);
        }
    }
}