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
    public class ExperiencesController : ControllerBase
    {
        private IExperiencesService _service;

        public ExperiencesController(IExperiencesService service)
        {
            _service = service;

        }

        [HttpGet("/api/Experiences")]
        public ActionResult<List<Experience>> GetExperiences()
        {
            return _service.GetExperiences().ToList();
        }

        [HttpGet("/api/Experiences/{id}")]
        public ActionResult<Experience> GetExperienceByID(int id)
        {
            return _service.GetExperienceByID(id);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("/api/Experiences")]
        public ActionResult<Experience> AddExperience(Experience experience)
        {
            _service.AddExperience(experience);
            return experience;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("/api/Experiences/{id}")]
        public ActionResult<Experience> UpdateExperience(Experience experience)
        {
            _service.UpdateExperience(experience);
            return experience;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("/api/Experiences/{id}")]
        public ActionResult<int> DeleteExperience(int id)
        {
            _service.DeleteExperience(id);
            return id;
        }
    }
}
