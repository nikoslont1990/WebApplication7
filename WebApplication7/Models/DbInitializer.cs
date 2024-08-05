using System.IO.Pipelines;

namespace WebApplication7.Models
{
    public class DbInitializer
    {
        //public static void Seed(WebAppDBContext context)
        //{
        //    //if (!context.Degrees.Any())
        //    //{
        //    //    context.Degrees.AddRange(Degree.Select(c => c.Value));
        //    //}

        //    //context.SaveChanges();

        public static void Seed(WebAppDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Candidates.Any())
            {
                return; // DB has been seeded
            }

            var candidates = new List<Candidate>
        {
            new Candidate
            {
                LastName = "Doe",
                FirstName = "John",
                Email = "john.doe@example.com",
                Mobile = "1234567890",
                CandidateDegrees = new List<Degree>
                {
                    new Degree { Name = "B.Sc. Computer Science",CreationTime=DateTime.Now },
                    new Degree { Name = "M.Sc. Computer Science",CreationTime=DateTime.Now }
                },
                CV = new byte[]{0},
                CreationTime = DateTime.Now
            },
            new Candidate
            {
                LastName = "Smith",
                FirstName = "Jane",
                Email = "jane.smith@example.com",
                Mobile = "0987654321",
                CandidateDegrees = new List<Degree>
                {
                    new Degree { Name = "B.A. English",CreationTime=DateTime.Now },
                    new Degree { Name = "M.A. English" , CreationTime = DateTime.Now}
                },
                CV = new byte[]{1},
                CreationTime = DateTime.Now
            }
        };

            context.Candidates.AddRange(candidates);
            context.SaveChanges();
        }




        //private static Dictionary<string, Category>? categories;

        //public static Dictionary<string, Category> Categories
        //{
        //    get
        //    {
        //        if (categories == null)
        //        {
        //            var genresList = new Category[]
        //            {
        //                new Category { Name = "Fruit pies", DateAdded = DateTime.Today },
        //                new Category { Name = "Cheese cakes", DateAdded = DateTime.Today },
        //                new Category { Name = "Seasonal pies", DateAdded = DateTime.Today }
        //            };

        //            categories = new Dictionary<string, Category>();

        //            foreach (Category genre in genresList)
        //            {
        //                categories.Add(genre.Name, genre);
        //            }
        //        }

        //        return categories;
        //    }
        //}
    }
}
