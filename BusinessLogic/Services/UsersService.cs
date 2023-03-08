using Core.Interfaces;
using Core.Entities;

namespace Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<User> usersRepo;

        public UsersService(IRepository<User> genresRepo)
        {
            this.usersRepo = genresRepo;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await usersRepo.Get();
        }

        public async Task<User?> GetById(int id)
        {
            if (await usersRepo.GetByID(id) == null) return null;

            return await usersRepo.GetByID(id);
        }

        public async Task Edit(User movie)
        {
            await usersRepo.Update(movie);
            await usersRepo.Save();
        }

        public async Task Create(User movie)
        {
            await usersRepo.Insert(movie);
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
