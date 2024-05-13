// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{//ingredient class
    class Ingredient
    {//ingredients properties
        public string Name { get; set; } = "";//added ingredient name
        public double Quantity { get; set; } // Added Quantity property
        public double Calories { get; set; }//added ingredient calories
        public string? FoodGroup { get; set; }//added ingredient food group
    }

    class Recipe
    {
        public string Name { get; set; } = "";
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> Steps { get; set; } = new List<string>();
    }
    //The class that is responsible for the management of recipes.
    class RecipeManager
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();

            // method to add a pre-existing recipes.
            Recipe existingRecipe = new Recipe
            {
                Name = "Creamy Mashed Potatoes and Grilled Chicken Wings",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Potatoes", Quantity = 4, Calories = 200 }, 
                    new Ingredient { Name = "Milk", Quantity = 1, Calories = 250 }, 
                    new Ingredient { Name = "Cheese", Quantity = 1, Calories = 100 }, 
                    new Ingredient { Name = "Salt and Pepper", Quantity = 1, Calories = 150 }, 
                    new Ingredient { Name = "Chicken Wings", Quantity = 10, Calories = 150 },
                    new Ingredient { Name = "Spices of Choice", Quantity = 5, Calories = 150 },
                    new Ingredient { Name = "Mayo", Quantity = 1, Calories = 150 },
                    new Ingredient { Name = "Nando's hot sauce", Quantity = 1, Calories = 150 } 
                },
                Steps = new List<string>
                {
                    "Marinate chicken wings using mayo, Nando’s hot sauce and spices.Set aside for an hour.",
                    "Grill at 180 degrees for 20 minutes",
                    "In a hot pan, add sauces used above, let it simmer a bit.",
                    "Toss your grilled chicken inside and let simmer for a while.",
                    "\r\nReady to Serve",
                    "Mashed Potatoes:",
                    " Peel and dice your potatoes.",
                    "In a pot with water, add salt and boil until soft.",
                    "Drain water out and add the milk and cheese. Mix and it’s Ready to serve."

                }
            };

            recipes.Add(existingRecipe);
        }
        //Method to add new recipes on the software
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }
        //Method to display all the recipes that are available.
        public void DisplayRecipes()
        {
            Console.WriteLine("\nAvailable Recipes:");
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }
            Console.WriteLine();
        }
        //method to display the detailed properties of a certain recipe.
        public void DisplayRecipeDetails(string recipeName)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            if (recipe != null)
            {
                Console.WriteLine($"Recipe: {recipe.Name}");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {GetUnit(ingredient.Name)} - {ingredient.Calories} calories - Food Group: {ingredient.FoodGroup ?? "N/A"}");
                }
                Console.WriteLine("\nSteps:");
                foreach (var step in recipe.Steps)
                {
                    Console.WriteLine(step);
                }
                Console.WriteLine($"Total Calories: {recipe.Ingredients.Sum(i => i.Calories)}");
                if (recipe.Ingredients.Sum(i => i.Calories) > 300)
                {
                    Console.WriteLine("Warning: This recipe exceeds 300 calories.");
                }
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
        //method to clear all th available recipes.
        public void ClearRecipes()
        {
            recipes.Clear();
            Console.WriteLine("All recipes cleared.");
        }

        // Method to get the unit based on ingredient name
        private string GetUnit(string ingredientName)
        {
            
            return "grams";
        }

        // Method to scale the ingredients of a recipe
        public void ScaleRecipe(string recipeName, double scaleFactor)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            if (recipe != null)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    // Scale the quantity of each ingredient
                    ingredient.Quantity *= scaleFactor;
                }
                Console.WriteLine("Recipe scaled successfully!");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
    }
    //this the main program class.
    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();

            while (true)
            {
                Console.WriteLine("***********************************************************************************************");
                Console.WriteLine("Welcome To The Kitchen With Zoxolo");
                Console.WriteLine("***********************************************************************************************");

                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Enter New Recipe");
                Console.WriteLine("2. View Recipes");
                Console.WriteLine("3. Clear All Recipes");
                Console.WriteLine("4. Exit");
                Console.WriteLine("5. Scale a Recipe");
                Console.WriteLine("***********************************************************************************************");
                Console.Write("\nEnter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        EnterNewRecipe(recipeManager);
                        break;
                    case 2:
                        recipeManager.DisplayRecipes();
                        Console.Write("\nEnter the name of the recipe you want to view or press Enter to return to the menu: ");
                        string recipeName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(recipeName))
                        {
                            recipeManager.DisplayRecipeDetails(recipeName);
                        }
                        break;
                    case 3:
                        recipeManager.ClearRecipes();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    case 5:
                        ScaleRecipe(recipeManager);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }

        static void EnterNewRecipe(RecipeManager recipeManager)
        {
            Recipe recipe = new Recipe();
            Console.Write("Enter the name of the recipe: ");
            recipe.Name = Console.ReadLine();

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Ingredient ingredient = new Ingredient();
                Console.Write("Name: ");
                ingredient.Name = Console.ReadLine();
                Console.Write("Quantity: ");
                ingredient.Quantity = Convert.ToDouble(Console.ReadLine());
                Console.Write("Calories: ");
                ingredient.Calories = Convert.ToDouble(Console.ReadLine());
                Console.Write("Food Group: ");
                ingredient.FoodGroup = Console.ReadLine();
                recipe.Ingredients.Add(ingredient);
            }

            Console.Write("\nEnter the number of steps: ");
            int numSteps = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                recipe.Steps.Add(Console.ReadLine());
            }

            recipeManager.AddRecipe(recipe);

            Console.WriteLine("\nRecipe added successfully!\n");
        }

        static void ScaleRecipe(RecipeManager recipeManager)
        {
            Console.Write("\nEnter the name of the recipe you want to scale: ");
            string recipeName = Console.ReadLine();
            Console.Write("Enter the scaling factor (e.g., 1.5 for 150%): ");
            double scaleFactor = Convert.ToDouble(Console.ReadLine());
            recipeManager.ScaleRecipe(recipeName, scaleFactor);
        }
    }
}

