using Contract;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrenzyAPI.Controllers
{
    public class UsersController:BaseApiController
    {
        private readonly IRequestHandler _handler;
        public UsersController(IRequestHandler handler)
        {
            _handler = handler;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _handler.GetUsers();
            if (users is null)
                return NotFound(users);
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([Required]int id)
        {
            var result = await _handler.GetUserById(id);
            return Ok(result);
        }

    }
}
