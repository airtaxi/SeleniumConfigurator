using Microsoft.Win32;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumConfigurator;

public static class Edge
{
    private static string GetVersion()
    {
        try
        {
            var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Edge\BLBeacon", true);
            string version = key.GetValue("version") as string;
            return version;
        }
        catch (Exception) { return null; }
    }

    public static string GetDriverPath()
    {
        var version = GetVersion();
        if (version == null) throw new Exception("Microsoft Edge Not Installed");
        var driverPath = new DriverManager().SetUpDriver(new EdgeConfig(), version);
        return driverPath;
    }
}