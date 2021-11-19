using System;
using TestFunction.DataAccess;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(TestFunction.StartUp))]
namespace TestFunction
{
    internal class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string azureConnectionString = Environment.GetEnvironmentVariable("AzureConnectionString");
            
            builder.Services.AddDbContext<TestDemoDbContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, azureConnectionString));
        }
    }
}
