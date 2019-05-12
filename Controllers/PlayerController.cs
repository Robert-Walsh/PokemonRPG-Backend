using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Controllers
{
    public static class PlayerController
    {
        [FunctionName("Player")]
        public static async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Player/{id}")] HttpRequest req, string id,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            id = id ?? data?.id;

            List<Player> players = new List<Player>(){
                new Player(){Id = 1, Name = "Robert"}
            };
            
            if(id != null){
                var player = players.FirstOrDefault(x => x.Id.ToString() == id);

                if(player != null){
                    return (ActionResult)new OkObjectResult($"Found player named {player.Name}");
                }
                else {
                    return (ActionResult)new OkObjectResult($"No player found with Id {id}");
                }
            }

            return new BadRequestObjectResult("Please pass an id on the query string or in the request body");
        }
    }
}
