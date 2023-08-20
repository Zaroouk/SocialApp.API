using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialApp.API.Models;
using SocialApp.API.Data;

namespace SocialApp.API.Data;

public class UserRepository : IUserRepository
{
    
    Ctx _entityFramework;
    public UserRepository(IConfiguration cfg)
    {
        _entityFramework = new Ctx(cfg);
    }
    public void AddUser<T>(T user)
    {
        if (user != null) _entityFramework.Add(user);
    }

    public void RemoveUser<T>(T user)
    {
        if (user != null) _entityFramework.Remove(user);
    }

    public bool SaveChanges()
    {
        return _entityFramework.SaveChanges() > 0;
    }

    public IEnumerable<User> GetAllUsers()
    {
        var userWithFollowersAndFollowing = _entityFramework.Users
            // .Where(u => u.Id == userId)
            .Join(_entityFramework.Follows,
                user => user.Id,
                follow => follow.FollowingId,
                (user, follow) => new { User = user, Follow = follow })
            .Join(_entityFramework.Users,
                u => u.Follow.FollowerId,
                follower => follower.Id,
                (u, follower) => new { User = u.User, Follower = follower })
            .ToList();
        
        
        if (userWithFollowersAndFollowing.Count > 0)
        {
            var followers = userWithFollowersAndFollowing.Select(u => u.Follower).ToList();
            return followers;
            // Now you have access to the user's followers
        }
        
        var users = userWithFollowersAndFollowing.Select(u => u.Follower).ToList(); 
        return users;
        
        // return _entityFramework.Users.ToList();
    }

    public User GetSingleUser(int id)
    {
        User? user = _entityFramework.Users?
            .Where(u => u.Id == id)
            .FirstOrDefault();
        if (user != null) return user;
        throw new Exception("no user was found");
    }

    public User GetUserByEmail(string email)
    {
        User? user = _entityFramework.Users?
            .Where(e => e.Email == email)
            .FirstOrDefault();
        if (user != null) return user;
        throw new Exception("no user was found with this email");
    }
}