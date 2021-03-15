using AuthenticateAndRequest.Models;
using AuthenticateAndRequest.Services.Payload;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticateAndRequest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .AddCommandLine(args)
               .Build();

            //Setup DI
            var serviceProvider = new ServiceCollection()
                .AddOptions()
                .Configure<RequestProperties>(Configuration.GetSection("Request"))
                .AddSingleton<IAuthentication, STS>()
                .AddSingleton<IPayload, Json>()
                .BuildServiceProvider();

            var payloadSvc = serviceProvider.GetService<IPayload>();

            payloadSvc.SendRequest();
        }
    }
}
