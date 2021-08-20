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
    public class CertificationsController : ControllerBase
    {
        private ICertificationsService _service;

        public CertificationsController(ICertificationsService service)
        {
            _service = service;

        }

        [HttpGet("/api/Certifications")]
        public ActionResult<List<Certification>> GetCertifications()
        {
            return _service.GetCertifications().ToList();
        }

        [HttpGet("/api/Certifications/{id}")]
        public ActionResult<Certification> GetCertificationByID(int id)
        {
            return _service.GetCertificationByID(id);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("/api/Certifications")]
        public ActionResult<Certification> AddCertification(Certification certification)
        {
            _service.AddCertification(certification);
            return certification;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("/api/Certifications/{id}")]
        public ActionResult<Certification> UpdateCertification(Certification certification)
        {
            _service.UpdateCertification(certification);
            return certification;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("/api/Certifications/{id}")]
        public ActionResult<int> DeleteCertification(int id)
        {
            _service.DeleteCertification(id);
            return id;
        }
    }
}
