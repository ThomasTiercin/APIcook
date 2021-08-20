using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CertificationsService : ICertificationsService
    {
        private readonly PortfolioDbContext _dbContext;
        public CertificationsService(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCertification(int Id)
        {
            var certification = _dbContext.Certification.Find(Id);
            _dbContext.Certification.Remove(certification);
            Save();
        }

        public Certification GetCertificationByID(int Id)
        {
            return _dbContext.Certification.Find(Id);
        }

        public IEnumerable<Certification> GetCertifications()
        {
            return _dbContext.Certification.ToList();
        }

        public void AddCertification(Certification certification)
        {
            _dbContext.Add(certification);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCertification(Certification certification)
        {
            _dbContext.Entry(certification).State = EntityState.Modified;
            Save();
        }
    }
}
