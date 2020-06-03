using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RealTimeApp.Models;

namespace RealTimeApp.Database 
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Chat> Chats {get; set;}
        public DbSet<Message> Messages { get; set; }
    }
}