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
    public class RecipesController : ControllerBase
    {
        private IRecipesService _service;

        public RecipesController(IRecipesService service)
        {
            _service = service;

        }

        [HttpGet("/api/Recipes")]
        public ActionResult<List<Recipe>> GetRecipes()
        {
            return _service.GetRecipes().ToList();
        }

        [HttpGet("/api/Recipes/{id}")]
        public ActionResult<Recipe> GetRecipeByID(int id)
        {
            return _service.GetRecipeByID(id);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("/api/Recipes")]
        public ActionResult<Recipe> AddRecipe(Recipe recipe)
        {
            _service.AddRecipe(recipe);
            return recipe;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("/api/Recipes/{id}")]
        public ActionResult<Recipe> UpdateRecipe(Recipe recipe)
        {
            _service.UpdateRecipe(recipe);
            return recipe;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("/api/Recipes/{id}")]
        public ActionResult<int> DeleteRecipe(int id)
        {
            _service.DeleteRecipe(id);
            return id;
        }
    }
}
