using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DTOs
{
    public class FeedbackDTO
    {
        public FeedbackDTO()
        {

        }

        public FeedbackDTO(int id, string email, string name, string message)
        {
            Id = id;
            Message = message;
            Name = name;
            Email = email;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
