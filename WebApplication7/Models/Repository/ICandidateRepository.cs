using WebApplication7.Models;
using WebApplication7.ViewModels;

namespace WebApplication7.Models.Repository
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAll();
        Task<Candidate?> GetCandidateById(int candidateId);

        Task<int> AddCandidateAsync(CandidateViewModel candidate);
        Task<int> Update(Candidate candidate);
        Task<int> Delete(int id);

        Task<int> UpdateCandidateAsync(CandidateEditViewModel candidate);
    }
}
