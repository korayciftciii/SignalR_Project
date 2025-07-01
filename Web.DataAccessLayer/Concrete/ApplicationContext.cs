using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.EntityLayer.Entities;

namespace Web.DataAccessLayer.Concrete
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SignalRProjectDB;User=DESKTOP-VJ74E6E\\koray; integrated Security=true;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Slider>Sliders {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Discount> Discounts {get; set;}
        public DbSet<Food> Foods{get; set;}
        public DbSet<FooterContent> FooterContents {get; set;}
        public DbSet<OpeningHour> OpeningHours {get; set;}
        public DbSet<Reservation>Reservations {get; set;}
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
