using APIcook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public interface IRecipesService
    {
        IEnumerable<Recipe> GetRecipes();

        void AddRecipe(Recipe recipeItem);
        Recipe GetRecipeByID(int id);

        void UpdateRecipe(Recipe recipeItem);

        void DeleteRecipe(int id);
    }
}
