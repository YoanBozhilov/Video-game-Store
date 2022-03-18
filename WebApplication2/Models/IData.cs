using System.Collections.Generic;

namespace WebApplication2.Models
{
    public interface IData
    {
        List<Feedback> Feedbacks { get; set; }
    }
}