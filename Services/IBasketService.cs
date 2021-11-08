using APIcook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public interface IBasketService
    {
        IEnumerable<Basket> GetBasket();

        void AddBasket(Basket BasketItem);
        Basket GetBasketByID(int id);
        IEnumerable<Basket> GetBasketByUserId(int id);
        
        void UpdateBasket(Basket BasketItem);

        void DeleteBasket(int id);
    }
}
