using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DTOs;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class FeedbackController : Controller
    {
        private FeedbackDbService feedbackService;

        public FeedbackController(FeedbackDbService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<FeedbackDTO> feedbacks = feedbackService.GetAll();

            return View(feedbacks);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Feedback feedback = feedbackService.GetById(id);

            return View(feedback);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Feedback feedback)
        {
            feedbackService.Create(feedback);

            return RedirectToAction(nameof(Index));
        }    

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Feedback feedback = feedbackService.GetById(id);

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
