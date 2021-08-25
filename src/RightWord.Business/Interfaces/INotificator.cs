using RightWord.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace RightWord.Business.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);

    }
}
