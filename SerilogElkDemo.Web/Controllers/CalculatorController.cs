using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using SerilogElkDemo.Web.Models;
using SerilogElkDemo.Web.Services;

namespace SerilogElkDemo.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;
        private readonly ILogger<CalculatorController> _logger;
        private readonly Serilog.Core.Logger _myLogger;

        public CalculatorController(ICalculatorService calculatorService,
                                    ILogger<CalculatorController> logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;

        }
        public ActionResult Index()
        {
            return View(new OperationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(OperationViewModel operation)
        {
            _logger.BeginScope("Wow, CalculatorController");


            _logger.LogInformation("Such action. Adding time!");
            operation.Result = await _calculatorService.Add(operation.FirstNumber, operation.SecondNumber);
            return View("Index", operation);
        }

        [HttpPost]
        public async Task<IActionResult> Sub(OperationViewModel operation)
        {
            operation.Result = await _calculatorService.Sub(operation.FirstNumber, operation.SecondNumber);
            return View("Index", operation);
        }
        [HttpPost]
        public async Task<IActionResult> Multi(OperationViewModel operation)
        {
            operation.Result = await _calculatorService.Multi(operation.FirstNumber, operation.SecondNumber);
            return View("Index", operation);
        }
        [HttpPost]
        public async Task<IActionResult> Div(OperationViewModel operation)
        {
            operation.Result = await _calculatorService.Div(operation.FirstNumber, operation.SecondNumber);
            return View("Index", operation);
        }
        [HttpPost]
        public async Task<IActionResult> RemoteMulti(OperationViewModel operation)
        {
            operation.Result = await _calculatorService.RemoteMulti(operation.FirstNumber, operation.SecondNumber);
            return View("Index", operation);
        }
        [HttpPost]
        public async Task<IActionResult> RemoteDiv(OperationViewModel operation)
        {
            operation.Result = await _calculatorService.RemoteDiv(operation.FirstNumber, operation.SecondNumber);
            return View("Index", operation);
        }

        //private AwesomeLog CreateAwesomeLog(string message)
        //{
        //    return new AwesomeLog
        //    {
        //        Message = message,
        //        Location = nameof(CalculatorController),
        //    };
        //}
        //private AwesomeLog CreateAwesomeErrorLog(string message, Exception ex)
        //{
        //    return new AwesomeLog
        //    {
        //        Message = message,
        //        Exception = ex,
        //        Location = nameof(CalculatorController),
        //    };
        //}
    }
}
