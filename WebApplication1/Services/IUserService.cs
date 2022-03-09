using System.Collections.Generic;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        List<UserDTO> GetAll();
        void Create(UserDTO userDto);
        void Edit(int id, UserDTO userDto);
        void Delete(int id);
        UserDTO GetById(int id);
    }
}