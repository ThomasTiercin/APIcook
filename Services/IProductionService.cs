using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IProductionsService
    {
        IEnumerable<Production> GetProductions();

        void AddProduction(Production productionItem);
        Production GetProductionByID(int id);

        void UpdateProduction(Production productionItem);

        void DeleteProduction(int id);
    }
}
