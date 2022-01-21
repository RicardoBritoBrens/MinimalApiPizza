using Microsoft.EntityFrameworkCore;
using PizzaApi.Models;

namespace PizzaApi.Persistence
{
    public class PizzaDb: DbContext
    {
        public PizzaDb(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }
        public DbSet<Pizza> Pizzas { get; set; }
    }
}
