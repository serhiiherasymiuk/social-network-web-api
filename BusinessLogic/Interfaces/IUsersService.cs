using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task Create(User user);
        Task Edit(User user);
        Task Delete(int id);
    }
}