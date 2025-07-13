using ShiftLoggerUi.Utils;

namespace ShiftLoggerUi;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        await RunProgramUtil.RunProgram();
    }
}