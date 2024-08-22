using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    namespace WebApplication7.Models

{
    public class Candidate
    {
            [Key]
            public int CandidateId { get; set; }

            [Required]
            public string LastName { get; set; }


            [Required]
            public string FirstName { get; set; }


        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits")]
        public string Mobile { get; set; }


        //[Display(Name = "Degree ID")]
        //public int DegreeID { get; set; }

        //[Display(Name = "Degree")]
        //public Degree? Degree { get; set; }

        [Display(Name = "Degrees")]
        public List<Degree> CandidateDegrees { get; set; }
        
        /*public IEnumerable<Degree> CandidateDegrees { get; set; } x;*/

        [DataType(DataType.Upload)]
        public string CV { get; set; }

        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;

    }
}
