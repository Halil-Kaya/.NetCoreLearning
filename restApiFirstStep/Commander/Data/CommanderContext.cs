using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
         public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt){

         }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql("server=127.0.0.1;port=3305;username=root;password=;database=CommanderDb");
        }
        public DbSet<Command> Commands { get; set; }

    }
}