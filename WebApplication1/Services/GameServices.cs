using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class GameServices
    {
        
            private GameDbContext dbContext;

            public GameServices(GameDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public List<Game> GetAll()
            {
                return dbContext.Games.ToList();
            }

            public Game GetById(int id)
            {
                return dbContext.Games.FirstOrDefault(p => p.Id == id);
            }

            public void Create(Game product)
            {
                dbContext.Games.Add(product);
                dbContext.SaveChanges();
            }

            public void Edit(Game product)
            {
                Game dbProduct = GetById(product.Id);

                dbProduct.Name = product.Name;
                dbProduct.Price = product.Price;
                dbProduct.Description = product.Description;
                dbProduct.Link = product.Link;
                dbProduct.Pic = product.Pic;

                dbContext.SaveChanges();
            }

            public void Delete(int id)
            {
                Game dbProduct = GetById(id);

                dbContext.Games.Remove(dbProduct);
                dbContext.SaveChanges();
            }
        
    }
}
