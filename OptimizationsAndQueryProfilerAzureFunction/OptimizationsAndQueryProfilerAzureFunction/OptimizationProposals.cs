using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using QueryProfiler.Optimization;
using QueryProfiler.Profile;
using QueryProfiler;
using System.Collections.Generic;

namespace OptimizationsAndQueryProfilerAzureFunction
{//pr
    public static class OptimizationProposals
    {
        [FunctionName("GetOptimizationProposalsForQuery")]
        public static async Task<List<ProposalScheme>> Run(
         [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetOptimizationProposalsForQuery/{query}")] string query,
         ILogger log)
        {
            log.LogInformation("C# HTTP trigger function GetOptimizationProposalsForQuery processed a request.");
            System.Console.WriteLine(query);
            return query != null ?
            OptimalProposalForQuery.GetListOfPropsalToQuery(query) :
            new List<ProposalScheme>();
        }

    }
   
}
