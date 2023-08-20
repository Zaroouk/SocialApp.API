namespace SocialApp.API.Dtos;

public class NotificationToAddDto
{
    public int UserId { get; set; }
    public int SenderId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}