using CandidateMatcher.Data;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CandidateMatcherTest
{
    public class TestCandidateMatcher
    {

        [Fact]
        public async Task GetJobData_Test()
        {
            bool any = false;
            TestServerProvider testServerProvider = new TestServerProvider();
            var client = testServerProvider.appService;
            var jobs = await client.InitData();
            
            foreach(var a in jobs.Item1)
            {
                any = (a != null);
                if (any) { break; }
            }
            Assert.True(any);
        }

        [Fact]
        public async Task GetCandidateData_Test()
        {
            bool any = false;
            TestServerProvider testServerProvider = new TestServerProvider();
            var client = testServerProvider.appService;
            var candidates = await client.InitData();

            foreach (var a in candidates.Item2)
            {
                any = (a != null);
                if (any) { break; }
            }
            Assert.True(any);
        }
    }
}
