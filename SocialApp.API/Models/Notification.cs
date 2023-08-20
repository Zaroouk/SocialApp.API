namespace SocialApp.API.Models;

public class Notification
{
    public int NotificationId { get; set; }
    public int UserId { get; set; }
    public int SenderId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}