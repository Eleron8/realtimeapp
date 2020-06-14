using Microsoft.AspNetCore.Mvc;
using RealTimeApp.Database;
using RealTimeApp.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;


namespace RealTimeApp.Controllers
 {
    public class HomeController : Controller 
    {
        private AppDbContext _ctx;

        public HomeController(AppDbContext ctx) => _ctx = ctx;
        
        public IActionResult Index() => View();

        [HttpGet("{id}")]
        public IActionResult Chat(int id)
        {
            var chat = _ctx.Chats
                .Include(x => x.Messages)
                .FirstOrDefault(x => x.Id == id);
            return View();
        }

        [HttpPost]
       public async Task<IActionResult> CreateMessage(int chatId, string msg)
       {
           var message = new Message {
               ChatId = chatId,
               Text = msg,
               Name = "Default",
               TimeStamp = DateTime.Now
           };

           _ctx.Messages.Add(message);
           await _ctx.SaveChangesAsync();
           
           return RedirectToAction("Chat", new {id = chatId});
       }

        
        [HttpPost]

        public async Task<IActionResult> CreateRoom(string name)
        {
            _ctx.Chats.Add(new Chat {
                Name = name,
                Type = ChatType.Room
            });

            await _ctx.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}