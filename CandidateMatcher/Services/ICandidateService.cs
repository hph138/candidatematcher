using System.Collections.Generic;
using CandidateMatcher.Data;
using System.Threading.Tasks;

namespace CandidateMatcher.Services
{
   public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> GetCandidates();
        Task<IEnumerable<Job>> GetTopJobs(string skills, int topJobs);
    }
}
