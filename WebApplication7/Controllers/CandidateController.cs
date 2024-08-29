using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.IO.Pipelines;
using System.Reflection.Metadata.Ecma335;
using WebApplication7.Models;
using WebApplication7.Models.Repository;
using WebApplication7.ViewModels;


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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var candidates = await _candidateRepository.GetAll();
            return Json(candidates);
        }

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            var candidate = await _candidateRepository.GetCandidateById(id);
            await _candidateRepository.Delete(candidate.CandidateId);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Add
        public async Task<IActionResult> Add()
        {
            try
            {
                var degrees = await _degreeRepository.GetAll();
                IEnumerable<SelectListItem> selectListItems = new SelectList(degrees, "DegreeId", "Name", null);
                CandidateViewModel viewModel = new CandidateViewModel
                {
                    AllDegrees = selectListItems,
                    ///*CandidateDegrees = degrees.ToList()/*// Populate with all degrees from the database
                    
                };


                return View(viewModel);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"There was an error: {ex.Message}";
            }
            return View(new CandidateViewModel());

        }

        [HttpPost]
        public async Task<IActionResult> Add(CandidateViewModel ncand)
         {
            try
            {


                //var sk=JsonConvert.DeserializeObject()
                if (ModelState.IsValid)
                {
                    List<SelectListItem> alldegrees = new List<SelectListItem>();
                    

                    

                    List<Degree> adddegrees = new List<Degree>();
                    
                    await _candidateRepository.AddCandidateAsync(ncand);

                    return RedirectToAction(nameof(Index));
                }
            }
 
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Adding the candidate failed, please try again! Error: {ex.Message}");
            }

            var degrees= await _degreeRepository.GetAll();
            ncand.AllDegrees = new SelectList(degrees, "DegreeId", "Name", null); 
            //model.AllDegrees= degrees.ToList();
            return View(ncand);
            
        }

        #endregion

        #region Update
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _candidateRepository.GetCandidateById(id.Value);
            
            IEnumerable<SelectListItem> selectListItems = new SelectList(candidate.CandidateDegrees, "DegreeId", "Name", null);
            CandidateEditViewModel editviewModel = new CandidateEditViewModel
            {
                Candidate = candidate,
                AllDegrees = selectListItems,
                ///*CandidateDegrees = degrees.ToList()/*// Populate with all degrees from the database

            };
            return View(editviewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CandidateEditViewModel newcandididate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _candidateRepository.UpdateCandidateAsync(newcandididate);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Updating the category failed, please try again! Error: {ex.Message}");
            }


            List<Degree> degreeList = new List<Degree>();
            if (newcandididate.SelectedDegrees.Count > 0)
            {
                foreach (var item in newcandididate.SelectedDegrees.ToList())
                {
                    degreeList.Add(await _degreeRepository.GetDegreeByIdAsync(item));
                }

                newcandididate.AllDegrees = new SelectList(degreeList, "DegreeId", "Name", null);
            }

            
            return View(newcandididate);
        }
        #endregion


    }
}
