using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace RealTimeApp.Hubs
{
    public class ChatHub : Hub
    {
        public string GetConnectionId() => Context.ConnectionId;
    }
}