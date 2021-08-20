using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class ExperiencesService : IExperiencesService
    {
        private readonly PortfolioDbContext _dbContext;
        public ExperiencesService(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteExperience(int Id)
        {
            var experience = _dbContext.Experience.Find(Id);
            _dbContext.Experience.Remove(experience);
            Save();
        }

        public Experience GetExperienceByID(int Id)
        {
            return _dbContext.Experience.Find(Id);
        }

        public IEnumerable<Experience> GetExperiences()
        {
            return _dbContext.Experience.ToList();
        }

        public void AddExperience(Experience experience)
        {
            _dbContext.Add(experience);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateExperience(Experience experience)
        {
            _dbContext.Entry(experience).State = EntityState.Modified;
            Save();
        }
    }
}
