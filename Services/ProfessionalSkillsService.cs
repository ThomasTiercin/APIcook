using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class ProfessionalSkillsService : IProfessionalSkillsService
    {
        private readonly PortfolioDbContext _dbContext;
        public ProfessionalSkillsService(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteProfessionalSkill(int Id)
        {
            var professionalSkill = _dbContext.ProfessionalSkills.Find(Id);
            _dbContext.ProfessionalSkills.Remove(professionalSkill);
            Save();
        }

        public ProfessionalSkills GetProfessionalSkillByID(int Id)
        {
            return _dbContext.ProfessionalSkills.Find(Id);
        }

        public IEnumerable<ProfessionalSkills> GetProfessionalSkills()
        {
            return _dbContext.ProfessionalSkills.ToList();
        }

        public void AddProfessionalSkill(ProfessionalSkills professionalSkill)
        {
            _dbContext.Add(professionalSkill);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProfessionalSkill(ProfessionalSkills professionalSkill)
        {
            _dbContext.Entry(professionalSkill).State = EntityState.Modified;
            Save();
        }
    }
}
