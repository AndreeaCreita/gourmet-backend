using bun.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;   //injections

        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;  //instanta noua de repositoryWrapper in constructor
                                       //pe care o vom asocia proprietatii _repository
                                       //ca sa folosim _repository in controllerul nostru prin aceasta proprietate
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult>GetAllUsers()
        {
            var users = await _repository.User.GetAllUsers();

            return Ok(new { users });
        }
                

    }
}
