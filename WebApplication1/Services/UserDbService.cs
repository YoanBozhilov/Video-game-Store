using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserDbService
    {
            private UserDbContext dbContext;

            public UserDbService(UserDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public List<UserDTO> GetAll()
            {
                return dbContext.Users.Select(u=>ToDTO(u)).ToList();
            }

            public User GetById(int id)
            {
                return dbContext.Users.FirstOrDefault(p => p.Id == id);
            }

            public void Create(User user)
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }

            public void Edit(User user)
            {
                User dbUser = GetById(user.Id);

                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.Email = user.Email;

                dbContext.SaveChanges();
            }

            public void Delete(int id)
            {
                User dbUser = GetById(id);

                dbContext.Users.Remove(dbUser);
                dbContext.SaveChanges();
            }
        private static UserDTO ToDTO(User user)
        {
            return new UserDTO(user.Id, user.FirstName, user.LastName, user.Email);
        }
    }
}
