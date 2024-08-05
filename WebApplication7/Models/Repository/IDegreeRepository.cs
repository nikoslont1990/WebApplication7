namespace WebApplication7.Models.Repository
{
    public interface IDegreeRepository
    {

        Task<IEnumerable<Degree>> GetAll();
        Task<Candidate?> GetDegreeById(int candidateId);

        Task<int> Add(Degree degree);
        Task<int> Update(Degree degree);
        Task<int> Delete(int id);

        Task<int> DeleteUnusedDegrees();

        Task<int> Search(Degree degree);
    }
}
