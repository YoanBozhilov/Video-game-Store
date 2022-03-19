using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class FeedbackService
    {
        private AllDbContext dbContext;

        public FeedbackService(AllDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<FeedbackDTO> GetAll()
        {
            return dbContext.Feedbacks.Select(u => ToDTO(u)).ToList();
        }

        public Feedback GetById(int id)
        {
            return dbContext.Feedbacks.FirstOrDefault(p => p.Id == id);
        }

        public void Create(Feedback feedback)
        {
            dbContext.Feedbacks.Add(feedback);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Feedback dbFeedback = GetById(id);

            dbContext.Feedbacks.Remove(dbFeedback);
            dbContext.SaveChanges();
        }
        private static FeedbackDTO ToDTO(Feedback feedback)
        {
            return new FeedbackDTO(feedback.Id, feedback.Email, feedback.Name, feedback.Message);
        }
    }
}
