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
        }


        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }

        [Test]
        public void TestGetById()
        {
            FeedbackDTO feedback = Create(1, "FirstName", "Email", "Message");
           
            feedbackService.CreateFeedback(feedback);

            FeedbackDTO dbFeedback = feedbackService.GetDTOById(1);

            Assert.AreEqual(dbFeedback.Message, "Message");
            Assert.AreEqual(dbFeedback.FirstName, "Name");
            Assert.AreEqual(dbFeedback.Email, "Email");
        }

        [Test]
        public void TestCreate()
        {

            FeedbackDTO feedback = Create(1, "FirstName", "Email", "Message");

            feedbackService.CreateFeedback(feedback);

            Feedback dbFeedback = context.Feedbacks.FirstOrDefault();

            Assert.NotNull(dbFeedback);
        }

        [Test]
        public void TestDelete()
        {
            FeedbackService postService = new FeedbackService(this.context);

            FeedbackDTO feedback = new FeedbackDTO();
            feedback.Id = 1;
            feedback.Message = "Message";
            feedback.Email = "Email";
            feedback.FirstName = "FirstName";

            feedbackService.CreateFeedback(feedback);

            feedbackService.DeleteFeedback(1);

            Feedback dbFeedback = context.Feedbacks.FirstOrDefault(x => x.Id == 1);
            Assert.Null(dbFeedback);
        }
    }
}
