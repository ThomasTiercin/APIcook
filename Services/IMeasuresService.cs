using APIcook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIcook.Services
{
    public interface IMeasuresService
    {
        IEnumerable<Measure> GetMeasures();

        void AddMeasure(Measure measureItem);
        Measure GetMeasureByID(int id);

        void UpdateMeasure(Measure measureItem);

        void DeleteMeasure(int id);
    }
}
