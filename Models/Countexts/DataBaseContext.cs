using car_service.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace soundcloud_.Models.Countexts
{
    public class DataBaseContext:DbContext
    {
        private IConfiguration _configuration;
        public DataBaseContext(IConfiguration configuration) {



            _configuration = configuration;
        }
      
        public DbSet<User> Users { set; get; }

        public DbSet<Role> Roles { set; get; }
        public DbSet<Music> Musics { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DBConnection"));
        }

    }
}
