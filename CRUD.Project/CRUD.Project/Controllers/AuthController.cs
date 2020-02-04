using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.Project.DAL.Entities;
using CRUD.Project.DAL.Models;
using CRUD.Project.BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace CRUD.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAuthRepository _authService;
        public AuthController(UserManager<IdentityUser> userManager, IAuthRepository authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] Registration model)
        {
            var user = await _authService.CreateUser(model);

            return Ok(user);
        }


        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] Login model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if(user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = await _authService.LoginUser(user);

                return Ok(new { 
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }


    }
}
