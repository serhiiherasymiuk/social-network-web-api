using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPostLikesService
    {
        Task<IEnumerable<PostLikeDTO>> GetAll();
        Task<IEnumerable<PostLikeDTO>> GetByUserId(string userId);
        Task<IEnumerable<PostLikeDTO>> GetByPostId(string userId);
        Task Create(PostLikeDTO postLike);
        Task Edit(PostLikeDTO postLike);
        Task Delete(int id);
    }
}
