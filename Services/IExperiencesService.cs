using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IExperiencesService
    {
        IEnumerable<Experience> GetExperiences();

        void AddExperience(Experience experienceItem);
        Experience GetExperienceByID(int id);

        void UpdateExperience(Experience experienceItem);

        void DeleteExperience(int id);
    }
}
