using SocialApp.API.Models;

namespace SocialApp.API.Data;

public interface ICommentRepository
{
    public void AddComment<T>(T comment);
    public void RemoveComment<T>(T comment);
    public bool SaveChanges();
    public Comment GetSingleComment(int commentId);
    public IEnumerable<Comment> GetAllComments();
    public IEnumerable<Comment> GetCommentsByUser(int userId);
    public IEnumerable<Comment> GetCommentsByPost(int postId);
    
}