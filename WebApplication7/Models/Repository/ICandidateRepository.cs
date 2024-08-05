﻿using WebApplication7.Models;

namespace WebApplication7.Models.Repository
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAll();
        Task<Candidate?> GetCandidateById(int candidateId);

        Task<int> Add(Candidate candidate);
        Task<int> Update(Candidate candidate);
        Task<int> Delete(int id);
    }
}