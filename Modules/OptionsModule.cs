using AzureFunctionOptionsConfigurationWithIoC.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureFunctionOptionsConfigurationWithIoC.Modules.OptionsModule))]

namespace AzureFunctionOptionsConfigurationWithIoC.Modules
{
    public class OptionsModule : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IOptionsTestService, OptionsTestOptionsTestService>();
            builder.Services.AddScoped<IConfigurationTestService, ConfigurationTestConfigurationTestService>();
            builder.Services.AddOptions<TestSettings>()
                .Configure<IConfiguration>((settings, configuration) => { configuration.Bind(settings); });
        }
    }

    public class TestSettings
    {
        public string Endpoint { get; set; }
        public string Token { get; set; }
    }
}