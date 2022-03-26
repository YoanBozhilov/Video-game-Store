using Microsoft.EntityFrameworkCore;
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
            return dbContext.Feedbacks.Include(f=>f.User).Select(u => ToDTO(u)).ToList();
        }

        public Feedback GetById(int id)
        {
            return dbContext.Feedbacks.FirstOrDefault(p => p.Id == id);
        }
        public FeedbackDTO GetDTOById(int id)
        {
            return ToDTO(dbContext.Feedbacks.Include(f => f.User).FirstOrDefault(p => p.Id == id));
        }

        public void CreateFeedback(FeedbackDTO feedback)
        {
            User user = dbContext.Users.FirstOrDefault(p => p.FirstName == feedback.FirstName && p.Email == feedback.Email);
            if(user == null)
            {
                return;
            }
            Feedback newFeedback = new Feedback();
            newFeedback.Message = feedback.Message;
            newFeedback.User = user;
            dbContext.Feedbacks.Add(newFeedback);
            dbContext.SaveChanges();
        }

        public void DeleteFeedback(int id)
        {
            Feedback dbFeedback = GetById(id);

            dbContext.Feedbacks.Remove(dbFeedback);
            dbContext.SaveChanges();
        }
        private static FeedbackDTO ToDTO(Feedback feedback)
        {
            return new FeedbackDTO(feedback.Id,feedback.User.FirstName,feedback.User.Email, feedback.Message);
        }
    }
}
