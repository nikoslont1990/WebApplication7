using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication7.Models.Repository;

namespace WebApplication7.Controllers
{
    public class CandidateController:Controller
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository= candidateRepository;  
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var candidates=await _candidateRepository.GetAll();
           return View(candidates);    
        }


        public async Task<IActionResult> Details(int id)
        {
            var candidate = await _candidateRepository.GetCandidateById(id);
            return View(candidate);
        }

        public async Task<IActionResult> Add()
        {
            //    try
            //    {
            //        IEnumerable<Category>? allCategories = await _categoryRepository.GetAllCategoriesAsync();
            //        IEnumerable<SelectListItem> selectListItems = new SelectList(allCategories, "CategoryId", "Name", null);

            //        PieAddViewModel pieAddViewModel = new() { Categories = selectListItems };
            //        return View(pieAddViewModel);
            //    }
            //    catch (Exception ex)
            //    {
            //        ViewData["ErrorMessage"] = $"There was an error: {ex.Message}";
            //    }
             return View();

        }



    }
}
