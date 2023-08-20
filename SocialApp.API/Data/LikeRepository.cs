using SocialApp.API.Models;

namespace SocialApp.API.Data;

public class LikeRepository : ILikeRepository
{
    Ctx _entityFramework;
    public LikeRepository(IConfiguration cfg)
    {
        _entityFramework = new Ctx(cfg);
    }
    public void AddLike(Like like)
    {
        if (like != null) _entityFramework.Add(like);
    }
    public void RemoveLike(Like like)
    {
        if (like != null) _entityFramework.Remove(like);
    }
    public bool SaveChanges()
    {
        return _entityFramework.SaveChanges() > 0;
    }

    public IEnumerable<Like> GetLikesOfContent(int contentId)
    {
        IEnumerable<Like> likesPost = _entityFramework.Likes.Where(p => p.ContentId == contentId).ToList();
        return likesPost;
    }
    public Like GetSingleLikeOfContent(int contentId)
    {
        Like likePost = _entityFramework.Likes.Where(l => l.ContentId == contentId).FirstOrDefault();
        if (likePost != null) return likePost;
        return null;
    }
}