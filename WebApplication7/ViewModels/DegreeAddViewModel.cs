using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO.Pipelines;
using WebApplication7.Models;

namespace WebApplication7.ViewModels
{
    public class DegreeAddViewModel
    {
        public IEnumerable<SelectListItem>? SelectedDegrees { get; set; } = default!;
        public Candidate Candidate { get; set; }



    }
}
