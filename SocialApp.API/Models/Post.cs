namespace SocialApp.API.Models;

public class Post
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string PostContent { get; set; } = string.Empty;
    public IEnumerable<Comment>? CommentList { get; set; }
    public DateTime PostCreated { get; set; }
    public DateTime LastEdited { get; set; }
    public IEnumerable<User>? UserLikedList { get; set; }
    public bool SelfLike { get; set; }
}