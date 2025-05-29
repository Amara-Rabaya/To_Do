using Microsoft.EntityFrameworkCore;
using DAL.ModelsNew;

namespace DAL.DataBase
{
    public class DbContextDLA : DbContext
    {
        public DbContextDLA(DbContextOptions<DbContextDLA> options) : base(options) { }

        public DbSet<CityDAL> Cities { get; set; }
        public DbSet<LogsDAL> Logs { get; set; }
        public DbSet<Cuntry> Cuntry { get; set; }   
        public DbSet<ContinentDAL> Continent { get; set; }  
    }
}