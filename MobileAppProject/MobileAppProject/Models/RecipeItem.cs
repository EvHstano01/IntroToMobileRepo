using System.ComponentModel;

namespace MobileAppProject.Models
{
    public class RecipeItem
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? ImageFile { get; set; }
        public List<string>? Ingredients { get; set; }
        public string? Instructions { get; set; }
        public int? PrepMinutes { get; set; }
        public int? CookMinutes { get; set; }

        public int? TotalMinutes => PrepMinutes + CookMinutes;

        private bool _isFavourite;
        public bool IsFavourite
        {
            get => _isFavourite;
            set
            {
                if (_isFavourite != value)
                {
                    _isFavourite = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFavourite)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}