using Microsoft.Win32;
using System.Reflection;
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
		// Get Version or throw exception if Browser is not installed
		var version = GetVersion() ?? throw new EdgeNotInstalledException();
		// Bugfix: This will get the directory of the current assembly, not the directory of the working directory
		// This is important because the working directory would set to System32 if the program started as a startup task of Windows
		var binaryDirectory = AppContext.BaseDirectory;
		var driverManager = new DriverManager(binaryDirectory); // Override the default binary directory to the current assembly directory
		var driverPath = driverManager.SetUpDriver(new EdgeConfig(), version);
		return driverPath;
	}
}