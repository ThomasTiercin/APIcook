using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IEducationsService
    {
        IEnumerable<Education> GetEducations();

        void AddEducation(Education educationItem);
        Education GetEducationByID(int id);

        void UpdateEducation(Education educationItem);

        void DeleteEducation(int id);
    }
}
