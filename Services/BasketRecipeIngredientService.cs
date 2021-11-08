using APIcook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public class BasketRecipeIngredientService : IBasketRecipeIngredientService
    {
        private readonly CookDbContext _dbContext;
        public BasketRecipeIngredientService(CookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteBasketRecipeIngredient(int Id, Boolean visible)
        {
            var BasketRecipeIngredient = _dbContext.BasketRecipeIngredient.Find(Id);
            BasketRecipeIngredient.Visible = visible;
            _dbContext.Entry(BasketRecipeIngredient).State = EntityState.Modified;
            Save();
        }
    
        public BasketRecipeIngredient GetBasketRecipeIngredientByID(int Id)
        {
            return _dbContext.BasketRecipeIngredient.Include(b => b.User).Include(b => b.Basket).Include(b => b.RecipeIngredient).FirstOrDefault(b => b.Id == Id);
        }
        public IEnumerable<BasketRecipeIngredient> GetBasketRecipeIngredientByUserId(int Id)
        {
            return _dbContext.BasketRecipeIngredient
                    .Include(b => b.User)
                    .Include(b => b.Basket)
                    .Include(b => b.RecipeIngredient).ThenInclude(c => c.Recipe)
                    .Include(b => b.RecipeIngredient).ThenInclude(c => c.Measure)
                    .Include(b => b.RecipeIngredient).ThenInclude(c => c.Ingredient)
                    .Where(b => b.UserId == Id);
        }
        
        public IEnumerable<BasketRecipeIngredient> GetBasketRecipeIngredient()
        {
            return _dbContext.BasketRecipeIngredient.Include(r => r.RecipeIngredient).Include(b => b.Basket).Include(b => b.User);
        }

        public void AddBasketRecipeIngredient(IEnumerable<BasketRecipeIngredient> BasketRecipeIngredients)
        {
            _dbContext.AddRange(BasketRecipeIngredients);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBasketRecipeIngredient(BasketRecipeIngredient BasketRecipeIngredient)
        {
            _dbContext.Entry(BasketRecipeIngredient).State = EntityState.Modified;
            Save();
        }
    }
}
