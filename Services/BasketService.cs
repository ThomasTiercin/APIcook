using APIcook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public class BasketService : IBasketService
    {
        private readonly CookDbContext _dbContext;
        public BasketService(CookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteBasket(int Id)
        {
            var Basket = _dbContext.Basket.Find(Id);
            _dbContext.Basket.Remove(Basket);
            Save();
        }
    
        public Basket GetBasketByID(int Id)
        {
            return _dbContext.Basket.Include(b => b.User).Include(b => b.Recipe).FirstOrDefault(b => b.Id == Id);
        }
        public IEnumerable<Basket> GetBasketByUserId(int Id)
        {
            return _dbContext.Basket.Include(b => b.User).Include(b => b.Recipe).Where(b => b.UserId == Id);
        }
        
        public IEnumerable<Basket> GetBasket()
        {
            return _dbContext.Basket.Include(r => r.Recipe).Include(b => b.User);
        }

        public void AddBasket(Basket Basket)
        {
            _dbContext.Add(Basket);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBasket(Basket Basket)
        {
            _dbContext.Entry(Basket).State = EntityState.Modified;
            Save();
        }
    }
}
