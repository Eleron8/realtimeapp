using Microsoft.AspNetCore.Mvc;
using RealTimeApp.Database;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace RealTimeApp.ViewComponets
{
    public class RoomViewComponent : ViewComponent 
    {
        private AppDbContext _ctx;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RoomViewComponent(AppDbContext ctx, IHttpContextAccessor httpContextAccessor)
        {
            _ctx = ctx;
            _httpContextAccessor = httpContextAccessor;
        }

        
        public IViewComponentResult Invoke()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var chats = _ctx.ChatUsers
            .Include(x => x.Chat)
            .Where(x => x.UserId == userId)
            .Select(x => x.Chat)
            .ToList();
            return View(chats);
        }
    }
}