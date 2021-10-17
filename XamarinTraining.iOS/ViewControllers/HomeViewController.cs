using GalaSoft.MvvmLight.Helpers;
using UIKit;
using XamarinTraining.Core.ViewModels;

namespace XamarinTraining.iOS.ViewControllers
{
    public class HomeViewController : BaseViewController<HomeViewModel>
    {
        private UITextField searchTextField;
        private UIButton searchButton;
        private Binding binding;

        public HomeViewController(string parameter = null) : base()
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            searchTextField = new UITextField();
            searchTextField.BackgroundColor = UIColor.Red;
            searchTextField.Frame = new CoreGraphics.CGRect(0, 100, 400, 50);
            View.Add(searchTextField);

            searchButton = new UIButton(UIButtonType.System);
            searchButton.Frame = new CoreGraphics.CGRect(0, 200, 400, 50);
            searchButton.SetTitle("hello world", UIControlState.Normal);
            View.Add(searchButton);

            bindings.Add(this.SetBinding(() => searchTextField.Text, () => ViewModel.SearchQuery, BindingMode.OneWay));
            searchButton.SetCommand(ViewModel.NavigateToCharactersCommand);
        }
    }
}