using Dogs.WebAPI.Data;
using Dogs.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dogs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        // GET: api/<DogsController>
        [HttpGet("[action]")]
        public IEnumerable<DogShortInfo> GetDogShortInfo()
        {
            return DataSeeds.GetDog().Select(c => new DogShortInfo
            {
                name = c.Name,
                ImgUrl = c.ImgUrl,
                Family = c.Family,

            });
        }

        [HttpGet("[action]")]

        public   IEnumerable<Dog> GetDog()
        {
            return DataSeeds.GetDog().Select(x => new Dog
            {
                Id = x.Id,
                Name = x.Name
            });
        }



        // POST api/<DogsController>
        [HttpPost]
        public IResult Post([FromBody] object value)
        {
            Console.WriteLine(value);
            DogShortInfo a = JsonSerializer.Deserialize<DogShortInfo>(value.ToString());

            Console.WriteLine(a.id);
            return Results.Ok("Create1 succesful");
        }
    }
}
