using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TWP_API_Notification.Hubs {
    public class ChatHub : Hub {
        public async Task SendMessage (string topic, string user, string message) {
            await Clients.All.SendAsync ("ReceiveMessage", topic, user, message);
        }

        public async Task SendEmail (string Topic, string CustomerName, string SendTo, string Subject, string Body) {
            await Clients.All.SendAsync ("ReceiveEmailMessage", Topic, CustomerName, SendTo, Subject, Body);
        }

        public async Task SendText (string text) {
            await Clients.All.SendAsync ("SendEmail", text);
        }
    }
}