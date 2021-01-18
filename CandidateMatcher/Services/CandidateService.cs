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
        private readonly IAppDataService _appData;
        public CandidateService(HttpClient httpClient, ISessionStorageService session,IAppDataService appDataService)
        {
            _httpClient = httpClient;
            _session = session;
            _appData = appDataService;
        }

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            IEnumerable<Candidate> candidates = await _session.GetItemAsync<IEnumerable<Candidate>>("CandidatesList");
            if (candidates == null)
            {
                //AppDataService appData = new AppDataService(_httpClient, _session);
                var result = await _appData.InitData();
                candidates = result.Item2;
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
