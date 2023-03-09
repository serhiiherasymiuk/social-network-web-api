using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPostsService
    {
        Task<IEnumerable<Post>> GetAll();
        Task<Post?> GetById(int id);
        Task<IEnumerable<Post>> GetByUserId(int userId);
        Task Create(Post post);
        Task Edit(Post post);
        Task Delete(int id);
    }
}
