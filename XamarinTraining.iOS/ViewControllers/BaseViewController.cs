using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.Generic;
using UIKit;

namespace XamarinTraining.iOS.ViewControllers
{
    public class BaseViewController<T> : BaseViewController where T : ViewModelBase
    {
        private T viewModel;
        public T ViewModel => viewModel ?? ( viewModel = SimpleIoc.Default.GetInstance<T>());
    }

    public class BaseViewController : UIViewController
    {
        protected List<Binding> bindings = new List<Binding>();
    }
}