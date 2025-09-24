using MobileAppProject.Views;

namespace MobileAppProject
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("recipedetail", typeof(RecipeDetailPage));
        }
    }
}
