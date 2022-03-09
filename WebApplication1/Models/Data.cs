using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Data : IData
    {
        public List<User> Users { get; set; }

        public Data()
        {
            this.Users = new List<User>()
            {
                new User("Ivan", "Petrov", "ivanpetrov@gmail.com"),
                new User("In", "Peov", "ivaetrov@gmail.com"),
                new User("Ian", "Ptrov", "ivaov@gmail.com"),
                new User("Ivn", "Prov", "itrov@gmail.com"),
            };
        }
    }
}
