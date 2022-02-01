using bun.Models.Constants;
using bun.Models.DTOs;
using bun.Models.Entities;
using bun.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        public AccountController(
            UserManager<User> userManager,
            IUserService userService
            
            )
        {
            _userManager = userManager;
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterUserDTO dto) //va primi niste date pe are la mapeaza pe RegisterUserDTO
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if(exists!=null)       //username luat
            {
                return BadRequest("User already registered!");
            }

            var result = await _userService.RegisterUserAsync(dto);

            if(result)
            {
                return Ok(result);
            }

            return BadRequest();   //altfel ii da badrequest
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
        {
            var token = await _userService.LoginUser(dto);

            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(new { token });
        }
    }
}
