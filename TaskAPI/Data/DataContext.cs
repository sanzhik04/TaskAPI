using Microsoft.EntityFrameworkCore;
using TaskAPI;

namespace MyTaskAPI.Data
{

    // creating a datacontext to link to our database
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<MyTask> MyTasks { get; set; }


        
    }
}
