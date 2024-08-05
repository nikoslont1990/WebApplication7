using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models
{
    public class WebAppDBContext : DbContext
    {
        public WebAppDBContext(DbContextOptions<WebAppDBContext> options) : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Degree> Degrees { get; set; }
    }
}
