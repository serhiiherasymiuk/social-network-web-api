using Core.Interfaces;
using Core.Entities;
using Core.Specifications;
using Core.DTOs;
using AutoMapper;

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
            if (await usersRepo.GetByID(id) == null) return;
            await usersRepo.Delete(id);
            await usersRepo.Save();
        }
    }
}