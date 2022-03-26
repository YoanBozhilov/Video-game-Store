using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.Services;

namespace UnitTests
{
    public class Tests
    {
        private AllDbContext context;
        private UserService userService;

        private User Create(int id, string firstname, string lastname, string email)
        {
            User user = new User();
            user.Id = id;
            user.FirstName = firstname;
            user.LastName = lastname;
            user.Email = email;

            return user;
        }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AllDbContext>()
                .UseInMemoryDatabase("sql11.freemysqlhosting.net").Options;

            this.context = new AllDbContext(options);
            userService = new UserService(this.context);
        }


        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }

        [Test]
        public void TestGetById()
        {
            User user = Create(1, "FirstName", "LastName", "Email");
            userService.Create(user);

            User dbUser = userService.GetById(1);

            Assert.AreEqual(dbUser.FirstName, "FirstName");
            Assert.AreEqual(dbUser.LastName, "LastName");
            Assert.AreEqual(dbUser.Email, "Email");
        }

        [Test]
        public void TestCreate()
        {

            User user = Create(1, "FirstName", "LastName", "Email");

            userService.Create(user);

            User dbUser = context.Users.FirstOrDefault();

            Assert.NotNull(dbUser);
        }
        [Test]
        public void TestEdit()
        {
            UserService postService = new UserService(this.context);

            User user = new User();
            user.Id = 1;
            user.FirstName = "Yoan";
            user.LastName = "Bozhilov";
            user.Email = "yoanbbozhilov@gmail.com";

            userService.Create(user);

            User editUser = new User();

            editUser.Id = 1;
            editUser.FirstName = "asd";
            editUser.LastName = "sad";
            editUser.Email = "yoan";

            postService.Edit(editUser);

            User dbUser = context.Users.FirstOrDefault(x => x.Id == 1);

            Assert.NotNull(dbUser);
            Assert.AreEqual(dbUser.FirstName, "asd");
            Assert.AreEqual(dbUser.LastName, "sad");
            Assert.AreEqual(dbUser.Email, "yoan");
        }

        [Test]
        public void TestDelete()
        {
            UserService postService = new UserService(this.context);

            User user = new User();
            user.Id = 1;
            user.FirstName = "Yoan";
            user.LastName = "Bozhilov";
            user.Email = "yoanbbozhilov@gamil.com";

            userService.Create(user);

            userService.Delete(1);

            User dbUser = context.Users.FirstOrDefault(x => x.Id == 1);
            Assert.Null(dbUser);
        }
    }
}