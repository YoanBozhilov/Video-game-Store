using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {

            public User(int id, string email, string firstname, string lastname)
            {

                Id = id;
                FirstName = firstname;
                LastName = lastname;
                Email = email;

            }

            public int Id { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            
    }
}

