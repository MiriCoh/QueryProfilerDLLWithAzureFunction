using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using QueryProfiler.Optimization;
using QueryProfiler.Profile;
using QueryProfiler;
using System.Collections.Generic;

namespace OptimizationsAndQueryProfilerAzureFunction
{
    public static class QueryProfiler
    {
        [FunctionName("GetQueryProfiler")]
        public static async Task<ProfileScheme> Run(
              [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetQueryProfiler/{query}")] string query,
              ILogger log)
        {
            log.LogInformation("C# HTTP trigger function GetQueryProfiler processed a request.");
            return query != null ?
            ProfileAnalyzer.GetProfile(query) :
            new ProfileScheme();
        }
    }

   
}
