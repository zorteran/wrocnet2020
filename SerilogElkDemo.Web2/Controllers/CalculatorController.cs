using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SerilogElkDemo.Web2.Controllers
{
    [ApiController]
    [Route("calculator")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("status")]
        public IActionResult Status()
        {
            return Ok();
        }

        [HttpPost]
        [Route("multi")]
        public string Multi([FromForm] int firstNumber, [FromForm] int secondNumber)
        {
            _logger.LogInformation("Multiplying...");
            _logger.LogDebug("Multiplication {firstNumber} and {secondNumber}", firstNumber, secondNumber);

            var result = (decimal)firstNumber * secondNumber;

            _logger.LogDebug("Result: {result}", result);
            return result.ToString("0.####");
        }


        [HttpPost]
        [Route("div")]
        public string Div([FromForm] int firstNumber, [FromForm] int secondNumber)
        {
            _logger.LogInformation("Dividing...");
            _logger.LogDebug("Division {firstNumber} and {secondNumber}", firstNumber, secondNumber);

            var result = (decimal)firstNumber / secondNumber;

            _logger.LogDebug("Result: {result}", result);
            return result.ToString("0.####");

        }
    }
}
