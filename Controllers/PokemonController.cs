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
    public static class PokemonController
    {
        [FunctionName("Pokemon")]
        public static async Task<IActionResult> GetByPlayerId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Pokemon")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string playerId = req.Query["playerId"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            playerId = playerId ?? data?.playerId;

            List<Pokemon> pokemon = new List<Pokemon>(){
                new Pokemon(){Id = 1, PlayerId = 1, Nickname = "Pokemon1", BreedId = 1 },
                new Pokemon(){Id = 2, PlayerId = 1, Nickname = "Pokemon2", BreedId = 1 },
                new Pokemon(){Id = 3, PlayerId = 2, Nickname = "Pokemon3", BreedId = 1 },
            };
            
            if(playerId != null){
                var playerPokemon = pokemon.Where(x => x.PlayerId.ToString() == playerId).ToList();

                if(playerPokemon != null){
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(playerPokemon);
                    return (ActionResult)new OkObjectResult(json);                
                }
                else {
                    return (ActionResult)new NotFoundObjectResult($"No Pokemon associated with player Id {playerId}");
                }
            }

            return new BadRequestObjectResult("Please pass a player id on the query string or in the request body");
        }
    }
}
