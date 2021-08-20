using APIcook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly CookDbContext _dbContext;
        public RecipesService(CookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteRecipe(int Id)
        {
            var recipe = _dbContext.Recipe.Find(Id);
            _dbContext.Recipe.Remove(recipe);
            Save();
        }

        public Recipe GetRecipeByID(int Id)
        {
            return _dbContext.Recipe.Find(Id);
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return _dbContext.Recipe.ToList();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipe.CreatedDate = DateTime.Now;
            _dbContext.Add(recipe);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _dbContext.Entry(recipe).State = EntityState.Modified;
            Save();
        }
    }
}
