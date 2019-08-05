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
    public class ConfigurationTestFunctionApplication
    {
        private readonly IConfigurationTestService _configurationTestService;
        private readonly ILogger<ConfigurationTestFunctionApplication> _logger;

        public ConfigurationTestFunctionApplication(IConfigurationTestService configurationTestService,
            ILogger<ConfigurationTestFunctionApplication> logger)
        {
            _configurationTestService = configurationTestService ??
                                        throw new ArgumentNullException(nameof(IConfigurationTestService));
            _logger = logger;
            ;
        }

        [FunctionName("ConfigurationTestTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]
            HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var configurationResult = await _configurationTestService.DoSomethingAsync();
            _logger.LogInformation($"Configuration Test Result :{configurationResult}");


            return new OkObjectResult(configurationResult);
        }
    }
}