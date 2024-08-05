using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Degree
    {
        [Key]
        public int DegreeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
