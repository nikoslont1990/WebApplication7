namespace WebApplication7.Models.Repository
{
    public interface IDegreeRepository
    {

        IEnumerable<Degree> GetAll();
        Task<Degree?> GetDegreeById(int candidateId);

        Task<int> Add(Degree degree);
        Task<int> Update(Degree degree);
        Task<int> Delete(int id);

        Task<int> DeleteUnusedDegrees();

        Task<int> Search(Degree degree);
    }
}
