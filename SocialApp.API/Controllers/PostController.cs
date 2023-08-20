// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;

using AutoMapper;
using SocialApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialApp.API.Dtos;
using SocialApp.API.Models;

namespace SocialApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repo;
        private readonly IMapper _mapper;
        public PostController(IPostRepository repo)
        {
            _repo = repo;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostToAddDto, Post>();
            }));
        }

        [HttpGet("GetAllPosts")]
        public IEnumerable<Post> GetPosts()
        {
            IEnumerable<Post> allPosts = _repo.GetAllPosts();
            return allPosts;
        }

        [HttpGet("GetAllPosts/{userId}")]
        public IActionResult GetPostsByUser(int userId)
        {
            IEnumerable<Post> allPosts = _repo.GetPostsByUser(userId);
            if (!allPosts.IsNullOrEmpty()) return Ok(allPosts);
            throw new Exception("this user has no posts");
        }

        [HttpPost("CreatePost")]
        public IActionResult CreatePost(PostToAddDto postCreate)
        {
            Post postDb = _mapper.Map<Post>(postCreate);
            postDb.PostCreated = DateTime.Now;
            postDb.LastEdited = postDb.PostCreated;
            _repo.AddPost(postDb);
            if (_repo.SaveChanges()) return Ok(postDb);
            

            throw new Exception("post could not be initialized");
        }

        [HttpPut("EditPost")]
        public IActionResult EditPost(Post postEdit)
        {
            int.TryParse(User.FindFirst("userId")?.Value, out int userId);
            if (userId == postEdit.UserId)
            {
                Post? dbPost = _repo.GetSinglePost(postEdit.PostId);
                if (dbPost != null)
                {
                    dbPost.PostContent = postEdit.PostContent;
                    dbPost.LastEdited = DateTime.Now;
                    if (_repo.SaveChanges()) return Ok(dbPost);
                }
                throw new Exception("could not edit post");
            }
            throw new Exception("this user cannot edit this post");
        }

        [HttpDelete("{postId}")]
        public IActionResult DeletePost(int postId)
        {
            int.TryParse(User.FindFirst("userId")?.Value, out int userId);
            Post postDb = _repo.GetSinglePost(postId);
            if (postDb.UserId == userId)
            {
                _repo.RemovePost(postDb);
                return Ok("post deleted successfully");
            }

            throw new Exception("You are not allow to delete this post");
        }
    }
}
