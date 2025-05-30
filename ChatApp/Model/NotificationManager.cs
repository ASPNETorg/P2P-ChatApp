using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Model
{   
    public class NotificationManager
    {
        private Queue<String> notifications = new Queue<String>();
        public event EventHandler newNotification;
        private readonly object _lock = new();
        public bool HasMoreNotifications() => notifications.Count != 0;
        public void AddNotification(string message)
        {
            lock (_lock)
            {
                notifications.Enqueue(message);
            }
            if (notifications.Count == 1)
            {
                newNotification?.Invoke(this, EventArgs.Empty);
            }
        }

        public string GetLatestNotification()
        {
            return notifications.First();
        }
        public void DequeueNotification()
        {
            lock (_lock)
            {
                notifications.Dequeue();
            }
        }
    }
}
