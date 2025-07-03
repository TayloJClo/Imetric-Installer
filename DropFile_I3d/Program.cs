using AutoUpdaterDotNET;

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

            // Check GitHub for new releases
            AutoUpdater.GitHubUserName = "your-user";   // TODO: replace with real username
            AutoUpdater.GitHubRepoName = "your-repo";   // TODO: replace with repository name
            AutoUpdater.Start();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
