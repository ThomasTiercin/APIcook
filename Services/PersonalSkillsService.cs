using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class PersonalSkillsService : IPersonalSkillsService
    {
        private readonly PortfolioDbContext _dbContext;
        public PersonalSkillsService(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeletePersonalSkill(int Id)
        {
            var personalSkill = _dbContext.PersonalSkills.Find(Id);
            _dbContext.PersonalSkills.Remove(personalSkill);
            Save();
        }

        public PersonalSkills GetPersonalSkillByID(int Id)
        {
            return _dbContext.PersonalSkills.Find(Id);
        }

        public IEnumerable<PersonalSkills> GetPersonalSkills()
        {
            return _dbContext.PersonalSkills.ToList();
        }

        public void AddPersonalSkill(PersonalSkills personalSkill)
        {
            _dbContext.Add(personalSkill);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdatePersonalSkill(PersonalSkills personalSkill)
        {
            _dbContext.Entry(personalSkill).State = EntityState.Modified;
            Save();
        }
    }
}
