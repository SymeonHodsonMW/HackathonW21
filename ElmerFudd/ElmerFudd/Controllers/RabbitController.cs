using ElmerFudd.Messages;
using ElmerFudd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmerFudd.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitController : ControllerBase {

        private readonly ILogger<RabbitController> _logger;
        private readonly IRabbitServices _rabbitServices;

        public RabbitController(ILogger<RabbitController> logger, IRabbitServices rabbitServices) {
            _logger = logger;
            _rabbitServices = rabbitServices;
        }

        [HttpGet("GetDemoMessage")]
        public async Task<IActionResult> GetDemoMessage(bool acknowledge) {
            try {
                var message = _rabbitServices.GetDemoMessage(acknowledge);
                return Ok(message);
            } catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = ex.Message, Exception = ex });
            }
        }

        [HttpPost("CreateDemoMessage1")]
        public async Task<IActionResult> CreateDemoMessage1(string title) {
            try {
                _rabbitServices.CreateDemoMessage1(title);
                return Ok();
            } catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = ex.Message, Exception = ex });
            }
        }

        [HttpPost("CreateDemoMessage2")]
        public async Task<IActionResult> CreateDemoMessage2(string title, string comment) {
            try {
                _rabbitServices.CreateDemoMessage2(title, comment);
                return Ok();
            } catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = ex.Message, Exception = ex });
            }
        }

        [HttpPost("PublishDemoMessage")]
        public async Task<IActionResult> PublishDemoMessage(string message) {
            try {
                _rabbitServices.PublishMessage(message);
                return Ok();
            } catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = ex.Message, Exception = ex });
            }
        }
    }
}
