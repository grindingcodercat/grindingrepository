using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace reminderswebapi1.Data
{
    public class ToDoContext : DbContext
    {
        public DbSet<DbToDo> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=ToDos;Trusted_Connection=True;ConnectRetryCount=0");
        }
    }

    public class DbToDo
    {
        [Key]
        public int ToDoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; }
    }
}
