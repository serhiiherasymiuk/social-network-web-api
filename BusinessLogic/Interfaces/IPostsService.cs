﻿using Core.DTOs;
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
        Task<IEnumerable<PostDTO>> GetAll();
        Task<PostDTO?> GetById(int id);
        Task<IEnumerable<PostDTO>> GetByUserId(string userId);
        Task Create(PostDTO post);
        Task Edit(PostDTO post);
        Task Delete(int id);
    }
}
