using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;
        
        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {


            return View();
        }
    }
}
