using WebApplication7.Models;

namespace WebApplication7.ViewModels
{
    public class CandidateViewModel
    {
        public Candidate Candidate { get; set; }
        //public int CandidateId { get; set; }
        //public string Name { get; set; }
        public List<int> SelectedDegrees { get; set; } // To capture the selected degree IDs
        public List<Degree> AllDegrees { get; set; } // To populate the dropdown
    }
}
