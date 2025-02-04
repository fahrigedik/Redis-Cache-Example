using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Distributed.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        readonly IDistributedCache _distributedCache;
        public ValueController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var value = await _distributedCache.GetStringAsync("NAME");
            return Ok(value);
        }
        [HttpGet("Set")]
        public async Task<IActionResult> Set(string name)
        {
            await _distributedCache.SetStringAsync("NAME", name, new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60),
                SlidingExpiration = TimeSpan.FromSeconds(15)
            });
            return Ok();
        }

    }
}
