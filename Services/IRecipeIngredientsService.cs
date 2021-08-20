using APIcook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public interface IRecipeIngredientsService
    {
        IEnumerable<RecipeIngredient> GetRecipeIngredients();

        void AddRecipeIngredient(RecipeIngredient recipeIngredientItem);
        RecipeIngredient GetRecipeIngredientByID(int id);

        void UpdateRecipeIngredient(RecipeIngredient recipeIngredientItem);

        void DeleteRecipeIngredient(int id);
    }
}
