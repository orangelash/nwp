using System.Data.Entity;

namespace WebApplication2.Models
{
    public class Management
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Store_id { get; set; }
        public int clearence { get; set; }
    }
    public class ManagementDBContext : DbContext
    {
        public ManagementDBContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Management> Management { get; set; }
    }
}   