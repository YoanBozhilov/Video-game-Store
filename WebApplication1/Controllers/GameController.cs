using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class GameController : Controller
    {
            private GameServices gameService;

            public GameController(GameServices gameService)
            {
                this.gameService = gameService;
            }

            [HttpGet]
            public IActionResult Index()
            {
                List<Game> products = gameService.GetAll();

                return View(products);
            }

            [HttpGet]
            public IActionResult Details(int id)
            {
                Game product = gameService.GetById(id);

                return View(product);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(Game product)
            {
                gameService.Create(product);

                return RedirectToAction(nameof(Index));
            }

            [HttpGet]
            public IActionResult Edit(int id)
            {
                Game product = gameService.GetById(id);

                return View(product);
            }

            [HttpPost]
            public IActionResult Edit(Game product)
            {
                gameService.Edit(product);

                return RedirectToAction(nameof(Index));
            }

            [HttpGet]
            public IActionResult Delete(int id)
            {
                Game product = gameService.GetById(id);

                return View(product);
            }

            [HttpPost]
            public IActionResult DeleteConfirm(int id)
            {
                gameService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
    }
}
