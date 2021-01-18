using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CandidateMatcher.Data;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;

namespace CandidateMatcher.Services
{
    public class AppDataService : IAppDataService
    {
        private HttpClient _httpClient;
        private ISessionStorageService _session;


        public AppDataService(HttpClient httpClient, ISessionStorageService session)
        {
            _httpClient = httpClient;
            _session = session;
        }

        public async Task<(IEnumerable<Job>, IEnumerable<Candidate>)> InitData()
        {
            IEnumerable<Job> jobs = await _session.GetItemAsync<IEnumerable<Job>>("JobsList");
            if (jobs == null)
            {
                jobs = await _httpClient.GetJsonAsync<Job[]>("jobs");
                await _session.SetItemAsync<IEnumerable<Job>>("JobsList", jobs);
            }

            IEnumerable<Candidate> candidates = await _session.GetItemAsync<IEnumerable<Candidate>>("CandidatesList");
            if (candidates == null)
            {
                candidates = await _httpClient.GetJsonAsync<Candidate[]>("candidates");
                await _session.SetItemAsync<IEnumerable<Candidate>>("CandidatesList", candidates);
            }
            return (jobs, candidates);
        }

    }
}