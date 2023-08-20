using System.Collections;
using SocialApp.API.Models;

namespace SocialApp.API.Data;

public class NotificationRepository : INotificationRepository
{
    public bool SaveChanges()
    {
        return true;
    }

    public void AddNotification(Notification notification)
    {
        bool a = true;
    }

    public void RemoveNotification(Notification notification)
    {
        bool a = true;
    }

    public IEnumerable<Notification> GetNotificationsByUser(int userId)
    {
        IEnumerable<Notification> noti = new List<Notification>();
        return noti;
    }

    public Notification GetSingleNotification(int notificationId)
    {
        Notification noti = new();
        return noti;
    }
}