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
                new User(1,"ASd", "Gosho", "Goshev"),
                new User(2,"ani123", "Ani", "Dimova"),
                new User(3,"iva22", "Iva", "Stoyanova"),
                new User(4,"gotinSimo12", "Simo", "Georgiev"),
            };
        }
    }
}
