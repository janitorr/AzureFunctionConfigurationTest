using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AzureFunctionOptionsConfigurationWithIoC.Modules;

namespace AzureFunctionOptionsConfigurationWithIoC
{
    public class OptionsTestFunctionApplication
    {
        private readonly ILogger<OptionsTestFunctionApplication> logger;
        private readonly TestSettings options;

        public OptionsTestFunctionApplication(IOptions<TestSettings> optionsTestService,
            ILogger<OptionsTestFunctionApplication> logger)
        {
            options = optionsTestService?.Value ?? throw new ArgumentNullException(nameof(optionsTestService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [FunctionName("OptionsHttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]
            HttpRequest req)
        {
            logger.LogInformation($"Options Test Result :{options}");

            return new OkObjectResult(options);
        }
    }
}