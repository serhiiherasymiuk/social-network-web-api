using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AutoMapper;

namespace Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;

        public UsersService(UserManager<User> userManager,
                               SignInManager<User> signInManager,
                                   IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await userManager.Users
                .Include(x => x.Posts)
                .Include(x => x.Comments)
                .Include(x => x.PostLikes)
                .Include(x => x.CommentLikes)
                .Include(x => x.Followers)
                .Include(x => x.FollowedUsers)
                .Include(x => x.SentMessages)
                .Include(x => x.ReceivedMessages)
                .Include(x => x.Notifications)
                .ToListAsync();
            return mapper.Map<IEnumerable<UserDTO>>(users);
        }
        public async Task<IEnumerable<UserDTO>> GetLikedUsersByCommentId(int id)
        {
            var users = await userManager.Users
                .Where(x => x.CommentLikes.Any(x => x.CommentId == id))
                .Include(x => x.Posts)
                .Include(x => x.Comments)
                .Include(x => x.PostLikes)
                .Include(x => x.CommentLikes)
                .Include(x => x.Followers)
                .Include(x => x.FollowedUsers)
                .Include(x => x.SentMessages)
                .Include(x => x.ReceivedMessages)
                .Include(x => x.Notifications)
                .ToListAsync();
            return mapper.Map<IEnumerable<UserDTO>>(users);
        }
        public async Task<IEnumerable<UserDTO>> GetLikedUsersByPostId(int id)
        {
            var users = await userManager.Users
                .Where(x => x.PostLikes.Any(x => x.PostId == id))
                .Include(x => x.Posts)
                .Include(x => x.Comments)
                .Include(x => x.PostLikes)
                .Include(x => x.CommentLikes)
                .Include(x => x.Followers)
                .Include(x => x.FollowedUsers)
                .Include(x => x.SentMessages)
                .Include(x => x.ReceivedMessages)
                .Include(x => x.Notifications)
                .ToListAsync();
            return mapper.Map<IEnumerable<UserDTO>>(users);
        }
        public async Task<UserDTO> GetById(string id)
        {
            var user = await userManager.Users.Where(u => u.Id == id)
                .Include(x => x.Posts)
                .Include(x => x.Comments)
                .Include(x => x.PostLikes)
                .Include(x => x.CommentLikes)
                .Include(x => x.Followers)
                .Include(x => x.FollowedUsers)
                .Include(x => x.SentMessages)
                .Include(x => x.ReceivedMessages)
                .Include(x => x.Notifications)
                .FirstOrDefaultAsync();
            if (user == null)
                throw new HttpException(ErrorMessages.UserByIdNotFound, HttpStatusCode.NotFound);
            return mapper.Map<UserDTO>(user);
        }

        public async Task Login(LoginDTO login)
        {
            var user = await userManager.FindByNameAsync(login.Username);
            if (user == null || !await userManager.CheckPasswordAsync(user, login.Password))
                throw new HttpException(ErrorMessages.InvalidCreds, HttpStatusCode.BadRequest);
            await signInManager.SignInAsync(user, true);
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task Register(RegisterDTO register) 
        {
            User user = new()
            {
                UserName = register.Username,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                string message = string.Join(", ", result.Errors.Select(x => x.Description));

                throw new HttpException(message, HttpStatusCode.BadRequest);
            }
        }

        public async Task Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
                throw new HttpException(ErrorMessages.UserByIdNotFound, HttpStatusCode.NotFound);

            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                string message = string.Join(", ", result.Errors.Select(x => x.Description));
                throw new HttpException(message, HttpStatusCode.BadRequest);
            }
        }
    }
}