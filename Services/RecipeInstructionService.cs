using APIcook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public class RecipeInstructionService : IRecipeInstructionService
    {
        private readonly CookDbContext _dbContext;
        public RecipeInstructionService(CookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteRecipeInstruction(int Id)
        {
            var RecipeInstruction = _dbContext.RecipeInstruction.Find(Id);
            _dbContext.RecipeInstruction.Remove(RecipeInstruction);
            Save();
        }
    
        public RecipeInstruction GetRecipeInstructionByID(int Id)
        {
            return _dbContext.RecipeInstruction.Include(b => b.Recipe).FirstOrDefault(b => b.Id == Id);
        }
        public IEnumerable<RecipeInstruction> GetRecipeInstructionByRecipeId(int Id)
        {
            return _dbContext.RecipeInstruction.Include(b => b.Recipe).Where(b => b.RecipeId == Id);
        }
        
        public IEnumerable<RecipeInstruction> GetRecipeInstruction()
        {
            return _dbContext.RecipeInstruction.Include(r => r.Recipe);
        }

        public void AddRecipeInstruction(RecipeInstruction RecipeInstruction)
        {
            _dbContext.Add(RecipeInstruction);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateRecipeInstruction(RecipeInstruction RecipeInstruction)
        {
            _dbContext.Entry(RecipeInstruction).State = EntityState.Modified;
            Save();
        }
    }
}
