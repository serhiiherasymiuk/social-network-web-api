using Core.Interfaces;
using Core.Entities;
using Core.Specifications;

namespace Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<User> usersRepo;

        public UsersService(IRepository<User> usersRepo)
        {
            this.usersRepo = usersRepo;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await usersRepo.GetAllBySpec(new Users.OrderedAll());
        }

        public async Task<User?> GetById(int id)
        {
            return await usersRepo.GetBySpec(new Users.ById(id));
        }

        public async Task Edit(User post)
        {
            await usersRepo.Update(post);
            await usersRepo.Save();
        }

        public async Task Create(User post)
        {
            await usersRepo.Insert(post);
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