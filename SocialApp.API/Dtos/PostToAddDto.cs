using SocialApp.API.Models;

namespace SocialApp.API.Dtos;

public class PostToAddDto
{
    public int UserId { get; set; }
    public string PostContent { get; set; } = string.Empty;
    public IEnumerable<Comment>? CommentList { get; set; }
    public DateTime PostCreated { get; set; }
    public DateTime LastEdited { get; set; }
    public IEnumerable<int>? UserLikedList { get; set; }
    public bool SelfLike { get; set; } = false;
}