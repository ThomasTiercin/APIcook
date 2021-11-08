using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIcook.Models;
using APIcook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIcook.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeInstructionController : ControllerBase
    {
        private IRecipeInstructionService _service;

        public RecipeInstructionController(IRecipeInstructionService service)
        {
            _service = service;

        }

        [HttpGet("/api/RecipeInstruction")]
        public ActionResult<List<RecipeInstruction>> GetRecipeInstruction()
        {
            return _service.GetRecipeInstruction().ToList();
        }

        [HttpGet("/api/RecipeInstruction/{id}")]
        public ActionResult<RecipeInstruction> GetRecipeInstructionByID(int id)
        {
            return _service.GetRecipeInstructionByID(id);
        }
        [HttpGet("/api/Recipe/{id}/RecipeInstruction")]
        public ActionResult<List<RecipeInstruction>> GetRecipeInstructionByRecipeId(int id)
        {
            return _service.GetRecipeInstructionByRecipeId(id).ToList();
        }
        [Authorize(Roles = "admin")]
        [HttpPost("/api/RecipeInstruction")]
        public ActionResult<RecipeInstruction> AddRecipeInstruction(RecipeInstruction RecipeInstruction)
        {
            _service.AddRecipeInstruction(RecipeInstruction);
            return RecipeInstruction;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("/api/RecipeInstruction/{id}")]
        public ActionResult<RecipeInstruction> UpdateRecipeInstruction(RecipeInstruction RecipeInstruction)
        {
            _service.UpdateRecipeInstruction(RecipeInstruction);
            return RecipeInstruction;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("/api/RecipeInstruction/{id}")]
        public ActionResult<int> DeleteRecipeInstruction(int id)
        {
            _service.DeleteRecipeInstruction(id);
            return id;
        }
    }
}
