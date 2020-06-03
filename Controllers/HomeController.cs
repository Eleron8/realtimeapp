using Microsoft.AspNetCore.Mvc;


namespace RealTimeApp.Controllers {
    public class HomeController : Controller 
    {

        public IActionResult Index() => View();
    }
}