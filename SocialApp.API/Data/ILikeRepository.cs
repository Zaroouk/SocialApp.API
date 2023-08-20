using SocialApp.API.Models;

namespace SocialApp.API.Data;

public interface ILikeRepository
{
    public void AddLike(Like like);
    public void RemoveLike(Like like);
    public bool SaveChanges();
    public IEnumerable<Like> GetLikesOfContent(int postId);
    public Like GetSingleLikeOfContent(int postId);
}