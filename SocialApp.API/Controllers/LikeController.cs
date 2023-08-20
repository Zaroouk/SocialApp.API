
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialApp.API.Data;
using SocialApp.API.Dtos;
using SocialApp.API.Models;
using Exception = System.Exception;

namespace SocialApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeRepository _repo;
        private readonly IMapper _mapper;
        public LikeController(ILikeRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/Like
        [HttpGet("GetLikes/{contentId}")]
        public IActionResult GetLikesByContent(int contentId)
        {
            IEnumerable<Like> likes = _repo.GetLikesOfContent(contentId);
            if (!likes.IsNullOrEmpty()) return Ok(likes);
            return NotFound();
        }

        // POST: api/Like
        [HttpPost("/AddLike")]
        public IActionResult AddLike(LikeToAddDto likeToAdd)
        {
            Like? likeDb = _mapper.Map<Like>(likeToAdd);
            likeDb.Timestamp = DateTime.Now;
            _repo.AddLike(likeDb);
            if(_repo.SaveChanges()) return Ok(likeDb);
            return BadRequest("Error adding like");
        }

        // DELETE: api/Like/5
        [HttpDelete("RemoveLike/{id}")]
        public IActionResult RemoveLike(int id)
        {
            Like likedContent = _repo.GetSingleLikeOfContent(id);
            if (likedContent != null)
            {
                _repo.RemoveLike(likedContent);
                if (_repo.SaveChanges()) return Ok("Like removed successfully");
                throw new Exception("Like was not removed");
            }
            return NotFound();
        }
    }
}
