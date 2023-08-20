// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
// using NuGet.Protocol;
using SocialApp.API.Data;
using SocialApp.API.Dtos;
using SocialApp.API.Models;

namespace SocialApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _repo;
        private readonly IMapper _mapper;
        public CommentController(ICommentRepository repo)
        {
            _repo = repo;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentToAddDto, Comment>();
            }));
        }
        
        // GET: api/Comment/5
        [HttpGet("{postId}")]
        public IEnumerable<Comment> GetCommentsByPost(int postId)
        {
            return _repo.GetCommentsByPost(postId);
        }

        // POST: api/Comment
        [HttpPost]
        public IActionResult CreateComment(CommentToAddDto createComment)
        {
            Comment commentDb = _mapper.Map<Comment>(createComment);
            
            commentDb.CommentCreated = DateTime.Now;
            commentDb.LastEdited = commentDb.CommentCreated;
            _repo.AddComment(commentDb);
            if (_repo.SaveChanges()) return Ok(commentDb);
            throw new Exception("comment could not be created");
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult EditComment(Comment editComment)
        {
            Comment dbComment = _repo.GetSingleComment(editComment.CommentId);
            dbComment.CommentContent = editComment.CommentContent;
            dbComment.LastEdited = DateTime.Now;
            if (_repo.SaveChanges()) return Ok(dbComment);
            throw new Exception("could not edit comment");
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            Comment dbComment = _repo.GetSingleComment(id);
            if (dbComment != null)
            {
                _repo.RemoveComment(id);
                if (_repo.SaveChanges())
                    return Ok($"comment the following comment has been removed from the db{dbComment}");
            }
            throw new Exception("this comment was found in the db");
        }
    }
}
