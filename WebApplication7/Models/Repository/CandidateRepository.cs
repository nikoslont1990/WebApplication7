using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebApplication7.ViewModels;

namespace WebApplication7.Models.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly WebAppDBContext _dbContext;

        public CandidateRepository(WebAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddCandidateAsync(CandidateViewModel ncand)
        {

            bool candidateWithSameNameExist = await _dbContext.Candidates.AnyAsync(c => c.FirstName == ncand.Candidate.FirstName && c.LastName == ncand.Candidate.LastName);
            if (candidateWithSameNameExist)
            {
                throw new Exception("A Degree with the same name already exists");
            }


            Candidate cand = new()
            {
                FirstName = ncand.Candidate.FirstName,
                LastName = ncand.Candidate.LastName,
                Email = ncand.Candidate.Email,
                Mobile = ncand.Candidate.Mobile,
                CV = ncand.Candidate.CV,
                CreationTime = ncand.Candidate.CreationTime,


            };

            cand.CandidateDegrees = CandidateDegrees(ncand.SelectedDegrees);
            _dbContext.Candidates.Add(cand);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Candidate>> GetAll()
        {
            return await _dbContext.Candidates.Include(x => x.CandidateDegrees).OrderBy(x => x.CandidateId).ToListAsync();
        }

        public async Task<Candidate?> GetCandidateById(int id)
        {
            var s = _dbContext.Candidates.Any(x => x.CandidateId == id);
            if (s == null)
            {

                throw new ArgumentException($"The candidate with this id" + id + " can't be found.");
            }

            return await _dbContext.Candidates.Include(x => x.CandidateDegrees).FirstOrDefaultAsync(x => x.CandidateId == id);
        }

        public async Task<int> Update(Candidate candidate)
        {
            var ncandidate = await _dbContext.Candidates.FirstOrDefaultAsync(x => x.CandidateId == candidate.CandidateId);
            if (ncandidate != null)
            {

                ncandidate.FirstName = candidate.FirstName;
                ncandidate.LastName = candidate.LastName;
                ncandidate.Email = candidate.Email;

                _dbContext.Candidates.Update(ncandidate);

                return await _dbContext.SaveChangesAsync();
            }

            else
            {
                throw new ArgumentException($"The candidate update can't be found.");
            }
        }

        public async Task<int> Delete(int id)
        {
            var cand = await _dbContext.Candidates.FirstOrDefaultAsync(x => x.CandidateId == id);
            if (cand != null)
            {
                _dbContext.Candidates.Remove(cand);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The pie to delete can't be found.");
            }
        }

        public async Task<int> UpdateCandidateAsync(CandidateEditViewModel candidate)
        {
            bool existWithSameNameCandidate = _dbContext.Candidates.Any(x => x.FirstName == candidate.Candidate.FirstName && x.LastName == candidate.Candidate.LastName);
            if (existWithSameNameCandidate)
            {
                throw new Exception("A canidate with the same name already exists");

            }

            var candidateToUpdate = _dbContext.Candidates.Include(y => y.CandidateDegrees).FirstOrDefault(x => x.CandidateId == candidate.Candidate.CandidateId);
            if (candidateToUpdate != null)
            {
                List<Degree> updatelistDegree = new List<Degree>();
                //foreach (var selection in candidate.SelectedDegrees.ToList())
                //{
                //    if (_dbContext.Degrees.Select(x => x.DegreeId).Contains(selection))
                //    {
                //        //var deg = _dbContext.Degrees.Where(x => x.DegreeId == selection).FirstOrDefault();
                //        updatelistDegree.Add(_dbContext.Degrees.Where(x => x.DegreeId == selection).FirstOrDefault());
                //    }
                //}
                candidateToUpdate.FirstName = candidate.Candidate.FirstName;
                candidateToUpdate.LastName = candidate.Candidate.LastName;
                candidateToUpdate.Mobile = candidate.Candidate.Mobile;
                candidateToUpdate.Email = candidate.Candidate.Email;
                candidateToUpdate.CandidateId = candidate.Candidate.CandidateId;
                candidateToUpdate.CandidateDegrees = CandidateDegrees(candidate.SelectedDegrees);

                _dbContext.Candidates.Update(candidateToUpdate);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The candidate to update can't be found");
            }
        }

        private List<Degree> CandidateDegrees(List<int>? selectedDegree)
        {
            List<Degree> updatelistDegree = new List<Degree>();
            foreach (var selection in selectedDegree)
            {
                var lstDegree= _dbContext.Degrees.Select(x => x.DegreeId).ToList();
                if (lstDegree.Contains(Convert.ToInt32(selection)))
                {
                    //var deg = _dbContext.Degrees.Where(x => x.DegreeId == selection).FirstOrDefault();
                    updatelistDegree.Add(_dbContext.Degrees.Where(x => x.DegreeId == selection).FirstOrDefault());
                }
            }

            return updatelistDegree;    
        }
    }
}
