using Microsoft.AspNetCore.Mvc;
using RealTimeApp.Database;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


namespace RealTimeApp.ViewComponets
{
    public class RoomViewComponent : ViewComponent 
    {
        private AppDbContext _ctx;
        public RoomViewComponent(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var chats = _ctx.ChatUsers
            .Include(x => x.Chat)
            .Where(x => x.UserId == userId)
            .Select(x => x.Chat)
            .ToList();
            return View(chats);
        }
    }
}