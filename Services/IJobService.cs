
using System.Collections.Generic;
using System.Threading.Tasks;
using CandidateMatcher.Data;
namespace CandidateMatcher.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetJobs();
        Task<IEnumerable<Candidate>> GetTopCandidates(string skills, int topCandidates);
    }
}
