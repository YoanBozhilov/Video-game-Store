using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Data : IData
    {
        public List<Feedback> Feedbacks { get; set; }

        public Data()
        {
            this.Feedbacks = new List<Feedback>()
            {
                new Feedback(1,"ASd", "Gosho", "Goshev"),
                new Feedback(2,"ani123", "Ani", "Dimova"),
                new Feedback(3,"iva22", "Iva", "Stoyanova"),
                new Feedback(4,"gotinSimo12", "Simo", "Georgiev"),
            };
        }
    }
}
