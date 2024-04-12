// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    class Recipe
    {
        private List<(string name, string[] details)> recipes;

        public Recipe()
        {
            recipes = new List<(string name, string[] details)>();
        }

        // Method to input recipe details
        public void InputRecipe()
        {
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();

            string[] newRecipe = new string[2]; // Array to hold ingredients and steps
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = Convert.ToInt32(Console.ReadLine());
            string[] ingredients = new string[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();
                Console.Write("Quantity: ");
                string quantity = Console.ReadLine();
                Console.Write("Unit of Measurement: ");
                string unit = Console.ReadLine();
                ingredients[i] = $"{quantity} {unit} of {ingredientName}";
            }
            newRecipe[0] = string.Join(";", ingredients); // Store ingredients as a single string separated by semicolon

            Console.Write("\nEnter the number of steps: ");
            int numSteps = Convert.ToInt32(Console.ReadLine());
            string[] steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                steps[i] = Console.ReadLine();
            }
            newRecipe[1] = string.Join(";", steps); // Store steps as a single string separated by semicolon

            recipes.Add((name, newRecipe)); // Add new recipe to the list with name
        }

        // Method to display all recipes
        public void DisplayRecipes()
        {
            Console.WriteLine("\nAvailable Recipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"Recipe {i + 1}: {recipes[i].name}");
            }
            Console.WriteLine();
        }

        // Method to display a single recipe
        public void DisplayRecipe(int index)
        {
            Console.WriteLine($"Recipe: {recipes[index].name}");
            string[] recipe = recipes[index].details;
            Console.WriteLine("Ingredients:");
            string[] ingredients = recipe[0].Split(';');
            foreach (string ingredient in ingredients)
            {
                Console.WriteLine(ingredient);
            }
            Console.WriteLine("\nSteps:");
            string[] steps = recipe[1].Split(';');
            for (int j = 0; j < steps.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {steps[j]}");
            }
            Console.WriteLine();
        }

        // Method to clear all data
        public void ClearData()
        {
            recipes.Clear();
            Console.WriteLine("All data cleared.");
        }

        // Method to add a pre-existing recipe
        public void AddRecipe(string name, string[] recipe)
        {
            recipes.Add((name, recipe));
        }

        // Method to scale a recipe by a given factor
        public void ScaleRecipe(int index, double factor)
        {
            string[] recipe = recipes[index].details;
            string[] ingredients = recipe[0].Split(';');
            for (int i = 0; i < ingredients.Length; i++)
            {
                string ingredient = ingredients[i];
                string[] parts = ingredient.Split(' ');
                double quantity = Convert.ToDouble(parts[0]);
                string unit = parts[1];
                double scaledQuantity = quantity * factor;
                ingredients[i] = $"{scaledQuantity} {unit} of {string.Join(' ', parts.Skip(2))}";
            }
            recipe[0] = string.Join(";", ingredients);
            recipes[index] = (recipes[index].name, recipe);
        }

        // Method to get the number of recipes
        public int GetRecipeCount()
        {
            return recipes.Count;
        }

        // Method to get the name of a recipe by index
        public string GetRecipeName(int index)
        {
            return recipes[index].name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            // Add a sample recipe
            string[] sampleRecipe = new string[2];
            sampleRecipe[0] = "Potatoes, Milk, Cheese, Salt and Paper, Chicken Wings, Spices of Choice, Mayo, Nando’s hot sauce";
            sampleRecipe[1] = "Marinate chicken wings using mayo, Nando’s hot sauce and spices. Set aside for an hour. Grill at 180 degrees for 20 minutes, In a hot pan, add sauces used above, let it simmer a bit. Toss your grilled chicken inside and let simmer for a while." +
                "Ready to Serve\r\n\r\nMashed Potatoes:\r\nPeel and dice your potatoes. \r\nIn a pot with water, add salt and boil until soft. \r\nDrain water out and add the milk and cheese. Mix and it’s Ready to serve\r\n\r\nPlate and Serve!!!";
            recipe.AddRecipe("Creamy Mashed Potatoes and Grilled Chicken wings.\nIngredients:\r\nPotatoes\r\nMilk\r\nCheese\r\nSalt and Paper\r\nChicken Wings\r\nSpices of Choice\r\nMayo\r\nNando’s hot sauce.\r\n" +
                "\nSteps:\r\nMarinate chicken wings using mayo.\r\nNando’s hot sauce and spices. \r\nSet aside for an hour.\r\nGrill at 180 degrees for 20 minutes \r\nIn a hot pan, add sauces used above, let it simmer a bit.\r\nToss your grilled chicken inside and let simmer for a while.\n" +
                "\r\nReady to Serve:\r\nMashed Potatoes:\r\nPeel and dice your potatoes. \r\nIn a pot with water, add salt and boil until soft. \r\nDrain water out and add the milk and cheese. Mix and it’s Ready to serve\r\n\r\nPlate and Serve!!!", sampleRecipe); // Added the name "Creamy Mashed Potatoes and Grilled Chicken wings" here

            while (true)
            {
                Console.WriteLine("***********************************************************************************************");
                Console.WriteLine("Welcome To The Ktchen With Zoxolo");
                Console.WriteLine("***********************************************************************************************");


                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Enter New Recipe");
                Console.WriteLine("2. View Recipes");
                Console.WriteLine("3. Clear All Data");
                Console.WriteLine("4. Exit");
                Console.WriteLine("5. Scale a Recipe");
                Console.WriteLine("***********************************************************************************************");
                Console.Write("\nEnter your choice: ");


                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe.InputRecipe();
                        break;
                    case 2:
                        recipe.DisplayRecipes();
                        break;
                    case 3:
                        recipe.ClearData();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    case 5:
                        Console.Write("Enter the index of the recipe you want to scale: ");
                        int index = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.Write("Enter the scaling factor (0.5 for half, 2 for double, 3 for triple): ");
                        double factor = Convert.ToDouble(Console.ReadLine());
                        recipe.ScaleRecipe(index, factor);
                        Console.WriteLine($"Recipe {index + 1} scaled by a factor of {factor}.");
                        break;
                    case 6:
                        // Display the specific recipe "Creamy Mashed Potatoes and Grilled Chicken wings"
                        int recipeIndex = -1;
                        for (int i = 0; i < recipe.GetRecipeCount(); i++)
                        {
                            if (recipe.GetRecipeName(i) == "Creamy Mashed Potatoes and Grilled Chicken wings")
                            {
                                recipeIndex = i;
                                break;
                            }
                        }
                        if (recipeIndex != -1)
                        {
                            recipe.DisplayRecipe(recipeIndex);
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }
    }
}
