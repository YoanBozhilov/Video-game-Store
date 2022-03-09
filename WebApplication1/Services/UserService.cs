using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {

        private IData data;
        private static int id = 4;

        public UserService(IData data)
        {
            this.data = data;
        }
        public void Create(UserDTO userDto)
        {
            User user = toEntity(userDto);
            user.Id = ++id;
            data.Users.Add(user);
        }

        public void Delete(int id)
        {
            User user = this.GetEntityById(id);
            data.Users.Remove(user);
        }

        public void Edit(int id, UserDTO userDto)
        {
            User user = this.GetEntityById(id);
            user.Email = userDto.Email;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
        }

        public List<UserDTO> GetAll()
        {
            return data.Users
                .Select(x => toDTO(x))
                .ToList();
        }

        public UserDTO GetById(int id)
        {
            return toDTO(GetEntityById(id));
        }

        private User GetEntityById(int id)
        {
            return data.Users.FirstOrDefault(u => u.Id == id);
        }

        private User toEntity(UserDTO userDTO)
        {
            return new User(userDTO.Id, userDTO.Email, userDTO.FirstName, userDTO.LastName);
        }

        private UserDTO toDTO(User user)
        {
            return new UserDTO(user.Id, user.Email, user.FirstName, user.LastName);
        }
    }
}
