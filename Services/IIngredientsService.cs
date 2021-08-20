using APIcook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public interface IIngredientsService
    {
        IEnumerable<Ingredient> GetIngredients();

        void AddIngredient(Ingredient ingredientItem);
        Ingredient GetIngredientByID(int id);

        void UpdateIngredient(Ingredient ingredientItem);

        void DeleteIngredient(int id);
    }
}
