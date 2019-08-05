using System.Threading.Tasks;

namespace AzureFunctionOptionsConfigurationWithIoC.Services
{
    public interface IConfigurationTestService
    {
        Task<string> DoSomethingAsync();
    }
}