using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Feedback
    {
            public Feedback()
            {

            }
            public Feedback(int id, string email, string name, string message)
            {
                Id = id;
                Name = name;
                Message = message;
                Email = email;

            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Message { get; set; }
    }
}
