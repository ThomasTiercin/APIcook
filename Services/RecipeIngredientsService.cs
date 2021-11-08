using APIcook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public class RecipeIngredientsService : IRecipeIngredientsService
    {
        private readonly CookDbContext _dbContext;
        public RecipeIngredientsService(CookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteRecipeIngredient(int Id)
        {
            var recipeIngredient = _dbContext.RecipeIngredient.Find(Id);
            _dbContext.RecipeIngredient.Remove(recipeIngredient);
            Save();
        }
    
        public RecipeIngredient GetRecipeIngredientByID(int Id)
        {
            return _dbContext.RecipeIngredient.Include(b => b.Ingredient).Include(b => b.Measure).Include(b => b.Recipe).FirstOrDefault(b => b.Id == Id);
        }
        public IEnumerable<RecipeIngredient> GetRecipeIngredientByRecipeId(int Id)
        {
            return _dbContext.RecipeIngredient.Include(b => b.Ingredient).Include(b => b.Measure).Include(b => b.Recipe).Where(b => b.RecipeId == Id);
        }
        
        public IEnumerable<RecipeIngredient> GetRecipeIngredients()
        {
            return _dbContext.RecipeIngredient.Include(r => r.Ingredient).Include(r => r.Measure).Include(r => r.Recipe);
        }

        public void AddRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            _dbContext.Add(recipeIngredient);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            _dbContext.Entry(recipeIngredient).State = EntityState.Modified;
            Save();
        }
    }
}
