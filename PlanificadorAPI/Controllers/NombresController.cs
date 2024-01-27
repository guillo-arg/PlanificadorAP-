using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace PlanificadorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NombresController : ControllerBase
    {      
        private readonly ILogger<NombresController> _logger;
        private readonly IMemoryCache _cache;
        private readonly IServiceTask _serviceTask;

        public NombresController(ILogger<NombresController> logger, IMemoryCache cache, IServiceTask serviceTask)
        {
            _logger = logger;
            _cache = cache;
            _serviceTask = serviceTask;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> response = _serviceTask.GetData();
            return response;
            
        }
    }
}
