using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Resources;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CommentsService
    {
        private readonly IRepository<Comment> commentsRepo;
        private readonly IMapper mapper;

        public CommentsService(IRepository<Comment> commentsRepo, IMapper mapper)
        {
            this.commentsRepo = commentsRepo;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<CommentDTO>> GetAll()
        {
            var commnets = await commentsRepo.GetAll();
            return mapper.Map<IEnumerable<CommentDTO>>(commnets);
        }
        public async Task<CommentDTO?> GetById(int id)
        {
            Comment comment = await commentsRepo.GetBySpec(new Comments.ById(id));
            if (comment == null)
                throw new HttpException(ErrorMessages.CommentByIdNotFound, HttpStatusCode.NotFound);
            return mapper.Map<CommentDTO>(comment);
        }
        public async Task<IEnumerable<CommentDTO>> GetByUserId(string userId)
        {
            var comments = await commentsRepo.GetAllBySpec(new Comments.ByUserId(userId));
            return mapper.Map<IEnumerable<CommentDTO>>(comments);
        }
        public async Task Edit(PostDTO comment)
        {
            await commentsRepo.Update(mapper.Map<Comment>(comment));
            await commentsRepo.Save();
        }

        public async Task Create(CommentDTO comment)
        {
            await commentsRepo.Insert(mapper.Map<Comment>(comment));
            await commentsRepo.Save();
        }

        public async Task Delete(int id)
        {
            if (await commentsRepo.GetByID(id) == null)
                throw new HttpException(ErrorMessages.CommentByIdNotFound, HttpStatusCode.NotFound);
            await commentsRepo.Delete(id);
            await commentsRepo.Save();
        }
    }
}
