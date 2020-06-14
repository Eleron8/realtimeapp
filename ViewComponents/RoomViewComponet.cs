using Microsoft.AspNetCore.Mvc;
using RealTimeApp.Database;
using System.Linq;

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
            var chats = _ctx.Chats.ToList();
            return View(chats);
        }
    }
}