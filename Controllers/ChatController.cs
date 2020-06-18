using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeApp.Hubs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RealTimeApp.Models;
using System;
using RealTimeApp.Database;

namespace RealTimeApp.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private IHubContext<ChatHub> _hubContext;
        public ChatController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpPost("joinRoom/{connectionId}/{roomId}")]
        public async Task<IActionResult> JoinRoom(string connectionId, string roomId)
        {
                await _hubContext.Groups.AddToGroupAsync(connectionId, roomId);
                return Ok();
        }
        [HttpPost("leaveRoom/{connectionId}/{roomId}")]
        public async Task<IActionResult> LeaveRoom(string connectionId, string roomId)
        {
                await _hubContext.Groups.RemoveFromGroupAsync(connectionId, roomId);
                return Ok();
        }

        public async Task<IActionResult> SendMessage(int roomId, string message, [FromServices] AppDbContext ctx)
        {
                var Message = new Message {
                    ChatId = roomId,
                    Text = message,
                    Name = User.Identity.Name,
                    TimeStamp = DateTime.Now
                };

           ctx.Messages.Add(Message);
           await ctx.SaveChangesAsync();

                await _hubContext.Clients.Group(roomId.ToString()).SendAsync("RecieveMessage", new {
                    Text = Message.Text,
                    Name = Message.Name,
                    TimeStamp = Message.TimeStamp.ToString("dd/MM/yyyy hh:mm:ss")
                });
                return Ok();
        }
    }
}