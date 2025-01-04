using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProgram
{
    public class NewClass
    {
        public static void Main(string[] args)
        {
            string[] allIngredients = { "sliced bread", "ground beef", "egg", "cheese", "lettuce", "tomato", "onion", "olive oil", "bacon", "butter", "chicken" };
            string[] breakfastPlate = { "sliced bread", "egg", "cheese", "butter", "bacon" };
            string[] burger = { "sliced bread", "ground beef", "lettuce", "tomato", "onion", "olive oil" };
            string[] salad = { "lettuce", "tomato", "onion" };
            string[] chickenSandwich = { "sliced bread", "chicken", "lettuce", "tomato", };


            string ingredientList = string.Join("\n", allIngredients.Select((item, index) => $"{index + 1}. {item}"));
            Console.WriteLine("Ingredients: \n" + ingredientList);

            Console.Write("list the number of any ingredients you have available: ");
        }
    }
}