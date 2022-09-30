using Microsoft.EntityFrameworkCore;

namespace Ecommerces_MS.Models
{
    public class UserdbContext : DbContext
    {
        public DbSet<Usermodel> Customer4 { get; set; }


        public static string ConnectionString
        {
            get;
            set;
        }

        public void BuildConnectionString(string dbstring)
        {
            ConnectionString = dbstring;
        }
        public UserdbContext(DbContextOptions<UserdbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usermodel>(eb =>

            {
                eb.HasKey("username");

            });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NO86JCG;Initial Catalog=ganesha;Integrated Security=True");
            //Configuration.GetConnectionString("TO-DB"));
            if (!string.IsNullOrEmpty(ConnectionString)) optionsBuilder.UseSqlServer(ConnectionString);

        }

    }
}
