using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
namespace CodegenDemo
{
    public static class Decide_Sentiment
    {
        [FunctionName("Decide_Sentiment")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            string sentiment = "GREEN";
            double score = await req.Content.ReadAsAsync<double>();
            if(score < 0.3){
                sentiment = "RED";
            }
            else if(score < 0.6){
                sentiment = "YELLOW";
            }
            return req.CreateResponse(System.Net.HttpStatusCode.OK,sentiment);
        }
    }
}
