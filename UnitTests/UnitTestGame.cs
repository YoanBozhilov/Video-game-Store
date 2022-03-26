using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WebApplication1.Models;
using WebApplication1.Services;
using System.Linq;
using WebApplication1.DTOs;
using System.Collections.Generic;

namespace UnitTests
{
    class UnitTestGame
    {
        private AllDbContext context;
        private GameService gameService;

        private Game Create(int id, string name, decimal price, string description, string link, string pic)
        {
            Game game = new Game();
            game.Id = id;
            game.Name = name;
            game.Price = price;
            game.Description = description;
            game.Link = link;
            game.Pic = pic;

            return game;
        }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AllDbContext>()
                .UseInMemoryDatabase("sql11.freemysqlhosting.net").Options;

            this.context = new AllDbContext(options);
            gameService = new GameService(this.context);
        }


        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }

        [Test]
        public void TestGetById()
        {
            Game game = Create(1, "Game Name", 56, "new", "dog", "cat");
            gameService.Create(game);

            Game dbGame = gameService.GetById(1);

            Assert.AreEqual(dbGame.Name, "Game Name");
            Assert.AreEqual(dbGame.Price, 56);
            Assert.AreEqual(dbGame.Description, "new");
            Assert.AreEqual(dbGame.Link, "dog");
            Assert.AreEqual(dbGame.Pic, "cat");
        }

        [Test]
        public void TestCreate()
        {

            Game game = Create(1, "Game Name", 56, "new", "dog", "cat");

            gameService.Create(game);

            Game dbGame = context.Games.FirstOrDefault();

            Assert.NotNull(dbGame);
        }
        [Test]
        public void TestEdit()
        {
            GameService postService = new GameService(this.context);

            Game game = new Game();
            game.Id = 1;
            game.Name = "Game Name";
            game.Price = 56;
            game.Description = "new";
            game.Link = "dog";
            game.Pic = "cat";

            gameService.Create(game);

            Game editGame = new Game();

            editGame.Id = 1;
            editGame.Name = "asd";
            editGame.Description = "sad";
            editGame.Price = 44;
            editGame.Link = "lion";
            editGame.Pic = "parrot";

            postService.Edit(editGame);

            Game dbGame = context.Games.FirstOrDefault(x => x.Id == 1);

            Assert.NotNull(dbGame);
            Assert.AreEqual(dbGame.Name, "asd");
            Assert.AreEqual(dbGame.Pic, "parrot");
            Assert.AreEqual(dbGame.Link, "lion");
            Assert.AreEqual(dbGame.Description, "sad");
            Assert.AreEqual(dbGame.Price, 44);
        }

        [Test]
        public void TestDelete()
        {
            GameService postService = new GameService(this.context);

            Game game = new Game();
            game.Id = 1;
            game.Name = "Game Name";
            game.Price = 56;
            game.Description = "new";
            game.Link = "new";
            game.Pic = "cat";


            gameService.Create(game);

            gameService.Delete(1);

            Game dbGame = context.Games.FirstOrDefault(x => x.Id == 1);
            Assert.Null(dbGame);
        }
    }
}
