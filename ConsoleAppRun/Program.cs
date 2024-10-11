using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32.TaskScheduler;
using System.Threading.Tasks;
using System.Security.AccessControl;

class ConsoleAppRunAfter
{
    static void Main(string[] args)
    {
        // Path to the EXE file you want to run
        string exePath = @"C:\I3D_Software\ICam4DSetup\ICam4DSetup.exe";
        File.AppendAllText(@"C:\I3D_Software\Logfile.txt", "Running");


        // Create a task to run the executable
        if (File.Exists(exePath))
        {
            // Use the local user's username
            string localUsername = string.Format("{0}\\{1}", Environment.MachineName, Environment.UserName);
            // You can specify a different local username if needed

            File.AppendAllText(@"C:\I3D_Software\Logfile.txt", "Found");
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Run ICam4DSetup after installation";
                td.Triggers.Add(new TimeTrigger { StartBoundary = DateTime.Now.AddSeconds(30) });

                td.Actions.Add(new ExecAction(exePath, null, null));
                //ts.Execute(@"ICamInstaller");
                td.Settings.Priority = ProcessPriorityClass.High;
                td.Settings.StartWhenAvailable = true;
                // Set the security options to run as the local user
                td.Principal.UserId = localUsername;
                td.Principal.LogonType = TaskLogonType.InteractiveToken; // No password is required
                td.Principal.RunLevel = TaskRunLevel.Highest; // Optional: Run with the highest privileges

                ts.RootFolder.RegisterTaskDefinition(@"ICam4DSetup", td);

                File.AppendAllText(@"C:\I3D_Software\Logfile.txt", "Task registered " + td.RegistrationInfo.Description);





                //// Get the current ACL for the file

                //FileSecurity fileSecurity = File.GetAccessControl(filePath);

                //// Create a new rule granting full control to the current user
                //FileSystemAccessRule accessRule = new FileSystemAccessRule(
                //    Environment.UserName,
                //    FileSystemRights.FullControl,
                //    AccessControlType.Allow);

                //// Add the access rule to the security settings
                //fileSecurity.AddAccessRule(accessRule);

                //// Apply the updated security settings to the file
                //File.SetAccessControl(filePath, fileSecurity);

            }
        }

    }
}

