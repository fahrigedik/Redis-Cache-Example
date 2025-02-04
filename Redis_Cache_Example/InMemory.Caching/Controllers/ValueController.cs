using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private IMemoryCache _memoryCache;
        public ValueController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }


        [HttpGet("Set")]
        public void Set(string name)
        {
            _memoryCache.Set("name", name);
        }


        [HttpGet]
        public string Get()
        {
            if (_memoryCache.TryGetValue<string>("name", out var name))
            {
                return name;
            }
            //var nameTypeDefined = _memoryCache.Get<string>("name"); 
            return "No value found";
        }



        [HttpGet("SetDate")]

        public void SetDate()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(10)
            });
        }

        [HttpGet("GetDate")]
        public string GetDate()
        {
            if (_memoryCache.TryGetValue<DateTime>("date", out var date))
            {
                return date.ToString();
            }
            return "No value found";
        }
    }
}
