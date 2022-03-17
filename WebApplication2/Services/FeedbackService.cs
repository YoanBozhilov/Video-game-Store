using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class FeedbackService : IFeedbackService
    {
        private IData data;
        private static int id = 4;

        public FeedbackService(IData data)
        {
            this.data = data;
        }
        public void Create(FeedbackDTO feedbackDto)
        {
            Feedback feedback = toEntity(feedbackDto);
            feedback.Id = ++id;
            data.Feedbacks.Add(feedback);
        }

        public void Delete(int id)
        {
            Feedback feedback = this.GetEntityById(id);
            data.Feedbacks.Remove(feedback);
        }

        public void Edit(int id, FeedbackDTO feedbackDto)
        {
            Feedback feedback = this.GetEntityById(id);
            feedback.Email = feedbackDto.Email;
            feedback.Name = feedbackDto.Name;
            feedback.Message = feedbackDto.Message;

        }

        public List<FeedbackDTO> GetAll()
        {
            return data.Feedbacks
                .Select(x => toDTO(x))
                .ToList();
        }

        public FeedbackDTO GetById(int id)
        {
            return toDTO(GetEntityById(id));
        }

        private Feedback GetEntityById(int id)
        {
            return data.Feedbacks.FirstOrDefault(u => u.Id == id);
        }

        private Feedback toEntity(FeedbackDTO feedbackDTO)
        {
            return new Feedback(feedbackDTO.Id, feedbackDTO.Email, feedbackDTO.Name, feedbackDTO.Message);
        }

        private FeedbackDTO toDTO(Feedback feedback)
        {
            return new FeedbackDTO(feedback.Id, feedback.Email, feedback.Name, feedback.Message);
        }
    }
}

