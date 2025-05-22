using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Dtos;
using app.src.model;
using app.src.repository.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace app.src.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<ActionResult<User?>> getUserById([FromQuery] long id)
        {
            var res = await _userRepository.getUserById(id);
            if (res == null) return BadRequest();

            return Ok(res);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User?>> loginUser([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _userRepository.getUserByName(request.UserName);
            if (res == null) return BadRequest();
            if (res.Password != request.Password) return BadRequest();

            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<User>> saveUser([FromBody]SaveUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(await _userRepository.saveUser(request));
        }
    }
}