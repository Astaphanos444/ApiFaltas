using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Dtos;
using app.src.model;

namespace app.src.repository.Interfaces
{
    public interface IMateriaRepository
    {
        Task<List<Materia>> getUserMaterias(long UserId);
        Task<Materia?> saveMateria(SaveMateriaRequest request);
        Task<Materia?> deleteMateria(long userId, long materiaId);
    }
}