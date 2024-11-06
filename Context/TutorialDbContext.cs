using Microsoft.EntityFrameworkCore;
using TutorialEx.Models;

namespace TutorialEx.Context
{
    public class TutorialDbContext:DbContext
    {
        public TutorialDbContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<Tutorial> Tutorials { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}
