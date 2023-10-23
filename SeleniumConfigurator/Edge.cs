using Microsoft.Win32;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumConfigurator;

public class EdgeNotInstalledException : Exception
{
	public EdgeNotInstalledException() : base("Microsoft Edge Not Installed") { }
}

public static class Edge
{
    private static string GetVersion()
    {
        using var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Edge\BLBeacon", true);
        string version = key?.GetValue("version") as string;
        return version;
}

    public static string GetDriverPath()
    {
        var version = GetVersion() ?? throw new EdgeNotInstalledException();
		var driverPath = new DriverManager().SetUpDriver(new EdgeConfig(), version);
        return driverPath;
    }
}