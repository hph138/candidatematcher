using CandidateMatcher.Data;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CandidateMatcher.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageService _session;

        public CandidateService(HttpClient httpClient,ISessionStorageService session)
        {
            _httpClient = httpClient;
            _session = session;
        }

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            IEnumerable<Candidate> candidates = await _session.GetItemAsync<IEnumerable<Candidate>>("CandidatesList");
            if (candidates == null)
            {
                AppDataService appData = new AppDataService(_httpClient, _session);
                await appData.InitData();
                candidates = await _session.GetItemAsync<IEnumerable<Candidate>>("CandidatesList");
            }
            return candidates;
        }

        public async Task<IEnumerable<Job>> GetTopJobs(string skills, int topJobs)
        {
            CandidateJobsMatcher jobMatcher = new CandidateJobsMatcher(_session);
            return await jobMatcher.GetTop(skills, topJobs);
        }
    }
}
