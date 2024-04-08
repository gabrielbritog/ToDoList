using Am4ToDo.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Am4ToDo.Infra.Data 
{
    public class Am4ToDoContext : DbContext
    {
        public DbSet<TaskToDo> TaskToDo { get; set; }
        public Am4ToDoContext(DbContextOptions<Am4ToDoContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
