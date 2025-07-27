using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShiftLoggerUi.Repositories;
using ShiftLoggerUi.Services;
using ShiftLoggerUi.Services.Interfaces;
using ShiftLoggerUi.Utils;

namespace ShiftLoggerUi;

class Program
{
    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
        {
            services.AddHttpClient("ShiftLoggerApi", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7145/");
            });
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IShiftRepository, ShiftRepository>();
            services.AddSingleton<RunProgramUtil>();
        }).Build();
        
        var runProgramUtil = host.Services.GetRequiredService<RunProgramUtil>();
        await runProgramUtil.RunProgram();
    }
}