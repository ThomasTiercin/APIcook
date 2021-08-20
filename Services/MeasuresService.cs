using APIcook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public class MeasuresService : IMeasuresService
    {
        private readonly CookDbContext _dbContext;
        public MeasuresService(CookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteMeasure(int Id)
        {
            var measure = _dbContext.Measure.Find(Id);
            _dbContext.Measure.Remove(measure);
            Save();
        }

        public Measure GetMeasureByID(int Id)
        {
            return _dbContext.Measure.Find(Id);
        }

        public IEnumerable<Measure> GetMeasures()
        {
            return _dbContext.Measure.ToList();
        }

        public void AddMeasure(Measure measure)
        {
            _dbContext.Add(measure);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateMeasure(Measure measure)
        {
            _dbContext.Entry(measure).State = EntityState.Modified;
            Save();
        }
    }
}
