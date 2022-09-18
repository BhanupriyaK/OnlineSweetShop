using Microsoft.EntityFrameworkCore;
using OnlineSweetShop1.Models;

namespace OnlineSweetShop.Models
{
    public class SweetContext : DbContext
    {
        public SweetContext(DbContextOptions<SweetContext> options) : base(options)
        {

        }
        public DbSet<SweetCategory> sweetCategories { get; set; }
        public object SweetCategories { get; internal set; }
        public DbSet<SweetProduct> sweetProducts { get; set; }
        public object SweetProducts { get; internal set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Offer> offers { get; set; }
  
        public DbSet<EventBookingReq> eventBookingReqs { get; set; }
      
        public DbSet<FeedBack> feedbacks { get; set; }
      
        public DbSet<Aspnetuser> Aspnetusers { get; set; }
      
        public DbSet<OnlineSweetShop1.Models.Contact> Contact { get; set; }
      
        public DbSet<OnlineSweetShop1.Models.Admin> Admin { get; set; }
      
        public DbSet<OnlineSweetShop1.Models.Location> Location { get; set; }
        
    }
}


