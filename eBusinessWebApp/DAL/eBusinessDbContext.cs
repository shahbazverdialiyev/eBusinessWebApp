using eBusinessWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eBusinessWebApp.DAL
{
    public class eBusinessDbContext:IdentityDbContext<AppUser>
    {
        public eBusinessDbContext(DbContextOptions<eBusinessDbContext> opt):base(opt){}
        public DbSet<Member> Members { get;set;}
        public DbSet<Image> Images { get;set;}
    }
}
