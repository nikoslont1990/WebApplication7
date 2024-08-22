using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Degree
    {
        [Key]
        public int DegreeId { get; set; }

        
        public string Name { get; set; }

        //[Required]
        //public DateTime CreationTime { get; set; } = DateTime.Now;


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date added")]
        public DateTime? CreationTime { get; set; } = DateTime.Now;

        ////[Display(Name = "Candidate ID")]
        //public int CandidateId { get; set; }
    }
}
