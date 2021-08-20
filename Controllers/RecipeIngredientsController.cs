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
    public class RecipeIngredientsController : ControllerBase
    {
        private IRecipeIngredientsService _service;

        public RecipeIngredientsController(IRecipeIngredientsService service)
        {
            _service = service;

        }

        [HttpGet("/api/RecipeIngredients")]
        public ActionResult<List<RecipeIngredient>> GetRecipeIngredients()
        {
            return _service.GetRecipeIngredients().ToList();
        }

        [HttpGet("/api/RecipeIngredients/{id}")]
        public ActionResult<RecipeIngredient> GetRecipeIngredientByID(int id)
        {
            return _service.GetRecipeIngredientByID(id);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("/api/RecipeIngredients")]
        public ActionResult<RecipeIngredient> AddRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            _service.AddRecipeIngredient(recipeIngredient);
            return recipeIngredient;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("/api/RecipeIngredients/{id}")]
        public ActionResult<RecipeIngredient> UpdateRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            _service.UpdateRecipeIngredient(recipeIngredient);
            return recipeIngredient;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("/api/RecipeIngredients/{id}")]
        public ActionResult<int> DeleteRecipeIngredient(int id)
        {
            _service.DeleteRecipeIngredient(id);
            return id;
        }
    }
}
