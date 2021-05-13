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
    public class IngredientsController : ControllerBase
    {
        private IIngredientsService _service;

        public IngredientsController(IIngredientsService service)
        {
            _service = service;

        }

        [HttpGet("/api/Ingredients")]
        public ActionResult<List<Ingredient>> GetIngredients()
        {
            return _service.GetIngredients().ToList();
        }

        [HttpGet("/api/Ingredients/{id}")]
        public ActionResult<Ingredient> GetIngredientByID(int id)
        {
            return _service.GetIngredientByID(id);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("/api/Ingredients")]
        public ActionResult<Ingredient> AddIngredient(Ingredient ingredient)
        {
            _service.AddIngredient(ingredient);
            return ingredient;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("/api/Ingredients/{id}")]
        public ActionResult<Ingredient> UpdateIngredient(Ingredient ingredient)
        {
            _service.UpdateIngredient(ingredient);
            return ingredient;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("/api/Ingredients/{id}")]
        public ActionResult<int> DeleteIngredient(int id)
        {
            _service.DeleteIngredient(id);
            return id;
        }
    }
}
