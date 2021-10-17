using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using XamarinTraining.Core.Services;

namespace XamarinTraining.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public RelayCommand NavigateToCharactersCommand => new RelayCommand(NavigateToCharacters);

        private void NavigateToCharacters()
        {
            navigationService.NavigateTo(nameof(CharactersViewModel), SearchQuery);
        }

        private string searchQuery;
        public string SearchQuery
        {
            get => searchQuery;
            set => Set(nameof(SearchQuery), ref searchQuery, value);
        }

        public HomeViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }     
    }
}