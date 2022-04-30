using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions context) : base(context)
        {

        }
        public DbSet<ListModel> ListModel { get; set; }
    }
}
