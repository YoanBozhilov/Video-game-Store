using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;

namespace WebApplication1.DTOs
{
    public class FeedbackDTO
    {
        public FeedbackDTO()
        {

        }
        public FeedbackDTO(int id, string firstname, string email, string message)
        {
            Id = id;
            Message = message;
            FirstName = firstname;
            Email = email;

        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Message { get; set; }
    }
}
