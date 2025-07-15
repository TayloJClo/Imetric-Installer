using AutoUpdaterDotNET;
using System.Diagnostics;
using System.IO;
using System;

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
            AutoUpdater.ApplicationExitEvent += CloseApplication;
            AutoUpdater.RunUpdateAsAdmin = true;

            // Download updates to a writable temporary folder
            string updatePath = Path.Combine(Path.GetTempPath(), "ImetricUpdater");
            Directory.CreateDirectory(updatePath);
            AutoUpdater.DownloadPath = updatePath;

            if (!UpdateHelper.IsAutoUpdateDisabled())
            {
                AutoUpdater.Start("https://raw.githubusercontent.com/TayloJClo/Imetric-Installer/master/Version.xml");
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static void CloseApplication()
        {
            // Exit so the updater can apply the downloaded files. The updater
            // will relaunch the application when extraction is complete.
            Environment.Exit(0);
        }

    }
}

