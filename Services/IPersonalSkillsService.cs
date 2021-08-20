using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IPersonalSkillsService
    {
        IEnumerable<PersonalSkills> GetPersonalSkills();

        void AddPersonalSkill(PersonalSkills personalSkillItem);
        PersonalSkills GetPersonalSkillByID(int id);

        void UpdatePersonalSkill(PersonalSkills personalSkillItem);

        void DeletePersonalSkill(int id);
    }
}
