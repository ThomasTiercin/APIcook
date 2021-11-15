using APIcook.Models;
using System;
using System.Collections.Generic;

namespace APIcook.Services
{
    public interface IBasketRecipeIngredientService
    {
        IEnumerable<BasketRecipeIngredient> GetBasketRecipeIngredient();

        void AddBasketRecipeIngredient(IEnumerable<BasketRecipeIngredient> BasketRecipeIngredients);
        BasketRecipeIngredient GetBasketRecipeIngredientByID(int id);
        IEnumerable<BasketRecipeIngredient> GetBasketRecipeIngredientByUserId(int id);
        List<RecipeIngredient> GetBasketRecipeIngredientGroupBy(int id);
        void UpdateBasketRecipeIngredient(BasketRecipeIngredient BasketRecipeIngredientItem);
        
        void UpdateBasketByIngredientMeasure(int ingredientId, int measureId, int userId);

        void DeleteBasketRecipeIngredient(int id, Boolean visible);
    }
}
