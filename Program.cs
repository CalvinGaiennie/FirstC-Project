using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace MyProgram
{
    public class NewClass
    {
        public static void Main(string[] args)
        {
            string[] allIngredients = { "sliced bread", "ground beef", "egg", "cheese", "lettuce", "tomato", "onion", "olive oil", "bacon", "butter", "chicken", "vinegar", "mayonnaise", "red onion", "potato", "salt", "pepper", "milk", "celery" };
            string[] breakfastPlate = { "sliced bread", "egg", "cheese", "butter", "bacon" };
            string[] burger = { "sliced bread", "ground beef", "lettuce", "tomato", "onion"};
            string[] salad = { "lettuce", "tomato", "onion", "olive oil", "vinegar" };
            string[] chickenSandwich = { "sliced bread", "chicken", "lettuce", "tomato", };
            string[] grilledChickenSalad = { "chicken", "lettuce", "tomato", "onion" };
            string[] chickenSalad = { "chicken", "vinegar", "mayonnaise", "red onion", "celery" };
            string[] potatoSalad = { "potato", "salt", "pepper", "milk", "celery" };



            string ingredientList = string.Join("\n", allIngredients.Select((item, index) => $"{index + 1}. {item}"));
            Console.WriteLine("Ingredients: \n" + ingredientList);

            Console.Write("list the number of any ingredients you have available: ");
            string input = Console.ReadLine();
            string[] inputArray = input.Split(',');
            List<int> inputList = inputArray.Select(int.Parse).ToList();
            List<string> ingredients = inputList.Select(index => allIngredients[index - 1]).ToList();
            
            // Add method to check recipes
            CheckRecipe(ingredients, breakfastPlate, "Breakfast Plate");
            CheckRecipe(ingredients, burger, "Burger");
            CheckRecipe(ingredients, salad, "Salad");
            CheckRecipe(ingredients, chickenSandwich, "Chicken Sandwich");
            CheckRecipe(ingredients, grilledChickenSalad, "Grilled Chicken Salad");
            CheckRecipe(ingredients, chickenSalad, "Chicken Salad");
            CheckRecipe(ingredients, potatoSalad, "Potato Salad");
        }

        private static void CheckRecipe(List<string> availableIngredients, string[] recipe, string recipeName)
        {
            bool canMake = recipe.All(ingredient => availableIngredients.Contains(ingredient));
            if (canMake)
            {
                string message = $"You can make a {recipeName}! with the following ingredients: {string.Join(", ", recipe)}";
                Console.WriteLine(message);
                
                // Create recipe object
                var recipeResult = new
                {
                    Name = recipeName,
                    CanMake = true,
                    Ingredients = recipe
                };

                // Convert to JSON and append to file
                string jsonString = System.Text.Json.JsonSerializer.Serialize(recipeResult, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                File.AppendAllText("recipes.json", jsonString + Environment.NewLine);
            }
        }
    }
}