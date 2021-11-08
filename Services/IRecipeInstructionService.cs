using APIcook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public interface IRecipeInstructionService
    {
        IEnumerable<RecipeInstruction> GetRecipeInstruction();

        void AddRecipeInstruction(RecipeInstruction RecipeInstructionItem);
        RecipeInstruction GetRecipeInstructionByID(int id);
        IEnumerable<RecipeInstruction> GetRecipeInstructionByRecipeId(int id);
        
        void UpdateRecipeInstruction(RecipeInstruction RecipeInstructionItem);

        void DeleteRecipeInstruction(int id);
    }
}
