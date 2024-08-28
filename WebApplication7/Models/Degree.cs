using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication7.Models
{
    public class Degree
    {
        [Key]
        public int DegreeId { get; set; }

        
        public string Name { get; set; }

        //[Required]
        //public DateTime CreationTime { get; set; } = DateTime.Now;

        
        public int? CandidateId { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date added")]
        public DateTime? CreationTime { get; set; } = DateTime.Now;


        public Candidate? Candidate { get; set; }
        ////[Display(Name = "Candidate ID")]
        //public int CandidateId { get; set; }
    }
}
