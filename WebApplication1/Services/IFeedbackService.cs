using System.Collections.Generic;
using WebApplication1.DTOs;

namespace WebApplication1.Services
{
    public interface IFeedbackService
    {
        void Create(FeedbackDTO feedbackDto);
        void Delete(int id);
        List<FeedbackDTO> GetAll();
        FeedbackDTO GetById(int id);
    }
}