using Core.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Interfaces
{
    public interface IUsersService
    {
        Task<IdentityUser> Get(string id);
        Task Login(LoginDTO loginDTO);
        Task Register(RegisterDTO registerDTO);
        Task Logout();
    }
}