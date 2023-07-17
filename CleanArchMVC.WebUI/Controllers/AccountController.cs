using CleanArchMVC.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMVC.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticate;

        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }



        [HttpGet]
        public IActionResult Register() { }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model) { }

        [HttpGet]
        public ActionResult Login() {  }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model) { }


        public async Task<ActionResult> Logout() { }
        
    }
}
