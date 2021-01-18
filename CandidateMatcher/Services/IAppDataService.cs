using CandidateMatcher.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateMatcher.Services
{
    public interface IAppDataService
    {
        Task<(IEnumerable<Job>, IEnumerable<Candidate>)> InitData();
    }
}