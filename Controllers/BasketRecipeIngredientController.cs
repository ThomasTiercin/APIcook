using System;
using System.Collections.Generic;
using System.Linq;
using APIcook.Models;
using APIcook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIcook.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketRecipeIngredientController : ControllerBase
    {
        private IBasketRecipeIngredientService _service;

        public BasketRecipeIngredientController(IBasketRecipeIngredientService service)
        {
            _service = service;

        }

        [HttpGet("/api/BasketRecipeIngredient")]
        public ActionResult<List<BasketRecipeIngredient>> GetBasketRecipeIngredient()
        {
            return _service.GetBasketRecipeIngredient().ToList();
        }

        [HttpGet("/api/BasketRecipeIngredient/{id}")]
        public ActionResult<BasketRecipeIngredient> GetBasketRecipeIngredientByID(int id)
        {
            return _service.GetBasketRecipeIngredientByID(id);
        }
        [HttpGet("/api/User/{id}/BasketRecipeIngredient")]
        public ActionResult<List<BasketRecipeIngredient>> GetBasketRecipeIngredientByUserId(int id)
        {
            return _service.GetBasketRecipeIngredientByUserId(id).ToList();
        }
        [HttpGet("/api/User/{id}/BasketRecipeIngredientGroupBy")]
        public ActionResult<List<RecipeIngredient>> GetBasketRecipeIngredientGroupBy(int id)
        {
            return _service.GetBasketRecipeIngredientGroupBy(id).ToList();
        }
        [Authorize(Roles = "admin")]
        [HttpPost("/api/BasketRecipeIngredient")]
        public ActionResult<List<BasketRecipeIngredient>> AddBasketRecipeIngredient(IEnumerable<BasketRecipeIngredient> BasketRecipeIngredients)
        {
            _service.AddBasketRecipeIngredient(BasketRecipeIngredients);
            return BasketRecipeIngredients.ToList();
        }
        [Authorize(Roles = "admin")]
        [HttpPut("/api/BasketRecipeIngredient/{id}")]
        public ActionResult<BasketRecipeIngredient> UpdateBasketRecipeIngredient(BasketRecipeIngredient BasketRecipeIngredient)
        {
            _service.UpdateBasketRecipeIngredient(BasketRecipeIngredient);
            return BasketRecipeIngredient;
        }
        [Authorize(Roles = "admin")]
        [HttpGet("/api/BasketRecipeIngredient/ingredient/{ingredientId}/measure/{measureId}/user/{userId}")]
        public Boolean UpdateBasketByIngredientMeasure(int ingredientId, int measureId, int userId)
        {
            _service.UpdateBasketByIngredientMeasure(ingredientId,measureId,userId);
            return true;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("/api/BasketRecipeIngredient/{id}/{visible}")]
        public ActionResult<int> DeleteBasketRecipeIngredient(int id, Boolean visible)
        {
            _service.DeleteBasketRecipeIngredient(id, visible);
            return id;
        }
    }
}
