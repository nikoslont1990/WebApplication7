
using Microsoft.AspNetCore.Mvc;
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
          
            bool degreeWithSameNameExist = await _dbContext.Degrees.AnyAsync(c => c.Name == degree.Name);

            if (degreeWithSameNameExist)
            {
                throw new Exception("A Degree with the same name already exists");
            }

            _dbContext.Degrees.Add(degree);//could be done using async too

            return await _dbContext.SaveChangesAsync();

        }

        

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteCategoryAsync(Degree degree)
        {
            bool degreeWithSameNameExist = await _dbContext.Degrees.AnyAsync(c => c.DegreeId == degree.DegreeId);
            //if (degreeWithSameNameExist)
            //{
            //    throw new Exception("A degree with the same name already exists");

            //}

            var deleteDegree = _dbContext.Degrees.FirstOrDefault(x => x.DegreeId == degree.DegreeId);
            if (deleteDegree != null)
            {
              

                _dbContext.Degrees.Remove(deleteDegree);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The degree to delete can't be found.");
            }
        }

        public async Task<int> DeleteUnusedDegrees()
        {
            var unusedDegrees = _dbContext.Degrees
                .Where(d => !_dbContext.Candidates.Any(c => c.CandidateDegrees.Any(y=>y.DegreeId == d.DegreeId)))
            .ToList();

            _dbContext.Degrees.RemoveRange(unusedDegrees);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Degree>> GetAll()
        {
            return await _dbContext.Degrees.OrderBy(c=>c.Name).ToListAsync();
        }

        public  async Task<Degree?> GetDegreeByIdAsync(int DegreeId)
        {
            return await _dbContext.Degrees.AsNoTracking().FirstOrDefaultAsync(c => c.DegreeId== DegreeId);


        }


        public Task<int> Search(Degree degree)
        {
            throw new NotImplementedException();
        }

    

        public async Task<int> UpdateCategoryAsync(Degree degree)
        {
            bool existWithSameName=_dbContext.Degrees.Any(x => x.Name==degree.Name);
            if(existWithSameName)
            {
                throw new Exception("A degree with the same name already exists");

            }

            var degreeToUpdate = _dbContext.Degrees.FirstOrDefault(x => x.DegreeId == degree.DegreeId); 
            if(degreeToUpdate != null) 
            {
                degreeToUpdate.Name = degree.Name;
                degreeToUpdate.DegreeId = degree.DegreeId;
                degreeToUpdate.CreationTime = degree.CreationTime;

                _dbContext.Degrees.Update(degreeToUpdate);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The category to update can't be found.");
            }

        }
    }
}
