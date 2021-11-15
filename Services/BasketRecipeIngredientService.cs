using APIcook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<RecipeIngredient> GetBasketRecipeIngredientGroupBy(int userId)
        {
            var result = (
                from a in _dbContext.RecipeIngredient join b in _dbContext.BasketRecipeIngredient on a.Id equals b.RecipeIngredientId join c in _dbContext.Basket on b.BasketId equals c.Id
                where b.Visible == true 
                where b.UserId == userId
                group a by new {a.IngredientId, a.MeasureId} into grp
                select new  RecipeIngredient {
                    IngredientId = grp.Key.IngredientId,
                    MeasureId = grp.Key.MeasureId,
                    Amount = grp.Sum(s=>s.Amount)
                }  
            ).ToList();
            return result;
            
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

        public void UpdateBasketByIngredientMeasure(int ingredientId, int measureId, int userId)
        {
            var result = (
                from a in _dbContext.BasketRecipeIngredient join b in _dbContext.RecipeIngredient on a.RecipeIngredientId equals b.Id
                where a.Visible == true 
                where a.UserId == userId
                where b.IngredientId == ingredientId
				where b.MeasureId == measureId
                select new  BasketRecipeIngredient {
                    Id = a.Id,
                    Visible = a.Visible,
                    BasketId = a.BasketId,
                    RecipeIngredientId = a.RecipeIngredientId,
                    UserId = a.UserId
                }  
            ).ToList();
            foreach(var item in result)
            {
                item.Visible=false;
                _dbContext.Entry(item).State = EntityState.Modified;
            }
            
            Save();
        }
    }
}
