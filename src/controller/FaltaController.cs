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
    public class FaltaController : ControllerBase
    {
        private readonly IFaltaRepository _faltaRepository;
        public FaltaController(IFaltaRepository faltaRepository)
        {
            _faltaRepository = faltaRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Falta>>> getFaltas([FromQuery] long UserId, [FromQuery] long MateriaId)
        {
            return Ok(await _faltaRepository.getFaltas(UserId, MateriaId));

        }

        [HttpPost]
        public async Task<ActionResult<Falta?>> saveFalta(SaveFaltaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _faltaRepository.saveFalta(request);
            if (res == null) return BadRequest();

            return Ok(res);
        }

        [HttpDelete]
        public async Task<ActionResult> deleteFalta([FromQuery] long faltaId)
        {
            var res = await _faltaRepository.deleteFalta(faltaId);
            if (res == null) return BadRequest();

            return Ok(res);
        }
    }
}