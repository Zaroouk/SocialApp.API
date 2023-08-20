using Microsoft.IdentityModel.Tokens;
using SocialApp.API.Models;

namespace SocialApp.API.Data;

public class FollowRepository : IFollowRepository
{
    Ctx _entityFramework;
    public FollowRepository(IConfiguration cfg)
    {
        _entityFramework = new Ctx(cfg);
    }
    public bool SaveChanges()
    {
        return _entityFramework.SaveChanges() > 0;
    }

    public void AddFollow(Follow follow)
    {
        if (follow != null) _entityFramework.Add(follow);
    }

    public void RemoveFollow(Follow follow)
    {
        if (follow != null) _entityFramework.Remove(follow);
    }
    
    public IEnumerable<Follow> GetFollowsByUser(int userId)
    {
        IEnumerable<Follow> followings = _entityFramework.Follows.Where(f => f.FollowerId == userId).ToList();
        return followings;
    }

    public IEnumerable<Follow> GetFollowersByUser(int userId)
    {
        IEnumerable<Follow> followers = _entityFramework.Follows.Where(f => f.FollowingId == userId);
        return followers;
    }

    public Follow GetSingleFollow(int followId)
    {
        Follow follow = _entityFramework.Follows.Where(f => f.Id == followId).FirstOrDefault();
        if (follow != null) return follow;
        return null;
    }
}