using AutoUpdaterDotNET;
using System.Diagnostics;

namespace DropFile_I3d
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Ensure secure HTTPS connections (required by GitHub/Dropbox)
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            // Configure AutoUpdater to check updates from a specific XML file
            AutoUpdater.ApplicationExitEvent += RestartAfterUpdate;
            AutoUpdater.DownloadPath = Application.StartupPath;
            AutoUpdater.Start("https://raw.githubusercontent.com/TayloJClo/Imetric-Installer/main/Version.xml");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static void RestartAfterUpdate()
        {
            Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        }
    }
}

