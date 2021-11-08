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
    public class BasketController : ControllerBase
    {
        private IBasketService _service;

        public BasketController(IBasketService service)
        {
            _service = service;

        }

        [HttpGet("/api/Basket")]
        public ActionResult<List<Basket>> GetBasket()
        {
            return _service.GetBasket().ToList();
        }

        [HttpGet("/api/Basket/{id}")]
        public ActionResult<Basket> GetBasketByID(int id)
        {
            return _service.GetBasketByID(id);
        }
        [HttpGet("/api/User/{id}/Basket")]
        public ActionResult<List<Basket>> GetBasketByUserId(int id)
        {
            return _service.GetBasketByUserId(id).ToList();
        }
        [Authorize(Roles = "admin")]
        [HttpPost("/api/Basket")]
        public ActionResult<Basket> AddBasket(Basket Basket)
        {
            _service.AddBasket(Basket);
            return Basket;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("/api/Basket/{id}")]
        public ActionResult<Basket> UpdateBasket(Basket Basket)
        {
            _service.UpdateBasket(Basket);
            return Basket;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("/api/Basket/{id}")]
        public ActionResult<int> DeleteBasket(int id)
        {
            _service.DeleteBasket(id);
            return id;
        }
    }
}
