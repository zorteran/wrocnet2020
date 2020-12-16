using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Formatting.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SerilogElkDemo.Web.Services
{
    public class CalculatorService : ICalculatorService
    {
        private static int lag = 1;
        private readonly ILogger<CalculatorService> _logger;
        private readonly IRemoteCalculatorClient _remoteCalculatorClient;
        private readonly Logger _myLogger;

        public CalculatorService(ILogger<CalculatorService> logger,
            IRemoteCalculatorClient remoteCalculatorClient
            )
        {
            _logger = logger;
            _remoteCalculatorClient = remoteCalculatorClient;

            _myLogger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(new JsonFormatter(), "log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        public async Task<double> Add(int firstNumber, int secondNumber)
        {
            _logger.BeginScope("Wow such service");
            _logger.LogInformation("Adding {firstNumber} and {secondNumber}", firstNumber, secondNumber);

            var result = firstNumber + secondNumber;

            _logger.LogDebug("Result: {result}", result);
            return result;
        }

        public async Task<double> Div(int firstNumber, int secondNumber)
        {
            _logger.LogInformation("Dividing...");
            _logger.LogDebug("Div {firstNumber} and {secondNumber}", firstNumber, secondNumber);

            //try
            //{
            var result = firstNumber / secondNumber;
            _logger.LogDebug("Result: {result}", result);
            return result;
            //}
            //catch (Exception e)
            //{
            //    var log = CreateAwesomeErrorLog(e.Message, e);
            //    _myLogger.Error("{@log}", log);
            //    throw;
            //}
        }

        public async Task<double> Multi(int firstNumber, int secondNumber)
        {
            _logger.LogInformation("Multiplying...");
            _logger.LogDebug("Multi {firstNumber} and {secondNumber}", firstNumber, secondNumber);

            Thread.Sleep(lag * 1000);
            lag++;
            var result = (double)firstNumber * secondNumber;

            _logger.LogDebug("Result: {result}", result);
            return result;
        }

        public async Task<double> RemoteDiv(int firstNumber, int secondNumber)
        {
            _logger.LogInformation("Remote Div...");
            _logger.LogDebug("Multi {firstNumber} and {secondNumber}", firstNumber, secondNumber);
            try
            {
                var result = await _remoteCalculatorClient.Div(firstNumber, secondNumber);
                _logger.LogDebug("Result: {result}", result);
                return result;
            }
            catch (System.Exception e)
            {
                _logger.LogError("Nooooooooooooooooooo", e);
                throw e;
            }
        }

        public async Task<double> RemoteMulti(int firstNumber, int secondNumber)
        {
            _logger.LogInformation("Remote Multi...");
            _logger.LogDebug("Multi {firstNumber} and {secondNumber}", firstNumber, secondNumber);
            try
            {
                var result = await _remoteCalculatorClient.Multi(firstNumber, secondNumber);
                _logger.LogDebug("Result: {result}", result);
                return result;
            }
            catch (System.Exception e)
            {
                _logger.LogError("Nooooooooooooooooooo", e);
                throw e;
            }
        }

        public async Task<double> Sub(int firstNumber, int secondNumber)
        {
            _logger.LogInformation("Sub...");
            _logger.LogDebug("Sub {firstNumber} and {secondNumber}", firstNumber, secondNumber);

            var result = (double)firstNumber - secondNumber;

            _logger.LogDebug("Result: {result}", result);
            return result;
        }

        private AwesomeLog CreateAwesomeLog(string message)
        {
            return new AwesomeLog
            {
                Message = message,
                Location = nameof(CalculatorService),
            };
        }
        private AwesomeLog CreateAwesomeErrorLog(string message, Exception ex)
        {
            return new AwesomeLog
            {
                Message = message,
                Exception = ex,
                Location = nameof(CalculatorService),
            };
        }
    }

    public class AwesomeLog
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public string Location { get; set; }
    }
}
