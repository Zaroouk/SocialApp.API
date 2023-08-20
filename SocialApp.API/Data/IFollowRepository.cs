using SocialApp.API.Models;

namespace SocialApp.API.Data;

public interface IFollowRepository
{
    public bool SaveChanges();
    public void AddFollow(Follow follow);
    public void RemoveFollow(Follow follow);
    public IEnumerable<Follow> GetFollowsByUser(int userId);
    public IEnumerable<Follow> GetFollowersByUser(int userId);
    public Follow GetSingleFollow(int followId);
}