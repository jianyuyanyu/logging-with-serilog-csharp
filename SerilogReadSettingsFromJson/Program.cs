using Serilog;
using SerilogReadSettingsFromJson.Classes.Core;
using Spectre.Console;

namespace SerilogReadSettingsFromJson;
internal partial class Program
{
    static void Main(string[] args)
    {

        ThrowException();

        SpectreConsoleHelpers.ExitPrompt(Justify.Left);
    }


    private static void ThrowException()
    {
        try
        {
            var lines = File.ReadAllLines("NonExistentFile.txt");
            SpectreConsoleHelpers.PinkPill(Justify.Left, "read file");
        }
        catch (Exception e)
        {
           Log.Error(e, "An error occurred while reading the file."); 
           SpectreConsoleHelpers.ErrorPill(Justify.Left, "An error occurred while reading the file.");
           
        }
    }

}
