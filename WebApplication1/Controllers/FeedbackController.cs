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
    public class FeedbackController : Controller
    {
        private FeedbackService feedbackService;

        public FeedbackController(FeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpGet]
        public IActionResult IndexFeedback()
        {
            List<FeedbackDTO> feedbacks = feedbackService.GetAll();

            return View(feedbacks);
        }

        [HttpGet]
        public IActionResult DetailsFeedback(int id)
        {
            Feedback feedback = feedbackService.GetById(id);

            return View(feedback);
        }

        [HttpGet]
        public IActionResult CreateFeedback()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFeedback(FeedbackDTO feedback)
        {
            feedbackService.CreateFeedback(feedback);
            return RedirectToAction(nameof(IndexFeedback));
        }    

        [HttpGet]
        public IActionResult DeleteFeedback(int id)
        {
            FeedbackDTO feedback = feedbackService.GetDTOById(id);

            return View(feedback);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            feedbackService.DeleteFeedback(id);

            return RedirectToAction(nameof(IndexFeedback));
        }
    }
}
