using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using CandidateMatcher;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Blazored.SessionStorage;
using Microsoft.JSInterop;
using Moq;

namespace CandidateMatcherTest
{
    public class TestServerProvider
    {
        public HttpClient client { get; private set; }
        public  IServiceCollection services;
        public IServiceProvider serviceProvider;
        public CandidateMatcher.Services.IAppDataService appService;

        public TestServerProvider()
        {
            var mockJsRuntime = new Mock<IJSRuntime>().Object;
            services = new ServiceCollection();
            services.AddHttpClient<CandidateMatcher.Services.IAppDataService, CandidateMatcher.Services.AppDataService>(client =>
            {
                client.BaseAddress = new Uri("https://private-76432-jobadder1.apiary-mock.com/jobs");
            });
             services.AddSingleton<IJSRuntime>(mockJsRuntime);
            services.AddScoped<ISessionStorageService, SessionStorageService>();
            services.AddBlazoredSessionStorage();
            serviceProvider = services.BuildServiceProvider();
            appService = serviceProvider.GetService<CandidateMatcher.Services.IAppDataService>();
       
        }
    }
}
