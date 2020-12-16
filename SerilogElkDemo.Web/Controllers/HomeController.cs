using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Context;
using Serilog.Formatting.Json;
using SerilogElkDemo.Web.Models;

namespace SerilogElkDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Serilog.Core.Logger _myLogger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            _myLogger = new LoggerConfiguration()
                .WriteTo.Console()
                //.Enrich.FromLogContext()
                //.WriteTo.File(new JsonFormatter(), "log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public IActionResult Index()
        {
            //ILogger
            _logger.BeginScope("User: {username}", User.Identity?.Name);
            _logger.LogInformation("Hey! I'm in the Index!");
            try
            {

                for (int i = 0; i < 10; i++)
                {
                    _logger.LogInformation("For loop... {i}", i);
                    if (i == 5)
                    {
                        throw new Exception("ups!");
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Strange... something broke");
            }

            //Serilog

            //LogContext.PushProperty("User", User.Identity?.Name);
            //_myLogger.Information("User: {username}", User.Identity?.Name);
            //try
            //{

            //    for (int i = 0; i < 10; i++)
            //    {
            //        _myLogger.Information("For loop... {i}", i);

            //        if (i == 5)
            //        {
            //            throw new Exception("ups!");
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    _myLogger.Error(e, "Strange... something broke");
            //}

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
