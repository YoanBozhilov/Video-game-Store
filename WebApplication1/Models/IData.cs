using System.Collections.Generic;

namespace WebApplication1.Models
{
    public interface IData
    {
        List<User> Users { get; set; }
    }
}