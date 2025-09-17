using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppProject.Models
{
    public class Recipe
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImageFile { get; set; }
        public List<string> Ingredients { get; set; }
        public string Instructions { get; set; }
        public int PrepMinutes { get; set; }
        public int CookMinutes { get; set; }

        // Recipe Total Time
        public int TotalMinutes => PrepMinutes + CookMinutes;
    }

}
