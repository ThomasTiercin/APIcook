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
    public class EducationsController : ControllerBase
    {
        private IEducationsService _service;

        public EducationsController(IEducationsService service)
        {
            _service = service;

        }

        [HttpGet("/api/Educations")]
        public ActionResult<List<Education>> GetEducations()
        {
            return _service.GetEducations().ToList();
        }

        [HttpGet("/api/Educations/{id}")]
        public ActionResult<Education> GetEducationByID(int id)
        {
            return _service.GetEducationByID(id);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("/api/Educations")]
        public ActionResult<Education> AddEducation(Education education)
        {
            _service.AddEducation(education);
            return education;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("/api/Educations/{id}")]
        public ActionResult<Education> UpdateEducation(Education education)
        {
            _service.UpdateEducation(education);
            return education;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("/api/Educations/{id}")]
        public ActionResult<int> DeleteEducation(int id)
        {
            _service.DeleteEducation(id);
            return id;
        }
    }
}
