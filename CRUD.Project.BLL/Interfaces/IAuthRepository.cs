using CRUD.Project.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Project.BLL.Interfaces
{
    public interface IAuthRepository
    {
        Task<IdentityResult> CreateUser(Registration model);
        Task<JwtSecurityToken> LoginUser(IdentityUser model);
    }
}
