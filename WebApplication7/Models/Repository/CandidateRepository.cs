using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly WebAppDBContext _dbContext;

        public CandidateRepository(WebAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Candidate candidate)
        {
           _dbContext.Candidates.AddAsync(candidate);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Candidate>> GetAll()
        {
            return await _dbContext.Candidates.OrderBy(x=>x.CandidateId).ToListAsync();
        }

        public async Task<Candidate?> GetCandidateById(int id)
        {
            var s = _dbContext.Candidates.Any(x => x.CandidateId == id);
            if (s == null) 
            {

                throw new ArgumentException($"The candidate with this id"+ id + " can't be found.");
            }

            return  await _dbContext.Candidates.FirstOrDefaultAsync(x => x.CandidateId == id);
        }

        public async Task<int> Update(Candidate candidate)
        {
            var ncandidate = await _dbContext.Candidates.FirstOrDefaultAsync(x => x.CandidateId == candidate.CandidateId);
            if(ncandidate != null)
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
            var cand = await _dbContext.Candidates.FirstOrDefaultAsync(x=>x.CandidateId==id);
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
    }
}
