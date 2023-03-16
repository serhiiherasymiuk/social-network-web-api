using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentDTO>> GetAll();
        Task<CommentDTO?> GetById(int id);
        Task<IEnumerable<CommentDTO>> GetByUserId(string userId);
        Task<IEnumerable<CommentDTO>> GetByPostId(int postId);
        Task Create(CommentDTO comment);
        Task Edit(CommentDTO comment);
        Task Delete(int id);
    }
}
