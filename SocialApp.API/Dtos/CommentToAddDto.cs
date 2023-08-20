namespace SocialApp.API.Dtos;

public class CommentToAddDto
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string CommentContent { get; set; } = string.Empty;
    public IEnumerable<int>? UserIdLikedList { get; set; }
    public int CommentLiked { get; set; }
    public DateTime CommentCreated { get; set; }
    public DateTime LastEdited { get; set; }
    public bool SelfLike { get; set; }
}