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
            private GameService gameService;

            public GameController(GameService gameService)
            {
                this.gameService = gameService;
            }

            [HttpGet]
            public IActionResult Index()
            {
                List<Game> games = gameService.GetAll();

                return View(games);
            }

            [HttpGet]
            public IActionResult Details(int id)
            {
                Game game = gameService.GetById(id);

                return View(game);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(Game game)
            {
                gameService.Create(game);

                return RedirectToAction(nameof(Index));
            }

            [HttpGet]
            public IActionResult Edit(int id)
            {
                Game game = gameService.GetById(id);

                return View(game);
            }

            [HttpPost]
            public IActionResult Edit(Game game)
            {
                gameService.Edit(game);

                return RedirectToAction(nameof(Index));
            }

            [HttpGet]
            public IActionResult Delete(int id)
            {
                Game game = gameService.GetById(id);

                return View(game);
            }

            [HttpPost]
            public IActionResult DeleteConfirm(int id)
            {
                gameService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
    }
}
