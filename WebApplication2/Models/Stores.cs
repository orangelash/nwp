using System.Data.Entity;

namespace WebApplication2.Models
{
    public class Stores
    {
        public int id { get; set; }
        public int Manager_id { get; set; }
        public string Name { get; set; }
    }

    public class StoresDBContext : DbContext
    {
        public StoresDBContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Stores> Stores { get; set; }
    }
}