using SocialApp.API.Models;

namespace SocialApp.API.Data;

public interface IPostRepository
{
    public void AddPost<T>(T comment);
    public void RemovePost<T>(T comment);
    public bool SaveChanges();
    public IEnumerable<Post> GetAllPosts();
    public IEnumerable<Post> GetPostsByUser(int userId);
    public Post GetSinglePost(int postId);
}