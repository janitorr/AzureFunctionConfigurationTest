using System;
using System.Threading.Tasks;
using AzureFunctionOptionsConfigurationWithIoC.Modules;


namespace AzureFunctionOptionsConfigurationWithIoC.Services
{
    public class OptionsTestOptionsTestService : IOptionsTestService
    {
        private readonly TestSettings _settings;

        public OptionsTestOptionsTestService(TestSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(TestSettings));
        }


        public async Task<string> DoSomethingAsync()
        {
            return await Task.FromResult($"{_settings.Endpoint}:{_settings.Token}");
        }
    }
}