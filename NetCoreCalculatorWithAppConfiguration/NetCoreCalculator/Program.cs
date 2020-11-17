using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Azure.Identity;
using Microsoft.Identity.Client;

namespace NetCoreCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 var settings = config.Build();
                 var credentials = new DefaultAzureCredential(
                     new DefaultAzureCredentialOptions
                     {
                         //ManagedIdentityClientId = "be1ad53a-d39e-4be4-98b7-088038d97bcd",
                         ExcludeEnvironmentCredential = true,
                         ExcludeManagedIdentityCredential = true,
                         ExcludeSharedTokenCacheCredential = true,
                         ExcludeVisualStudioCodeCredential = true,
                         ExcludeVisualStudioCredential = true
                     }
                     );

                 config.AddAzureAppConfiguration(options =>
                 {
                     options.Connect(new Uri("https://appconfigurationsample.azconfig.io"), credentials)
                             .ConfigureKeyVault(kv =>
                             {
                                 kv.SetCredential(credentials);
                             });
                 });
             })
            .UseStartup<Startup>()
            .Build();

    }
}
