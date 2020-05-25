using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
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
            while (!cancellationToken.IsCancellationRequested)
            {
                var payload = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss:ffff") + Environment.NewLine;
                await Response.WriteAsync(payload, cancellationToken);
                await Response.Body.FlushAsync(cancellationToken);

                await Task.Delay(TimeSpan.FromMilliseconds(500), cancellationToken);
            }
        }
    }
}
