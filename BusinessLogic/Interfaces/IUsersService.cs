using Core.DTOs;

namespace Core.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetById(string id);
        Task<IEnumerable<UserDTO>> GetLikedUsersByCommentId(int id);
        Task<IEnumerable<UserDTO>> GetLikedUsersByPostId(int id);
        Task<LoginResponseDto> Login(LoginDTO loginDTO);
        Task Register(RegisterDTO registerDTO);
        Task Logout();
        Task Delete(string id);
    }
}