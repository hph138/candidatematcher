using CandidateMatcher.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateMatcher.Services
{
    public interface IJobCandidateMatcher<T>
    {
       Task<IEnumerable<T>> GetTop(string jobSkills, int topCandidates);
    }
}