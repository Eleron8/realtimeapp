using Microsoft.AspNetCore.Mvc;


namespace RealTimeApp.Controllers
 {
    public class HomeController : Controller 
    {

        public HomeController(AppDbContext ctx) => _ctx = ctx;
        
        public IActionResult Index() => View();

        
        [HttpPost]

        public IActionResult CreateRoom(string name)
        {
            

            return RedirectToAction("Index");
        }
    }
}