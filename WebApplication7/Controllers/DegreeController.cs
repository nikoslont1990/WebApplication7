using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication7.Models.Repository;
using WebApplication7.Models;
using WebApplication7.ViewModels;

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
        public async Task<IActionResult> Index()
        {
            DegreeListViewModel model = new()
            {
                Degrees = (await _degreeRepository.GetAll()).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            DegreeListViewModel model = new()
            {
                Degrees = (await _degreeRepository.GetAll()).ToList()
            };
            return Json(model);
        }




        public async Task<IActionResult> Delete(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _degreeRepository.GetDegreeByIdAsync(id);
            return View(candidate);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Degree degree)
        {
            try
            {
                
                    await _degreeRepository.DeleteCategoryAsync(degree);
                    return RedirectToAction(nameof(Index));
              
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Deleting the degree failed, please try again! Error: {ex.Message}");
            }

            return View(degree);
        }


        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var degree = await _degreeRepository.GetDegreeByIdAsync(id.Value);
            return View(degree);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Degree degree)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _degreeRepository.UpdateCategoryAsync(degree);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Updating the degree failed, please try again! Error: {ex.Message}");
            }

            return View(degree);
        }



        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Degree degree)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    await _degreeRepository.Add(degree);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Adding the degree failed, please try again! Error: {ex.Message}");
            }

     

            return View(degree);
        }
    }
}
    

