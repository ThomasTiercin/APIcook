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
    public class ProfessionalSkillsController : ControllerBase
    {
        private IProfessionalSkillsService _service;

        public ProfessionalSkillsController(IProfessionalSkillsService service)
        {
            _service = service;

        }

        [HttpGet("/api/ProfessionalSkills")]
        public ActionResult<List<ProfessionalSkills>> GetProfessionalSkills()
        {
            return _service.GetProfessionalSkills().ToList();
        }

        [HttpGet("/api/ProfessionalSkills/{id}")]
        public ActionResult<ProfessionalSkills> GetProfessionalSkillByID(int id)
        {
            return _service.GetProfessionalSkillByID(id);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("/api/ProfessionalSkills")]
        public ActionResult<ProfessionalSkills> AddProfessionalSkill(ProfessionalSkills professionalSkill)
        {
            _service.AddProfessionalSkill(professionalSkill);
            return professionalSkill;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("/api/ProfessionalSkills/{id}")]
        public ActionResult<ProfessionalSkills> UpdateProfessionalSkill(ProfessionalSkills professionalSkill)
        {
            _service.UpdateProfessionalSkill(professionalSkill);
            return professionalSkill;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("/api/ProfessionalSkills/{id}")]
        public ActionResult<int> DeleteProfessionalSkill(int id)
        {
            _service.DeleteProfessionalSkill(id);
            return id;
        }
    }
}
