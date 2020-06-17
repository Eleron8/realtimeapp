using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using RealTimeApp.Models;
using System.Threading.Tasks;

namespace RealTimeApp.Controllers
{
    public class AccountController : Controller 
    {

        private SignInManager<User> _signInManager;  
        private UserManager<User> _userManager;      
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                       
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Registration() => View();

        [HttpPost]
        public async Task<IActionResult> Registration(string username, string password)
        {
            var user = new User{
                UserName = username
            };
            
            var result = await _userManager.CreateAsync(user, password);

            if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

            return RedirectToAction("Registration", "Account");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View();
        }
    }
}