using Microsoft.AspNetCore.Mvc;
using RealTimeApp.Database;
using RealTimeApp.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Data;
using System.Diagnostics;


namespace RealTimeApp.Controllers
 {
    [Authorize]
    public class HomeController : Controller                                                                                                                                                                                                                                                                                                                                                                                                                                                  
    {
        private AppDbContext _ctx;

        public HomeController(AppDbContext ctx) => _ctx = ctx;
        
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var chats = _ctx.Chats
                .Include(x => x.Users)
                .Where(x => !x.Users.Any(y => y.UserId == userId))
                .ToList();
            return View(chats);
        }  

        [HttpGet("{id}")]
        public IActionResult Chat(int id)
        {
            var chat = _ctx.Chats
                .Include(x => x.Messages)
                .FirstOrDefault(x => x.Id == id);
            return View(chat);
        }

       
        [HttpPost]
       public async Task<IActionResult> CreateMessage(int chatId, string msg)
       {
           var message = new Message {
               ChatId = chatId,
               Text = msg,
               Name = User.Identity.Name,
               TimeStamp = DateTime.Now
           };

           _ctx.Messages.Add(message);
           await _ctx.SaveChangesAsync();
           
           return RedirectToAction("Chat", new {id = chatId});
       }

        
        [HttpPost]

        public async Task<IActionResult> CreateRoom(string name)
        {
            var chat = new Chat {
                Name = name,
                Type = ChatType.Room
            };
            
            chat.Users.Add(new ChatUser{
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Role = UserRole.Admin
            });
            _ctx.Chats.Add(chat);

            await _ctx.SaveChangesAsync();

            return RedirectToAction("Index");
        }

         [HttpPost]
        public async Task<IActionResult> JoinRoom(int roomId)
        {
            var chatUser = new ChatUser{
                ChatId = roomId,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Role = UserRole.Admin
            };

            _ctx.ChatUsers.Add(chatUser);

            await _ctx.SaveChangesAsync();

            return RedirectToAction("Chat", "Home", new { id = roomId });
        }
    }
}