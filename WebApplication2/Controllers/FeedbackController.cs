using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DTOs;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class FeedbackController : Controller
    {
        private IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        public IActionResult Index()
        {
            List<FeedbackDTO> feedbacks = feedbackService.GetAll();

            return View(feedbacks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FeedbackDTO feedback)
        {
            feedbackService.Create(feedback);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            FeedbackDTO feedback = feedbackService.GetById(id);

            return View(feedback);
        }

        [HttpPost]
        public IActionResult Edit(int id, FeedbackDTO feedback)
        {
            feedbackService.Edit(id, feedback);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            FeedbackDTO feedback = feedbackService.GetById(id);

            return View(feedback);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            feedbackService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

