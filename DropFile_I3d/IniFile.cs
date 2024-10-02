using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

public class IniFile
{
    private string path;

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    public IniFile(string INIPath)
    {
        path = INIPath;
    }

    public void Write(string section, string key, string value)
    {
        WritePrivateProfileString(section, key, value, path);
    }

    public string Read(string section, string key, string defaultValue = "")
    {
        var retVal = new StringBuilder(255);
        GetPrivateProfileString(section, key, defaultValue, retVal, 255, path);
        return retVal.ToString();
    }
}
