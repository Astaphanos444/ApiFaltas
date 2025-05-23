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
    public class FaltaRepository : IFaltaRepository
    {
        private readonly ApplicationDbContext _context;
        public FaltaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Falta>> getFaltas(long UserId, long MateriaId)
        {
            return await _context.Faltas.AsQueryable()
                .Where(x => x.UserId == UserId && x.MateriaId == MateriaId)
                .OrderByDescending(x => x.DataFalta)
                .ToListAsync();
        }

        public async Task<Falta?> saveFalta(SaveFaltaRequest request)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            Materia materia = await _context.Materias.FirstOrDefaultAsync(x => x.Id == request.MateriaId);
            if (user == null || materia == null) return null;

            Falta falta = new Falta
            {
                DataFalta = DateTime.Now,
                UserId = request.UserId,
                MateriaId = request.MateriaId,
                User = user,
                Materia = materia
            };

            await _context.Faltas.AddAsync(falta);
            await _context.SaveChangesAsync();

            return falta;
        }

        public async Task<Falta?> deleteFalta(long faltaId)
        {
            Falta falta = await _context.Faltas.FirstOrDefaultAsync(x => x.Id == faltaId);
            if (falta == null) return null;

            _context.Faltas.Remove(falta);
            await _context.SaveChangesAsync();
            
            return falta;
        }
    }
}