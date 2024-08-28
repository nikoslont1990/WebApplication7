//using Microsoft.EntityFrameworkCore;
//using System.IO.Pipelines;

//namespace WebApplication7.Models
//{
//    public class DbInitializer
//    {
//        //public static void Seed(WebAppDBContext context)
//        //{
//        //    //if (!context.Degrees.Any())
//        //    //{
//        //    //    context.Degrees.AddRange(Degree.Select(c => c.Value));
//        //    //}

//        //    //context.SaveChanges();

//        public static void Seed(WebAppDBContext context)
//        {
//            //context.Database.EnsureDeleted();
//            context.Database.EnsureCreated();

      


//            var degrees1 = new List<Degree>
//        {
//            new Degree { DegreeId = 1,Name = "Bachelor of Science"},
//            new Degree { DegreeId = 2, Name = "Master of Science"}
//        };

//            var degrees2 = new List<Degree>
//        {
//            new Degree { DegreeId = 3,Name = "Associate Degree in Arts"}
//        };

//            // Create a list of candidates with their degrees
//            var candidates = new List<Candidate>
//            {
//            new Candidate
//            {
                
//                FirstName = "John",
//                LastName = "Doe",
//                Email = "john.doe@example.com",
//                Mobile = "123-456-7890",
//                CandidateDegrees = degrees1,
//                CV ="PDF" ,
//                CreationTime = DateTime.Now
//            },
//            new Candidate
//            {
                
//                FirstName = "Jane",
//                LastName = "Smith",
//                Email = "jane.smith@example.com",
//                Mobile = "098-765-4321",
//                CV ="Word",
//                CandidateDegrees = degrees2,
//                CreationTime = DateTime.Now
//            }
//            };
         
//            context.Candidates.AddRange(candidates);
//            //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Candidates OFF");
//            //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Degrees OFF");
//            context.SaveChanges();
            
//            //hahaha
//        }




//        //private static Dictionary<string, Category>? categories;

//        //public static Dictionary<string, Category> Categories
//        //{
//        //    get
//        //    {
//        //        if (categories == null)
//        //        {
//        //            var genresList = new Category[]
//        //            {
//        //                new Category { Name = "Fruit pies", DateAdded = DateTime.Today },
//        //                new Category { Name = "Cheese cakes", DateAdded = DateTime.Today },
//        //                new Category { Name = "Seasonal pies", DateAdded = DateTime.Today }
//        //            };

//        //            categories = new Dictionary<string, Category>();

//        //            foreach (Category genre in genresList)
//        //            {
//        //                categories.Add(genre.Name, genre);
//        //            }
//        //        }

//        //        return categories;
//        //    }
//        //}
//    }
//}
