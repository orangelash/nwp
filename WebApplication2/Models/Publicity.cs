using System.Data.Entity;

namespace WebApplication2.Models
{
    public class Publicity
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int Parent_Beacon_id { get; set; }
    }

    public class PublicityDBContext : DbContext
    {
        public PublicityDBContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Publicity> Publicity{ get; set; }
    }

}