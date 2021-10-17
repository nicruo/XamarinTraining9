using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XamarinTraining.Core.Domain;
using XamarinTraining.Core.Services;

namespace XamarinTraining.Core.ViewModels
{
    public class CharactersViewModel : ViewModelBase
    {
        private ObservableCollection<Character> characters = new ObservableCollection<Character>();
        private readonly IDataService dataService;

        public ObservableCollection<Character> Characters
        {
            get => characters;
            set => Set(nameof(Characters), ref characters, value);
        }

        public CharactersViewModel(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public async void LoadDataAsync(string searchQuery)
        {
            IList<Character> charactersResult = await dataService.GetCharactersByNameAsync(searchQuery);

            foreach(Character character in charactersResult)
            {
                Characters.Add(character);
                await Task.Delay(200);
            }
        }
    }
}