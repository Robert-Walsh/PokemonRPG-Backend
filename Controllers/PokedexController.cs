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
    public static class PokedexController
    {
        [FunctionName("Pokedex")]
        public static async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Pokedex")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            Pokedex pokedex = new Pokedex(){
                Id = 1
            };
            List<PokedexEntry> entries = new List<PokedexEntry>(){
                new PokedexEntry(){
                    Id = 1, 
                    PokedexId = 1,
                    PokemonBreedId = 1,
                    Entry = "A pokemon description",
                    EvolvesFromBreedId = 0,
                    Generation = 1,
                    Type1Id = 1,
                    Type2Id = 0
                },
                new PokedexEntry(){                    
                    Id = 1, 
                    PokedexId = 1,
                    PokemonBreedId = 2,
                    Entry = "A pokemon description",
                    EvolvesFromBreedId = 1,
                    Generation = 1,
                    Type1Id = 1,
                    Type2Id = 0
                },
                new PokedexEntry(){                   
                    Id = 3, 
                    PokedexId = 1,
                    PokemonBreedId = 3,
                    Entry = "A pokemon description",
                    EvolvesFromBreedId = 2,
                    Generation = 1,
                    Type1Id = 1,
                    Type2Id = 0
                }
            };

            if(entries!=null){
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(entries);
                return (ActionResult)new OkObjectResult(json);
            }
            else if(entries == null){
                return (ActionResult)new OkObjectResult("No Pokemon found in Pokedex");
            }
            else{
                return new BadRequestObjectResult("Bad request for Pokedex");
            }
        }
    }
}
