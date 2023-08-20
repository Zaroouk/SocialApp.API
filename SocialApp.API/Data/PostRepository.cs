using Microsoft.AspNetCore.Http.HttpResults;
using SocialApp.API.Models;

namespace SocialApp.API.Data;

public class PostRepository : IPostRepository
{
    Ctx _entityFramework;

    public PostRepository(IConfiguration cfg)
    {
        _entityFramework = new Ctx(cfg);
    }
    public void AddPost<T>(T post)
    {
        if (post != null) _entityFramework.Add(post);
    }

    public void RemovePost<T>(T post)
    {
        if (post != null) _entityFramework.Remove(post);
    }

    public bool SaveChanges()
    {
        return _entityFramework.SaveChanges() > 0;
    }

    public IEnumerable<Post> GetAllPosts()
    {
        IEnumerable<Post> dbPosts = _entityFramework.Posts.ToList();
        return dbPosts;
    }

    public IEnumerable<Post> GetPostsByUser(int userId)
    {
        IEnumerable<Post> posts = _entityFramework.Posts.ToList().Where(u => u.UserId == userId);
        return posts;
    }

    public Post GetSinglePost(int postId)
    {
        Post? post = _entityFramework.Posts.Where(p => p.PostId == postId).FirstOrDefault();
        if(post!=null) return post;
        throw new Exception("no post found");
    }
}