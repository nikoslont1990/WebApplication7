using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;
using WebApplication7.Models;
using WebApplication7.Models.Repository;


namespace WebApplication7.Controllers
{
    public class CandidateController:Controller
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IDegreeRepository _degreeRepository;

        public CandidateController(ICandidateRepository candidateRepository, IDegreeRepository degreeRepository)
        {
            _candidateRepository= candidateRepository;
            _degreeRepository= degreeRepository;    
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
            //ViewBag.DegreeList = _degreeRepository.GetAll()
            //.Select(d => new { Value = d.DegreeId, Text = d.Name });

            //IEnumerable<Degree>? allDegrees = _degreeRepository.GetAll();
            //IEnumerable<SelectListItem> selectListItems = new SelectList(allDegrees, "DegreeId", "Name", "CreationTime");

            //CandidateAddViewModel candidateViewModel = new CandidateAddViewModel() {Degrees= selectListItems };
            var degrees =  await _degreeRepository.GetAll();
            ViewBag.DegreeList = degrees.ToList();
            //.Select(d => new { Value = d.De, Text = d.Text })
            //.ToList(); 
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Add(Candidate candidate,string CV)
         {
            try
            {
                if (ModelState.IsValid)
                {
                    Candidate cand = new()
                    {
                        FirstName = candidate.FirstName,
                        LastName = candidate.LastName,
                        Email = candidate.Email,
                        Mobile = candidate.Mobile,
                        CV = CV,
                        CreationTime = candidate.CreationTime,

                        CandidateDegrees = candidate.CandidateDegrees
                    };
                    
                        foreach (var degreeId in cand.CandidateDegrees)
                         {
                        var degree = await _degreeRepository.GetDegreeById(degreeId.DegreeId);
                        if (degree != null)
                        {
                            candidate.CandidateDegrees.ToList().Add(degree);
                        }
                    }
               

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Adding the pie failed, please try again! Error: {ex.Message}");
            }

            //var degrees = await _degreeRepository.GetAll();

            //IEnumerable<SelectListItem> selectListItems = new SelectList(allCategories, "CategoryId", "Name", null);

            //pieAddViewModel.Categories = selectListItems;


            return View(candidate);
            
        }

    }
}
