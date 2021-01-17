using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using CandidateMatcher;
using System.Net.Http;

namespace CandidateMatcherTest
{
    public class TestServerProvider
    {
        public HttpClient client { get; private set; }
        public TestServerProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            client = server.CreateClient();
        }
    }
}
