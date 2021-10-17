using Foundation;
using GalaSoft.MvvmLight.Helpers;
using System;
using UIKit;
using XamarinTraining.Core.Domain;
using XamarinTraining.Core.ViewModels;
using XamarinTraining.iOS.ViewCells;

namespace XamarinTraining.iOS.ViewControllers
{
    public class CharactersViewController : BaseViewController<CharactersViewModel>
    {
        private readonly string parameter;
        private UICollectionView collectionView;
        private Binding binding;

        public CharactersViewController(string parameter = null) : base()
        {
            this.parameter = parameter;
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            UICollectionViewLayout collectionViewLayout = UICollectionViewCompositionalLayout.GetLayout(new UICollectionLayoutListConfiguration(UICollectionLayoutListAppearance.Plain));
            collectionView = new UICollectionView(new CoreGraphics.CGRect(0, 0, 200, 600), collectionViewLayout);
            collectionView.RegisterClassForCell(typeof(CharacterViewCell), nameof(CharacterViewCell));

            View.Add(collectionView);

            collectionView.DataSource = ViewModel.Characters.GetCollectionViewSource<Character, CharacterViewCell>(OnBindElementViewCell);

            ViewModel.LoadDataAsync(parameter);
        }

        private void OnBindElementViewCell(CharacterViewCell arg1, Character arg2, NSIndexPath arg3)
        {

        }
    }
}