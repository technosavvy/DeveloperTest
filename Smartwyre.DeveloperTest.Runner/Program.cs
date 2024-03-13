using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types.Readers;
using System;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        
        // register dependencies
        builder.Services.AddScoped<IProductDataStore, ProductDataStore>();
        builder.Services.AddScoped<IRebateDataStore, RebateDataStore>();
        builder.Services.AddScoped<IRebateService, RebateService>();

        using var host = builder.Build();

        using IServiceScope serviceScope = host.Services.CreateScope();

        var services = serviceScope.ServiceProvider;

        var rebateService = services.GetRequiredService<IRebateService>();
        var breakFlag = false;
        while (!breakFlag)
        {   
            var request = new RebateRequestReader().Read().Request;

            var result = rebateService.Calculate(request);

            Console.WriteLine($"RebateStatus={result.Success}");

            Console.WriteLine($"Do you want to exist application then type y else press any key");
            var value = Console.ReadLine();
            if ( value.ToLower() == "y" ) {
                breakFlag = true;
            }
        }
    }
}
