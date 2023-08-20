using SocialApp.API.Models;

namespace SocialApp.API.Data;

public class NotificationRepository : INotificationRepository
{
    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void AddNotification(Notification notification)
    {
        throw new NotImplementedException();
    }

    public void RemoveNotification(Notification notification)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Notification> GetNotificationsByUser(int userId)
    {
        throw new NotImplementedException();
    }

    public Notification GetSingleNotification(int notificationId)
    {
        throw new NotImplementedException();
    }
}