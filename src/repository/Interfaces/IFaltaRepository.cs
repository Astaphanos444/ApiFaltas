using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Dtos;
using app.src.model;

namespace app.src.repository.Interfaces
{
    public interface IFaltaRepository
    {
        Task<List<Falta>> getFaltas(long UserId, long MateriaId);
        Task<Falta?> saveFalta(SaveFaltaRequest request);
    }
}