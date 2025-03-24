using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FlagExplorer.Tests.Integration;

public class TestProgram
{
    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            // webBuilder.UseStartup<Startup>();
        });
}