using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IProfessionalSkillsService
    {
        IEnumerable<ProfessionalSkills> GetProfessionalSkills();

        void AddProfessionalSkill(ProfessionalSkills professionalSkillItem);
        ProfessionalSkills GetProfessionalSkillByID(int id);

        void UpdateProfessionalSkill(ProfessionalSkills professionalSkillItem);

        void DeleteProfessionalSkill(int id);
    }
}
