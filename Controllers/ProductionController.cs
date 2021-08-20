using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductionsController : ControllerBase
    {
        private IProductionsService _service;

        public ProductionsController(IProductionsService service)
        {
            _service = service;

        }

        [HttpGet("/api/Productions")]
        public ActionResult<List<Production>> GetProductions()
        {
            return _service.GetProductions().ToList();
        }

        [HttpGet("/api/Productions/{id}")]
        public ActionResult<Production> GetProductionByID(int id)
        {
            return _service.GetProductionByID(id);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("/api/Productions")]
        public ActionResult<Production> AddProduction(Production production)
        {
            _service.AddProduction(production);
            return production;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("/api/Productions/{id}")]
        public ActionResult<Production> UpdateProduction(Production production)
        {
            _service.UpdateProduction(production);
            return production;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("/api/Productions/{id}")]
        public ActionResult<int> DeleteProduction(int id)
        {
            _service.DeleteProduction(id);
            return id;
        }
    }
}
