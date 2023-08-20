namespace SocialApp.API.Models;

public class Comment
{
 public int CommentId { get; set; }
 public int UserId { get; set; }
 public int PostId { get; set; }
 public string CommentContent { get; set; } = string.Empty;
 public IEnumerable<User>? UserIdLikedList { get; set; }
 public int CommentLiked { get; set; }
 public DateTime CommentCreated { get; set; }
 public DateTime LastEdited { get; set; }
 public bool SelfLike { get; set; }
}