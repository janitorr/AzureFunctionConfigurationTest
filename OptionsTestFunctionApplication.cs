using System;
using System.Threading.Tasks;
using AzureFunctionOptionsConfigurationWithIoC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionOptionsConfigurationWithIoC
{
    public class OptionsTestFunctionApplication
    {
        private readonly ILogger<OptionsTestFunctionApplication> _logger;
        private readonly IOptionsTestService _optionsTestService;

        public OptionsTestFunctionApplication(IOptionsTestService optionsTestService,
            ILogger<OptionsTestFunctionApplication> logger)
        {
            _optionsTestService = optionsTestService ??
                                  throw new ArgumentNullException(nameof(IOptionsTestService));
            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger<OptionsTestFunctionApplication>));
        }

        [FunctionName("OptionsHttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]
            HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var optionsTestResult = await _optionsTestService.DoSomethingAsync();
            _logger.LogInformation($"Options Test Result :{optionsTestResult}");


            return new OkObjectResult(optionsTestResult);
        }
    }
}