using System;
using System.Collections.Generic;
using System.Linq;
using APIcook.Models;
using APIcook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace APIcook.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class MeasuresController : ControllerBase
    {
        private IMeasuresService _service;

        public MeasuresController(IMeasuresService service)
        {
            _service = service;

        }

        [HttpGet("/api/Measures")]
        public ActionResult<List<Measure>> GetMeasures()
        {
            return _service.GetMeasures().ToList();
        }

        [HttpGet("/api/Measures/{id}")]
        public ActionResult<Measure> GetMeasureByID(int id)
        {
            return _service.GetMeasureByID(id);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("/api/Measures")]
        public ActionResult<Measure> AddMeasure(Measure measure)
        {
            _service.AddMeasure(measure);
            return measure;
        }

        [Authorize(Roles = "admin")]
        [HttpPut("/api/Measures/{id}")]
        public ActionResult<Measure> UpdateMeasure(Measure measure)
        {
            _service.UpdateMeasure(measure);
            return measure;
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("/api/Measures/{id}")]
        public ActionResult<int> DeleteMeasure(int id)
        {
            _service.DeleteMeasure(id);
            return id;
        }
    }
}
