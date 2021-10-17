using Android.App;
using Android.OS;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Bumptech.Glide;
using GalaSoft.MvvmLight.Ioc;
using XamarinTraining.Core.Domain;
using XamarinTraining.Core.Services;
using XamarinTraining.Core.ViewModels;
using XamarinTraining.Droid.Adapters;
using XamarinTraining.Droid.Services;
using XamarinTraining.Droid.Utils;

namespace XamarinTraining.Droid.Activities
{
    [Activity]
    public class CharactersActivity : ActivityBase<CharactersViewModel>
    {
        private ObservableRecyclerAdapter<Character, RecyclerView.ViewHolder> charactersAdapter;
        private RecyclerView charactersRecyclerView;
        public RecyclerView CharactersRecyclerView => charactersRecyclerView ??= FindViewById<RecyclerView>(Resource.Id.charactersRecyclerView);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_characters);

            NavigationService nav = SimpleIoc.Default.GetInstance<INavigationService>() as NavigationService;
            string activityParameter = nav.GetAndRemoveParameter<string>(Intent);
            ViewModel.LoadDataAsync(activityParameter);
            charactersAdapter = ViewModel.Characters.GetRecyclerAdapter(BindViewHolder, CreateViewHolder, null);
            CharactersRecyclerView.SetAdapter(charactersAdapter);
        }

        private RecyclerView.ViewHolder CreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.text_row_item, parent, false);

            CharacterViewHolder vh = new CharacterViewHolder(itemView);
            return vh;
        }

        private void BindViewHolder(RecyclerView.ViewHolder holder, Character character, int position)
        {
            CharacterViewHolder viewHolder = holder as CharacterViewHolder;
            viewHolder.TextView.Text = character.Name;
            Glide.With(this).Load(character.Image).Into(viewHolder.ImageView);
        }
    }
}