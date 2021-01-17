using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidateMatcher.Content;
using CandidateMatcher.Data;
using Blazored.SessionStorage;

namespace CandidateMatcher.Services
{
    public class JobCandidatesMatcher : IJobCandidateMatcher<Candidate>
    {
        private ISessionStorageService _session;

        public JobCandidatesMatcher(ISessionStorageService session)
        {
            _session = session;
        }
        
        public  async Task<IEnumerable<Candidate>> GetTop(string jobSkills, int topCandidates)
        {
            Dictionary<Candidate, int> CandidateSkillsMatched = new Dictionary<Candidate, int>();
            IEnumerable<Candidate> candidates = await _session.GetItemAsync<IEnumerable<Candidate>>("CandidatesList");
            if (candidates != null)
            {

                foreach (Candidate candidate in candidates)
                {
                    CandidateSkillsMatched.Add(candidate, new Matcher().CountMatches(candidate.SkillTags, jobSkills));
                }
            }
            else
            {
                return null;
            }

            var sortedDict = (from entry in CandidateSkillsMatched orderby entry.Value descending select entry.Key)
                     .Take(topCandidates).AsEnumerable();

            return sortedDict;
        }
    }
}
