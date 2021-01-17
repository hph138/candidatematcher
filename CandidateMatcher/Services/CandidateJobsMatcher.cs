using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidateMatcher.Content;
using CandidateMatcher.Data;
using Blazored.SessionStorage;

namespace CandidateMatcher.Services
{
    public class CandidateJobsMatcher : IJobCandidateMatcher<Job>
    {
        private ISessionStorageService _session;

        public CandidateJobsMatcher(ISessionStorageService session)
        {
            _session = session;
        }

        public async Task<IEnumerable<Job>> GetTop(string candidateSkills, int topCandidates)
        {
            Dictionary<Job, int> jobsMatched = new Dictionary<Job, int>();
            IEnumerable<Job> jobs = await _session.GetItemAsync<IEnumerable<Job>>("JobsList");
            if (jobs != null)
            {

                foreach (Job job in jobs)
                {
                    jobsMatched.Add(job, new Matcher().CountMatches(job.Skills, candidateSkills));
                }
            }
            else
            {
                return null;
            }

            var sortedDict = (from entry in jobsMatched orderby entry.Value descending select entry.Key)
                     .Take(topCandidates).AsEnumerable();

            return sortedDict;
        }
    }
}
