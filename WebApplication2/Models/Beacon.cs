using System.Data.Entity;


namespace WebApplication2.Models
{
    public class Beacon
    {
        public int id { get; set; }
        public string Description { get; set; }
        public string Store_id { get; set; }
        public string Location { get; set; }
    }

    public class BeaconDBContext : DbContext
    {
        public BeaconDBContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Beacon> Beacon { get; set; }
    }

}