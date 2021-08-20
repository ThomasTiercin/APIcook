using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class EducationsService : IEducationsService
    {
        private readonly PortfolioDbContext _dbContext;
        public EducationsService(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteEducation(int Id)
        {
            var education = _dbContext.Education.Find(Id);
            _dbContext.Education.Remove(education);
            Save();
        }

        public Education GetEducationByID(int Id)
        {
            return _dbContext.Education.Find(Id);
        }

        public IEnumerable<Education> GetEducations()
        {
            return _dbContext.Education.ToList();
        }

        public void AddEducation(Education education)
        {
            _dbContext.Add(education);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateEducation(Education education)
        {
            _dbContext.Entry(education).State = EntityState.Modified;
            Save();
        }
    }
}
