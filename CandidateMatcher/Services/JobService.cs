using CandidateMatcher.Data;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.SessionStorage;

namespace CandidateMatcher.Services
{
    public class JobService : IJobService
    {
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageService _session;

        public JobService(HttpClient httpClient, ISessionStorageService session)
        {
            _httpClient = httpClient;
            _session = session;
        }
       public  async Task<IEnumerable<Job>> GetJobs()
        {
            IEnumerable<Job> jobs = await _session.GetItemAsync<IEnumerable<Job>>("JobsList");
            if (jobs == null)
            {
               AppDataService appData = new AppDataService(_httpClient,_session);
                await  appData.InitData();  
                jobs = await _session.GetItemAsync<IEnumerable<Job>>("JobsList");
            }
            return jobs;
        }

        public  async Task<IEnumerable<Candidate>> GetTopCandidates(string skills, int topCandidates)
        {
          JobCandidatesMatcher jobMatcher = new JobCandidatesMatcher(_session);
            return await jobMatcher.GetTop(skills, topCandidates);
        }

    }
}
