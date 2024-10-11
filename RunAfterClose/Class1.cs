using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting.Contexts;
using Microsoft.Win32.TaskScheduler;

[RunInstaller(true)]
public class CustomAction : Installer
{
    public override void Commit(System.Collections.IDictionary savedState)
    {
        base.Commit(savedState);

        // Path to the executable
        string targetDir = Context.Parameters["C:\\"];
        string exePath = Path.Combine(targetDir, "ICam4DSetup.exe");

        // Create a task to run the executable
        if (File.Exists(exePath))
        {
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Run MyApp after installation";
                td.Triggers.Add(new TimeTrigger { StartBoundary = DateTime.Now.AddSeconds(10) });
                td.Actions.Add(new ExecAction(exePath, null, null));
                ts.RootFolder.RegisterTaskDefinition(@"MyAppPostInstall", td);
            }
        }
    }
}
