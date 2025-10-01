using MobileAppProject.Models;
using MobileAppProject.Services;
using MobileAppProject.ViewModels;
using MobileAppProject.Views;

namespace MobileAppProject.Views
{
    public partial class RecipeListPage : ContentPage
    {
        private RecipeListViewModel vm;

        public RecipeListPage()
        {
            InitializeComponent();

            vm = new RecipeListViewModel(new MockRecipeService());
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ = vm.LoadRecipesAsync();
        }

        void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var recipe = e.CurrentSelection.FirstOrDefault() as RecipeItem;
            if (recipe != null)
            {
                vm.SelectRecipeCommand.Execute(recipe);
                ((CollectionView)sender).SelectedItem = null;
            }
        }

        private void OnToggleThemeClicked(object sender, EventArgs e)
        {
            var app = Application.Current;
            if (app != null)
            {
                var currentTheme = app.UserAppTheme;
                app.UserAppTheme = currentTheme == AppTheme.Light ? AppTheme.Dark : AppTheme.Light;
            }
        }

        private async void OnViewFavouritesClicked(object sender, EventArgs e)
        {
            var page = new FavouritesPage(vm.Favourites);
            await Navigation.PushAsync(page);
        }
    }
}