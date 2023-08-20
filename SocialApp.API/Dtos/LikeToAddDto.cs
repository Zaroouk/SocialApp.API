namespace SocialApp.API.Dtos;

public class LikeToAddDto
{
    public int ContentId { get; set; }
    public string ContentType { get; set; } = string.Empty;
    public int UserId { get; set; }
    public DateTime Timestamp { get; set; }
}