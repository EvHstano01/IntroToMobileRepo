using MobileAppProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppProject.Services
{
    public class MockRecipeService : IRecipeService
    {
        // Hardcoded list of recipes until a recipe service and functionality is implemented
        private readonly List<RecipeItem> _recipes = new()
        {
            new RecipeItem
            {
                Id = "r1",
                Title = "Spaghetti with Meat Sauce",
                ShortDescription = "Classic spaghetti with a rich beef tomato sauce",
                ImageFile = "spaghetti.jpg",
                Ingredients = new List<string>
                {
                    "1 lb spaghetti",
                    "1 lb ground beef",
                    "1 can (28 oz) crushed tomatoes",
                    "1 onion, diced",
                    "2 cloves garlic, minced",
                    "1 tsp salt",
                    "1/2 tsp pepper",
                    "2 tbsp olive oil",
                    "1 tsp dried oregano",
                    "1 tsp dried basil"
                },
                Instructions =
                    "1. Cook spaghetti according to package instructions.\n" +
                    "2. In a large pan, heat olive oil over medium heat. Sauté onion until translucent.\n" +
                    "3. Add garlic and cook 1 more minute.\n" +
                    "4. Add ground beef and cook until browned.\n" +
                    "5. Stir in crushed tomatoes, oregano, basil, salt, and pepper. Simmer for 15–20 minutes.\n" +
                    "6. Serve sauce over cooked spaghetti.",
                PrepMinutes = 10,
                CookMinutes = 25
            },
            new RecipeItem
            {
                Id = "r2",
                Title = "Roast Chicken with Potatoes",
                ShortDescription = "Juicy roast chicken with roasted potatoes",
                ImageFile = "roastchicken.jpg",
                Ingredients = new List<string>
                {
                    "1 whole chicken (4–5 lbs)",
                    "4 cups potatoes, chopped",
                    "2 tbsp olive oil",
                    "1 tsp salt",
                    "1/2 tsp pepper",
                    "1 tsp paprika",
                    "1 tsp dried thyme"
                },
                Instructions =
                    "1. Preheat oven to 375°F (190°C).\n" +
                    "2. Rub chicken with 1 tbsp olive oil, salt, pepper, paprika, and thyme.\n" +
                    "3. Toss potatoes with remaining olive oil, salt, and pepper.\n" +
                    "4. Place chicken in roasting pan and arrange potatoes around it.\n" +
                    "5. Roast for 1.5 hours or until chicken reaches internal temp of 165°F (74°C).\n" +
                    "6. Let chicken rest 10 minutes before carving.",
                PrepMinutes = 15,
                CookMinutes = 90
            },
            new RecipeItem
            {
                Id = "r3",
                Title = "Beef Stew",
                ShortDescription = "Hearty beef stew with vegetables",
                ImageFile = "beefstew.jpg",
                Ingredients = new List<string>
                {
                    "1 lb beef stew meat",
                    "4 cups beef broth",
                    "3 carrots, sliced",
                    "3 potatoes, diced",
                    "1 onion, chopped",
                    "2 tbsp flour",
                    "2 tbsp oil",
                    "1 tsp salt",
                    "1/2 tsp pepper",
                    "1 tsp dried thyme"
                },
                Instructions =
                    "1. In a large pot, heat oil over medium heat. Brown beef on all sides.\n" +
                    "2. Sprinkle flour over beef and stir for 1 minute.\n" +
                    "3. Add onion, carrots, potatoes, beef broth, salt, pepper, and thyme.\n" +
                    "4. Bring to a boil, then reduce heat and simmer for 1.5–2 hours until beef is tender.\n" +
                    "5. Serve hot.",
                PrepMinutes = 15,
                CookMinutes = 120
            },
            new RecipeItem
            {
                Id = "r4",
                Title = "Mac and Cheese",
                ShortDescription = "Classic creamy macaroni and cheese",
                ImageFile = "maccheese.jpg",
                Ingredients = new List<string>
                {
                    "2 cups elbow macaroni",
                    "2 cups shredded cheddar cheese",
                    "2 cups milk",
                    "2 tbsp butter",
                    "2 tbsp flour",
                    "1/2 tsp salt",
                    "1/4 tsp pepper"
                },
                Instructions =
                    "1. Cook macaroni according to package instructions and drain.\n" +
                    "2. In a saucepan, melt butter over medium heat. Stir in flour and cook 1 minute.\n" +
                    "3. Gradually whisk in milk and cook until thickened.\n" +
                    "4. Add cheese, salt, and pepper. Stir until cheese melts.\n" +
                    "5. Combine cheese sauce with cooked macaroni and serve warm.",
                PrepMinutes = 10,
                CookMinutes = 15
            },
            new RecipeItem
            {
                Id = "r5",
                Title = "Mashed Potatoes",
                ShortDescription = "Creamy, buttery mashed potatoes",
                ImageFile = "mashtater.jpg",
                Ingredients = new List<string>
                {
                    "2 lbs potatoes, peeled and cut into chunks",
                    "1/2 cup milk",
                    "1/4 cup butter",
                    "Salt and pepper to taste"
                },
                Instructions =
                    "1. Boil potatoes in salted water until tender, about 15–20 minutes.\n" +
                    "2. Drain and return to pot.\n" +
                    "3. Mash potatoes and stir in butter and milk.\n" +
                    "4. Season with salt and pepper and serve warm.",
                PrepMinutes = 10,
                CookMinutes = 20
            },
            new RecipeItem
            {
                Id = "r6",
                Title = "Pumpkin Pie",
                ShortDescription = "Classic pumpkin pie with warm spices",
                ImageFile = "pumpkinpie.jpg",
                Ingredients = new List<string>
                {
                    "1 (9-inch) pie crust",
                    "1 can (15 oz) pumpkin puree",
                    "3/4 cup sugar",
                    "1/2 tsp salt",
                    "1 tsp cinnamon",
                    "1/2 tsp ginger",
                    "1/4 tsp nutmeg",
                    "2 large eggs",
                    "1 can (12 oz) evaporated milk"
                },
                Instructions =
                    "1. Preheat oven to 425°F (220°C).\n" +
                    "2. In a bowl, mix pumpkin puree, sugar, salt, and spices.\n" +
                    "3. Beat in eggs, then gradually stir in evaporated milk.\n" +
                    "4. Pour mixture into pie crust.\n" +
                    "5. Bake 15 minutes, then reduce oven to 350°F (175°C) and bake 40–50 minutes until set.\n" +
                    "6. Cool before serving.",
                PrepMinutes = 15,
                CookMinutes = 55
            },
            new RecipeItem
            {
                Id = "r7",
                Title = "Apple Pie",
                ShortDescription = "Classic apple pie with flaky crust",
                ImageFile = "applepie.jpg",
                Ingredients = new List<string>
                {
                    "1 pie crust (bottom)",
                    "1 pie crust (top)",
                    "6 cups apples, peeled and sliced",
                    "3/4 cup sugar",
                    "1 tsp cinnamon",
                    "1/4 tsp nutmeg",
                    "1 tbsp lemon juice",
                    "2 tbsp butter"
                },
                Instructions =
                    "1. Preheat oven to 375°F (190°C).\n" +
                    "2. Mix apples with sugar, cinnamon, nutmeg, and lemon juice.\n" +
                    "3. Place bottom pie crust in 9-inch pie pan. Pour apple mixture in and dot with butter.\n" +
                    "4. Cover with top crust, crimp edges, and cut small slits for steam.\n" +
                    "5. Bake 45–50 minutes until crust is golden and apples are tender.\n" +
                    "6. Cool slightly before serving.",
                PrepMinutes = 20,
                CookMinutes = 50
            }
        };

        public Task<IEnumerable<RecipeItem>> GetAllRecipesAsync() =>
            Task.FromResult(_recipes.AsEnumerable());

        public Task<RecipeItem?> GetRecipeByIdAsync(string id) =>
            Task.FromResult(_recipes.FirstOrDefault(r => r.Id == id));
    }
}
