using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Entities;

namespace TravelGuide.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string settings = "Server=(localdb)\\MSSQLLocalDB; Database=TravelGuide;Trusted_Connection= true;";
            optionsBuilder.UseSqlServer(settings);
        }
        
            public DbSet<Attraction> Attractions { get; set; }
            public DbSet<City> Cities { get; set; }
            public DbSet<Menu> Menus { get; set; }
            public DbSet<Restaraunt> Restaraunts { get; set; }
            public DbSet<Review> Reviews { get; set; }
            public DbSet<ToDoList> ToDoLists { get; set; }
            public DbSet<TravelTip> TravelTips { get; set; }
            public DbSet<User> Users { get; set; }

        }
}
