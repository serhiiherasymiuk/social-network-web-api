using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICommentLikesService
    {
        Task<IEnumerable<CommentLikeDTO>> GetAll();
        Task<IEnumerable<CommentLikeDTO>> GetByUserId(string userId);
        Task<IEnumerable<CommentLikeDTO>> GetByCommentId(string userId);
        Task Create(CommentLikeDTO commentLike);
        Task Edit(CommentLikeDTO commentLike);
        Task Delete(int id);
    }
}
