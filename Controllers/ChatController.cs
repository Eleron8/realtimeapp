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
        [HttpPost("joinRoom/{connectionId}/{roomName}")]
        public async Task<IActionResult> JoinRoom(string connectionId, string roomName)
        {
                await _hubContext.Groups.AddToGroupAsync(connectionId, roomName);
                return Ok();
        }
        [HttpPost("leaveRoom/{connectionId}/{roomName}")]
        public async Task<IActionResult> LeaveRoom(string connectionId, string roomName)
        {
                await _hubContext.Groups.RemoveFromGroupAsync(connectionId, roomName);
                return Ok();
        }

        public async Task<IActionResult> SendMessage(string roomName, string message, int chatId, [FromServices] AppDbContext ctx)
        {
                var Message = new Message {
                    ChatId = chatId,
                    Text = message,
                    Name = User.Identity.Name,
                    TimeStamp = DateTime.Now
                };

           ctx.Messages.Add(Message);
           await ctx.SaveChangesAsync();

                await _hubContext.Clients.Group(roomName).SendAsync("RecieveMessage", Message);
                return Ok();
        }
    }
}