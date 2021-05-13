using APIcook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly CookDbContext _dbContext;
        public IngredientsService(CookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteIngredient(int Id)
        {
            var ingredient = _dbContext.Ingredient.Find(Id);
            _dbContext.Ingredient.Remove(ingredient);
            Save();
        }

        public Ingredient GetIngredientByID(int Id)
        {
            return _dbContext.Ingredient.Find(Id);
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            return _dbContext.Ingredient.ToList();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            _dbContext.Add(ingredient);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            _dbContext.Entry(ingredient).State = EntityState.Modified;
            Save();
        }
    }
}
