using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication7.Models;

namespace WebApplication7.ViewModels
{
    public class CandidateEditViewModel
    {

        public Candidate Candidate { get; set; }
        public List<int>? SelectedDegrees { get; set; } // To capture the selected degree IDs
        public IEnumerable<SelectListItem>? AllDegrees { get; set; } // To populate the dropdown
    }
}
