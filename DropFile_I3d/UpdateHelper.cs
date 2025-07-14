using System.IO;
using System;

namespace DropFile_I3d
{
    internal static class UpdateHelper
    {
        public static bool IsAutoUpdateDisabled()
        {
            try
            {
                string configPath = Path.Combine(AppContext.BaseDirectory, "config.ini");
                if (File.Exists(configPath))
                {
                    var ini = new IniFile(configPath);
                    string value = ini.Read("Updater", "DisableAutoUpdater", "false");
                    return value.Equals("true", StringComparison.OrdinalIgnoreCase) || value == "1";
                }
            }
            catch
            {
                // Ignore any errors reading the config file
            }
            return false;
        }
    }
}
