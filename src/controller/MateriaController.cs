using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Dtos;
using app.src.model;
using app.src.repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.src.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaRepository _materiaRepository;
        public MateriaController(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Materia>>> getAllMaterias([FromQuery] long UserId)
        {
            return Ok(await _materiaRepository.getUserMaterias(UserId));
        }

        [HttpPost]
        public async Task<ActionResult<Materia?>> saveMateria(SaveMateriaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var materia = await _materiaRepository.saveMateria(request);
            if (materia == null) return BadRequest();

            return Ok(materia);
        }

        [HttpDelete]
        public async Task<ActionResult> deleteMateria([FromQuery] long materiaId, [FromQuery] long userId)
        {
            var materia = await _materiaRepository.deleteMateria(userId, materiaId);
            if (materia == null) return BadRequest();

            return Ok(materia);
        }
    }
}