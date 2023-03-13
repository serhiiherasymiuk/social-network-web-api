using Core.Interfaces;
using Core.Entities;
using Core.Specifications;
using Core.DTOs;
using AutoMapper;
using Core.Helpers;
using System.Net;

namespace Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<User> usersRepo;
        private readonly IMapper mapper;
        public UsersService(IRepository<User> usersRepo, IMapper mapper)
        {
            this.usersRepo = usersRepo;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await usersRepo.GetAllBySpec(new Users.OrderedAll());
            return mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO?> GetById(int id)
        {
            User user = await usersRepo.GetBySpec(new Users.ById(id));
            if (user == null)
                throw new HttpException($"User with Id of {id} not found!", HttpStatusCode.NotFound);
            return mapper.Map<UserDTO>(user);
        }

        public async Task Edit(UserDTO userDTO)
        {
            await usersRepo.Update(mapper.Map<User>(userDTO));
            await usersRepo.Save();
        }

        public async Task Create(UserDTO userDTO)
        {
            await usersRepo.Insert(mapper.Map<User>(userDTO));
            await usersRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await usersRepo.GetByID(id) == null)
                throw new HttpException($"User with Id of {id} not found!", HttpStatusCode.NotFound);
            await usersRepo.Delete(id);
            await usersRepo.Save();
        }
    }
}