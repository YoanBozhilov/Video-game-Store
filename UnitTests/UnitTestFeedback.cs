using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.DTOs;

namespace UnitTests
{
    class UnitTestFeedback
    {
        private AllDbContext context;
        private FeedbackService feedbackService;

        private FeedbackDTO Create(int id, string firstname, string email, string message)
        {
            FeedbackDTO feedback = new FeedbackDTO();
            feedback.Id = id;
            feedback.Message = message;
            feedback.Email = email;
            feedback.FirstName = firstname;

            return feedback;
        }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AllDbContext>()
                .UseInMemoryDatabase("sql11.freemysqlhosting.net").Options;

            this.context = new AllDbContext(options);
            feedbackService = new FeedbackService(this.context);
            context.Users.Add(new User(1, "FirstName", "LastName", "Email"));
            context.SaveChanges();
            FeedbackDTO feedback = Create(1, "FirstName", "Email", "Message");
            feedbackService.CreateFeedback(feedback);
        }


        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }

        [Test]
        public void TestGetById()
        {
            Feedback dbFeedback = feedbackService.GetById(1);
            Assert.AreEqual(dbFeedback.Message, "Message");
        }

        [Test]
        public void TestCreate()
        {
            FeedbackDTO feedback = Create(2, "FirstName", "Email", "Message");
            feedbackService.CreateFeedback(feedback);
            Feedback dbFeedback = context.Feedbacks.FirstOrDefault(x => x.Id == 2);
            Assert.NotNull(dbFeedback);
        }

        [Test]
        public void TestDelete()
        {
            feedbackService.DeleteFeedback(1);

            Feedback dbFeedback = context.Feedbacks.FirstOrDefault(x => x.Id == 1);
            Assert.Null(dbFeedback);
        }
    }
}
