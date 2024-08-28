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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the 1-to-many relationship
            modelBuilder.Entity<Candidate>()
                .HasMany(c => c.CandidateDegrees)
                .WithOne(d => d.Candidate)
                .HasForeignKey(d => d.CandidateId);

            // Seed data
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    CandidateId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Mobile = "123-456-7890",
                    CV="PDF",
                    CreationTime = DateTime.Now
                },
                new Candidate
                {
                    CandidateId = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    Mobile = "098-765-4321",
                    CV="Word",
                    CreationTime = DateTime.Now
                }
            );

            modelBuilder.Entity<Degree>().HasData(
                new Degree
                {
                    DegreeId = 1,
                    Name = "Bachelor of Science",
                    CandidateId = 1,
                    CreationTime = DateTime.Now
                },
                new Degree
                {
                    DegreeId = 2,
                    Name = "Master of Science",
                    CandidateId = 1,
                    CreationTime = DateTime.Now
                },
                new Degree
                {
                    DegreeId = 3,
                    Name = "Associate Degree in Arts",
                    CandidateId = 2,
                    CreationTime = DateTime.Now
                }
            );
        }
    }
}
