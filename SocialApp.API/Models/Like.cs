namespace SocialApp.API.Models;

public class Like
{
    public int LikeId { get; set; }
    public int ContentId { get; set; }
    public string ContentType { get; set; } = string.Empty;
    public int UserId { get; set; }
    public DateTime Timestamp { get; set; }
}