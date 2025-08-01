using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace AgentElite.Api.Controllers
{
    [ApiController]
    [Route("v1/util")]
    public class UtilController : ControllerBase
    {
        private readonly ILogger<UtilController> _logger;

        public UtilController(ILogger<UtilController> logger)
        {
            _logger = logger;
        }

        [HttpGet("new-uuid")]
        public IActionResult NewUuid()
        {
            var uuid = Guid.NewGuid().ToString();
            var acceptHeader = Request.Headers["Accept"].ToString();

            _logger.LogInformation("Generated UUID: {UUID} | Accept: {AcceptHeader}", uuid, acceptHeader);

            if (acceptHeader.Contains("text"))
            {
                _logger.LogInformation("Responding with plain text UUID");
                return Content(uuid, "text/markdown");
            }

            _logger.LogInformation("Responding with JSON UUID");
            return Ok(new { uuid });
        }
        [HttpGet("my-ip")]
        public IActionResult MyIp()
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            var country = Request.Headers["cf-ipcountry"].ToString();
            var userAgent = Request.Headers["User-Agent"].ToString();
            var acceptHeader = Request.Headers["Accept"].ToString();

            _logger.LogInformation("IP request — IP: {IP} | Country: {Country} | UA: {UserAgent}", ip, country, userAgent);

            if (acceptHeader.Contains("text"))
            {
                _logger.LogInformation("Responding with plain text IP");
                return Content(ip, "text/plain");
            }

            _logger.LogInformation("Responding with JSON IP data");

            return Ok(new
            {
                ip,
                country = string.IsNullOrEmpty(country) ? "N/A" : country,
                userAgent
            });
        }

    }
}
