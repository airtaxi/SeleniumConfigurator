using Microsoft.Win32;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumConfigurator;

public class ChromeNotInstalledException : Exception
{
	public ChromeNotInstalledException() : base("Google Chrome Not Installed") { }
}

public static class Chrome
{
    private static string GetVersion()
    {
        using var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Google\Chrome\BLBeacon", true);
        string version = key?.GetValue("version") as string;
        return version;
    }

    public static string GetDriverPath()
    {
        var version = GetVersion() ?? throw new ChromeNotInstalledException();
		var driverPath = new DriverManager().SetUpDriver(new ChromeConfig(), version);
        return driverPath;
    }
}