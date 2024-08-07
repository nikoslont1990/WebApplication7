
using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models.Repository
{
    public class DegreeRepository : IDegreeRepository
    {

        private readonly WebAppDBContext _dbContext;    

        public DegreeRepository(WebAppDBContext dbContext)
        {
            _dbContext = dbContext; 
        }
       
        public async Task<int> Add(Degree degree)
        {
            _dbContext.Degrees.AddAsync(degree);
            return await _dbContext.SaveChangesAsync();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteUnusedDegrees()
        {
            var unusedDegrees = _dbContext.Degrees
                .Where(d => !_dbContext.Candidates.Any(c => c.CandidateDegrees.Any(x=>x.DegreeId==d.DegreeId)))
            .ToList();

            _dbContext.Degrees.RemoveRange(unusedDegrees);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Degree>> GetAll()
        {
            return await _dbContext.Degrees.ToListAsync();
        }

        public Task<Degree?> GetDegreeById(int candidateId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Search(Degree degree)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Degree degree)
        {
            throw new NotImplementedException();
        }
    }
}
