using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ICertificationsService
    {
        IEnumerable<Certification> GetCertifications();

        void AddCertification(Certification certificationItem);
        Certification GetCertificationByID(int id);

        void UpdateCertification(Certification certificationItem);

        void DeleteCertification(int id);
    }
}
