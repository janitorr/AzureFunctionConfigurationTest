using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AzureFunctionOptionsConfigurationWithIoC.Services
{
    public class ConfigurationTestConfigurationTestService : IConfigurationTestService
    {
        private string _endpoint;
        private string _token;

        public ConfigurationTestConfigurationTestService(IConfiguration configuration)
        {
            _endpoint = configuration.GetSection("Endpoint").Value;
            _token = configuration.GetSection("Token").Value;
        }

        public async Task<string> DoSomethingAsync()
        {
            return await Task.FromResult($"{_endpoint}:{_token}");
        }
    }
}