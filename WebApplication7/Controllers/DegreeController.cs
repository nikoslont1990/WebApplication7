using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication7.Models.Repository;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class DegreeController : Controller
    {
        private readonly IDegreeRepository _degreeRepository;

        public DegreeController(IDegreeRepository degreeRepository)
        {
          
            _degreeRepository = degreeRepository;
        }


        [HttpGet]
        public  IActionResult Index()
        {
            var degrees = _degreeRepository.GetAll();
            return View(degrees);
        }


        public async Task<IActionResult> Details(int id)
        {
            var candidate = await _degreeRepository.GetDegreeById(id);
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

        [HttpPost]
        public async Task<IActionResult> Add(Degree degree)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Degree degree1 = new()
                    {
                        DegreeId = degree.DegreeId,
                        Name = degree.Name,
                        CreationTime = degree.CreationTime,

                    };

                    await _degreeRepository.Add(degree1);

                    ViewBag.DegreeList = new SelectList(_degreeRepository.GetAll(), "DegreeId", "DegreeName");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Adding the pie failed, please try again! Error: {ex.Message}");
            }

            //var allCategories = await _categoryRepository.GetAllCategoriesAsync();

            //IEnumerable<SelectListItem> selectListItems = new SelectList(allCategories, "CategoryId", "Name", null);

            //pieAddViewModel.Categories = selectListItems;

            return View(degree);
        }
    }
}
