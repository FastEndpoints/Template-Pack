using System.Diagnostics.CodeAnalysis;
using Xunit.MicrosoftTestingPlatform;
using Xunit.Runner.InProc.SystemConsole;

namespace MyProject.Tests;

public static class TestDiscoveryHandler
{
    public static bool IsTestRun(string[] args, [NotNullWhen(true)] out Func<Task<int>>? testRunner)
    {
        if (args.Contains("@@")) // this is a 'dotnet test' run from the test explorer
        {
            testRunner = () =>
                ConsoleRunner.Run(args);
            return true;
        }

        if (args.Any(a => a == "dotnettestcli")) // this is a 'dotnet test' run from the CLI
        {
            testRunner = () =>
                TestPlatformTestFramework.RunAsync(args, SelfRegisteredExtensions.AddSelfRegisteredExtensions);
            return true;
        }

        testRunner = null;
        return false;
    }
}
