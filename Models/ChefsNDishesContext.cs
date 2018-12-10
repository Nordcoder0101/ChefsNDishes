using Microsoft.EntityFrameworkCore;



namespace ChefsNDishes.Models
{
  public class ChefsNDishesContext : DbContext
  {
    public ChefsNDishesContext(DbContextOptions<ChefsNDishesContext> options) : base(options) { }
    public DbSet<Chef> Chef { get; set; }
    public DbSet<Dish> Dish {get; set;}
  }
}