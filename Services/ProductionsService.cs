using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class ProductionsService : IProductionsService
    {
        private readonly PortfolioDbContext _dbContext;
        public ProductionsService(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteProduction(int Id)
        {
            var production = _dbContext.Production.Find(Id);
            _dbContext.Production.Remove(production);
            Save();
        }

        public Production GetProductionByID(int Id)
        {
            return _dbContext.Production.Find(Id);
        }

        public IEnumerable<Production> GetProductions()
        {
            return _dbContext.Production.ToList();
        }

        public void AddProduction(Production production)
        {
            _dbContext.Add(production);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduction(Production production)
        {
            _dbContext.Entry(production).State = EntityState.Modified;
            Save();
        }
    }
}
