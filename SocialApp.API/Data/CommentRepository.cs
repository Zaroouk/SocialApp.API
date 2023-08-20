using SocialApp.API.Models;

namespace SocialApp.API.Data;

public class CommentRepository : ICommentRepository
{
    Ctx _entityFramework;

    public CommentRepository(IConfiguration cfg)
    {
        _entityFramework = new Ctx(cfg);

    }
    public void AddComment<T>(T comment)
    {
        if (comment != null) _entityFramework.Add(comment);
    }

    public void RemoveComment<T>(T comment)
    {
        if (comment != null) _entityFramework.Remove(comment);
    }

    public bool SaveChanges()
    {
        return _entityFramework.SaveChanges() > 0;
    }

    public Comment GetSingleComment(int commentId)
    {
        Comment comment = _entityFramework.Comments.Where(c => c.CommentId == commentId).FirstOrDefault();
        if(comment != null)return comment;
        throw new Exception("FAILED TO GET COMMENT");
    }

    public IEnumerable<Comment> GetAllComments()
    {
        IEnumerable<Comment> comments = _entityFramework.Comments.ToList();
        return comments;
    }

    public IEnumerable<Comment> GetCommentsByUser(int userId)
    {
        IEnumerable<Comment> comments = _entityFramework.Comments.ToList().Where(c => c.UserId == userId);
        if (comments != null) return comments;
        throw new Exception("THIS USER HAS NOT MADE ANY COMMENTS");
    }

    public IEnumerable<Comment> GetCommentsByPost(int postId)
    {
        IEnumerable<Comment> comments = _entityFramework.Comments.ToList().Where(p => p.PostId == postId);
        if(comments != null) return comments;
        throw new Exception("THERE ARE NO COMMENTS IN THIS POST");
    }
}