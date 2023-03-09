using Core.Interfaces;
using Core.Entities;
using Core.Specifications;

namespace Core.Services
{
    public class PostsService : IPostsService
    {
        private readonly IRepository<Post> postsRepo;

        public PostsService(IRepository<Post> postsRepo)
        {
            this.postsRepo = postsRepo;
        }
        public async Task<IEnumerable<Post>> GetAll()
        {
            return await postsRepo.GetAll();
        }

        public async Task<Post?> GetById(int id)
        {
            return await postsRepo.GetById(id);
        }
        public async Task<IEnumerable<Post>> GetByUserId(int userId)
        {
            return await postsRepo.GetAll();
        }
        public async Task Edit(Post post)
        {
            await postsRepo.Update(post);
            await postsRepo.Save();
        }

        public async Task Create(Post post)
        {
            await postsRepo.Insert(post);
            await postsRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await postsRepo.GetById(id) == null) return;
            await postsRepo.Delete(id);
            await postsRepo.Save();
        }
    }
}