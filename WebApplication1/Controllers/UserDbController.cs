using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private UserDbService userService;

        public UserController(UserDbService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserDTO> users = userService.GetAll();

            return View(users);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            User user = userService.GetById(id);

            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            userService.Create(user);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            UserDTO user = userService.GetById(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            userService.Edit(user);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            UserDTO user = userService.GetById(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            userService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

