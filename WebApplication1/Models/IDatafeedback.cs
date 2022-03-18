using System.Collections.Generic;

namespace WebApplication1.Models
{
    public interface IDatafeedback
    {
        List<Feedback> Feedbacks { get; set; }
    }
}