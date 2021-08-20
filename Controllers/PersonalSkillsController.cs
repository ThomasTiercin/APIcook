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
    public class PersonalSkillsController : ControllerBase
    {
        private IPersonalSkillsService _service;

        public PersonalSkillsController(IPersonalSkillsService service)
        {
            _service = service;

        }

        [HttpGet("/api/PersonalSkills")]
        public ActionResult<List<PersonalSkills>> GetPersonalSkills()
        {
            return _service.GetPersonalSkills().ToList();
        }

        [HttpGet("/api/PersonalSkills/{id}")]
        public ActionResult<PersonalSkills> GetPersonalSkillByID(int id)
        {
            return _service.GetPersonalSkillByID(id);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("/api/PersonalSkills")]
        public ActionResult<PersonalSkills> AddPersonalSkill(PersonalSkills personalSkill)
        {
            _service.AddPersonalSkill(personalSkill);
            return personalSkill;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("/api/PersonalSkills/{id}")]
        public ActionResult<PersonalSkills> UpdatePersonalSkill(PersonalSkills personalSkill)
        {
            _service.UpdatePersonalSkill(personalSkill);
            return personalSkill;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("/api/PersonalSkills/{id}")]
        public ActionResult<int> DeletePersonalSkill(int id)
        {
            _service.DeletePersonalSkill(id);
            return id;
        }
    }
}
