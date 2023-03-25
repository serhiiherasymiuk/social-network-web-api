using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IIndividualChat
    {
        Task<IEnumerable<PostDTO>> GetAll();
        Task<PostDTO?> GetById(int id);
        Task<IEnumerable<PostDTO>> GetByUserId(string userId);
        Task<IEnumerable<PostDTO>> GetByIndividualChatId(string userId);
        Task Create(PostDTO post);
        Task Edit(PostDTO post);
        Task Delete(int id);
    }
}
