using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.data;
using app.src.Dtos;
using app.src.model;
using app.src.repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace app.src.repository
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly ApplicationDbContext _context;
        public MateriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Materia>> getUserMaterias(long UserId)
        {
            return await _context.Materias.AsQueryable()
                .Where(x => x.UserId == UserId)
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }

        public async Task<Materia?> saveMateria(SaveMateriaRequest request)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null) return null;

            Materia materia = new Materia
            {
                Nome = request.Nome,
                MaxFaltas = request.MaxFaltas,
                UserId = request.UserId,
                User = user
            };

            await _context.Materias.AddAsync(materia);
            await _context.SaveChangesAsync();

            return materia;
        }
    }
}