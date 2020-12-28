using Microsoft.EntityFrameworkCore;

namespace emre.Model
{
    public class KutuphaneContext : DbContext
    {

        public KutuphaneContext(){}

        public virtual DbSet<Kutuphane> Kutuphanes { get; set; }

        public KutuphaneContext(DbContextOptions<KutuphaneContext> options) : base(options){

        } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql("server=127.0.0.1;port=3306;username=root;password=;database=ktphn");
        }
        
    }
}