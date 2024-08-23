using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            
            var degrees = await _degreeRepository.GetAll();
            var viewModel = new CandidateViewModel
            {
                AllDegrees = degrees.ToList() // Populate with all degrees from the database
                
            };

        
            return View(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Candidate candidate)
         {
            try
            {
                if (ModelState.IsValid)
                {
                    List<Degree> alldegrees = new List<Degree>();
                    foreach(var degree in candidate.CandidateDegrees)
                            {
                        degree.DegreeId = degree.DegreeId;
                        degree.Name = degree.Name;
                        alldegrees.Add(degree);
                    }
                    Candidate cand = new()
                    {
                        FirstName = candidate.FirstName,
                        LastName = candidate.LastName,
                        Email = candidate.Email,
                        Mobile = candidate.Mobile,
                        CV = candidate.CV,
                        CreationTime = candidate.CreationTime,
                         CandidateDegrees=alldegrees   
                    
                    };

                   var candidates= await _candidateRepository.AddCandidateAsync(cand);

                    return RedirectToAction(nameof(Index));
                }
            }
 
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Adding the pie failed, please try again! Error: {ex.Message}");
            }

            var degrees= await _degreeRepository.GetAll();
            //model.AllDegrees= degrees.ToList();
            return View(candidate);
            
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
            return View(candidate);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Candidate newcandididate)
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

            return View(newcandididate);
        }
        #endregion


    }
}
