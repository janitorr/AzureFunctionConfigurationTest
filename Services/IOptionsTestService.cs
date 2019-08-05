using System.Threading.Tasks;

namespace AzureFunctionOptionsConfigurationWithIoC.Services
{
    public interface IOptionsTestService
    {
        Task<string> DoSomethingAsync();
    }
}