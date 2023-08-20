using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialApp.API.Data;
using SocialApp.API.Dtos;
using SocialApp.API.Models;

namespace SocialApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserToAddDto, User>();
            }));
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleUser(int id)
        {
            User? dbUser = _repo.GetSingleUser(id);
            if (dbUser != null) return Ok(dbUser);
            throw new Exception("this user does not exist");
        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {
                var users = _repo.GetAllUsers();
                return users;
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser(User user)
        {
            User dbUser = _repo.GetSingleUser(user.Id);
            if (_repo.SaveChanges()) return Ok(dbUser);
            throw new Exception("user edit was not completed");
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(UserToAddDto userToAdd)
        {
            User dbUser = _repo.GetUserByEmail(userToAdd.Email);
            if (dbUser != null)
            {
                User newUserDb = _mapper.Map<User>(userToAdd);
                _repo.AddUser(newUserDb);
                if (_repo.SaveChanges()) return Ok(newUserDb);
                return NotFound();
            }
            throw new Exception("user was not created");
        }

        [HttpDelete("/{id}")]
        public IActionResult DeleteUser(int id)
        {
            User dbUser = _repo.GetSingleUser(id);
            if (dbUser != null)
            {
                _repo.RemoveUser(dbUser);
                if (_repo.SaveChanges()) return Ok($"user: {dbUser} was removed successfully");
                return NotFound();
            }
            throw new Exception("User was not found");
        }
    }
}
