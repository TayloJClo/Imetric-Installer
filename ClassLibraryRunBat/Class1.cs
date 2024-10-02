using System.Diagnostics;
using System.Configuration.Install;
using System.ComponentModel;

[RunInstaller(true)]
public class CustomAction : Installer
{
    public override void Install(System.Collections.IDictionary stateSaver)
    {
        base.Install(stateSaver);
        ExecuteBatFile();
    }

    private void ExecuteBatFile()
    {
        // Path to your .BAT file (you might need to use the installed path)
        string batFilePath = Context.Parameters["targetdir"] + "yourfile.bat";

        ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + batFilePath);
        processInfo.CreateNoWindow = true;
        processInfo.UseShellExecute = false;
        processInfo.RedirectStandardOutput = true;
        processInfo.RedirectStandardError = true;

        Process process = Process.Start(processInfo);
        process.WaitForExit();
    }
}
