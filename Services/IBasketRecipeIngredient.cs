using APIcook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public interface IBasketRecipeIngredientService
    {
        IEnumerable<BasketRecipeIngredient> GetBasketRecipeIngredient();

        void AddBasketRecipeIngredient(IEnumerable<BasketRecipeIngredient> BasketRecipeIngredients);
        BasketRecipeIngredient GetBasketRecipeIngredientByID(int id);
        IEnumerable<BasketRecipeIngredient> GetBasketRecipeIngredientByUserId(int id);
        
        void UpdateBasketRecipeIngredient(BasketRecipeIngredient BasketRecipeIngredientItem);

        void DeleteBasketRecipeIngredient(int id, Boolean visible);
    }
}
