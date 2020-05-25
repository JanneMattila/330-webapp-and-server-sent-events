using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;

        public EventsController(ILogger<EventsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task Get(CancellationToken cancellationToken)
        {
            Response.Headers.Add("Content-Type", "text/event-stream");

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var payload = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "\n";
                    await Response.WriteAsync(payload, cancellationToken);
                    await Response.Body.FlushAsync(cancellationToken);

                    await Task.Delay(TimeSpan.FromMilliseconds(500), cancellationToken);
                }
            }
            catch (TaskCanceledException)
            {
            }
        }
    }
}
