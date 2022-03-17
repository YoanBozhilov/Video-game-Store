using System.Collections.Generic;
using WebApplication2.DTOs;

namespace WebApplication2.Services
{
    public interface IFeedbackService
    {
        void Create(FeedbackDTO feedbackDto);
        void Delete(int id);
        void Edit(int id, FeedbackDTO feedbackDto);
        List<FeedbackDTO> GetAll();
        FeedbackDTO GetById(int id);
    }
}