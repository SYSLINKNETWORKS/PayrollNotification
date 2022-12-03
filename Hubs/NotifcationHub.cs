using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TWP_API_Notification.Hubs {
    public class NotificationMessageHub : Hub {
        public async Task SendNotificationMessage (string _Topic,string _DateTime, string _CustomerId, string _CustomerName, string _MessageCategory, string _Message) {
            await Clients.All.SendAsync ("ReceiveNotificationMessage", _Topic,_DateTime, _CustomerId, _CustomerName, _MessageCategory, _Message);
        }

    }
}