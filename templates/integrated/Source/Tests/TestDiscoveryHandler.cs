using System.Diagnostics.CodeAnalysis;
using Xunit.MicrosoftTestingPlatform;
using Xunit.Runner.InProc.SystemConsole;

namespace MyProject.Tests;

public static class TestDiscoveryHandler
{
    public static bool IsTestRun(string[] args, [NotNullWhen(true)] out Func<Task<int>>? testRunner)
    {
        // VS Test Explorer (VSTest) launches the exe with an xunit response file.
        if (args is ["@@", ..])
        {
            testRunner = () => ConsoleRunner.Run(args);
            return true;
        }

        // `dotnet test` (MTP). The SDK passes `--server dotnettestcli` plus `--dotnet-test-pipe`.
        if (args.Any(a => a is "--server" or "--internal-msbuild-node" or "dotnettestcli"))
        {
            testRunner = () =>
                TestPlatformTestFramework.RunAsync(args, SelfRegisteredExtensions.AddSelfRegisteredExtensions);
            return true;
        }

        testRunner = null;
        return false;
    }
}
