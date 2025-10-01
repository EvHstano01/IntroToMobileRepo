using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppProject.Services
{
    class SpoonacularAPIService
    {
        private readonly HttpClient _httpClient;

        public SpoonacularAPIService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("recipe-food-nutrition.p.rapidapi.com");
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "78e0c4265bmshdfa1acbbc99ef27p1b2bd2jsn8ca37");
        }



    }
}
