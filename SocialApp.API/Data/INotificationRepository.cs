using SocialApp.API.Models;

namespace SocialApp.API.Data;

public interface INotificationRepository
{
    public bool SaveChanges();
    public void AddNotification(Notification notification);
    public void RemoveNotification(Notification notification);
    public IEnumerable<Notification> GetNotificationsByUser(int userId);
    public Notification GetSingleNotification(int notificationId);
}