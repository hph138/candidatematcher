using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CandidateMatcherTest
{
    public class TestCandidateMatcher
    {
        [Fact]
        public async  Task GetDataTest()
        {
            var client = new TestServerProvider().client;
            var response = await client.GetAsync("https://private-76432-jobadder1.apiary-mock.com/");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
