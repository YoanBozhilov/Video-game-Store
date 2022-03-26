using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class GameServices
    {
        
            private AllDbContext dbContext;

            public GameServices(AllDbContext dbContext)
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

            public void Create(Game game)
            {
                dbContext.Games.Add(game);
                dbContext.SaveChanges();
            }

            public void Edit(Game game)
            {
                Game dbProduct = GetById(game.Id);

                dbProduct.Name = game.Name;
                dbProduct.Price = game.Price;
                dbProduct.Description = game.Description;
                dbProduct.Link = game.Link;
                dbProduct.Pic = game.Pic;

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
