namespace WebApplication7.Models.Repository
{
    public interface IDegreeRepository
    {

        Task<IEnumerable<Degree>> GetAll();
        Task<Degree?> GetDegreeByIdAsync(int DegreeId);

        Task<int> Add(Degree degree);
        //Task<int> Update(Degree degree);
        Task<int> DeleteCategoryAsync(Degree degree);

        Task<int> DeleteUnusedDegrees(); 
        
        Task<int>UpdateCategoryAsync(Degree degree);

        Task<int> Search(Degree degree);
    }
}
