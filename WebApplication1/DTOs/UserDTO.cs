using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(int id, string username, string firstName, string lastName)
        {
            Id = id;
            Email = username;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
