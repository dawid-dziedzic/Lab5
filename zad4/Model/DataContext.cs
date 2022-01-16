using Microsoft.EntityFrameworkCore;
using zad4.Model;

namespace zad4.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Film> filmy { get; set; }


     
    }
}
