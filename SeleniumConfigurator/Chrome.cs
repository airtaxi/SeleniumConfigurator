using Microsoft.Win32;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumConfigurator;

public static class Chrome
{
    private static string GetVersion()
    {
        try
        {
            var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Google\Chrome\BLBeacon", true);
            string version = key.GetValue("version") as string;
            return version;
        }
        catch (Exception) { return null; }
    }

    public static string GetDriverPath()
    {
        var version = GetVersion();
        if (version == null) throw new Exception("Google Chrome Not Installed");
        var driverPath = new DriverManager().SetUpDriver(new ChromeConfig(), version);
        return driverPath;
    }
}