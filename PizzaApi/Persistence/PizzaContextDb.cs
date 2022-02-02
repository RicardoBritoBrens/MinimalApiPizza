using Microsoft.EntityFrameworkCore;
using PizzaApi.Core.Models;

namespace PizzaApi.Persistence
{
    public class PizzaContextDb: DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public PizzaContextDb(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

    }
}
