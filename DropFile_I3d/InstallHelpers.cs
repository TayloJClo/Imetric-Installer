using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DropFile_I3d
{
    internal static class InstallHelpers
    {
        private const string VerbRunAs = "runas";

        public static void InstallBat(string batFilePath)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = batFilePath,
                    Verb = VerbRunAs,
                    UseShellExecute = true,
                    CreateNoWindow = true
                };

                using var process = Process.Start(processInfo);
                process.WaitForExit();
                MessageBox.Show("Installation complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public static void InstallInf(string infPath)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"Start-Process pnputil.exe -ArgumentList '/add-driver `{infPath}` /install' -Verb RunAs\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using var process = Process.Start(processInfo);
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrEmpty(output)) MessageBox.Show("Output: " + output);
                if (!string.IsNullOrEmpty(error)) MessageBox.Show("Error: " + error);

                MessageBox.Show("Driver installation complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Driver installation failed: " + ex.Message);
            }
        }

        public static void Install(string scriptPath)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"& '{scriptPath}'\"",
                    Verb = VerbRunAs,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using var process = Process.Start(processInfo);
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(output)) MessageBox.Show("Output: " + output);
                if (!string.IsNullOrWhiteSpace(error)) MessageBox.Show("Error: " + error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public static void InstallMsi(string msiPath)
        {
            try
            {
                if (!File.Exists(msiPath))
                {
                    MessageBox.Show("MSI file not found: " + msiPath);
                    return;
                }

                var processInfo = new ProcessStartInfo
                {
                    FileName = "msiexec.exe",
                    Arguments = $"/i \"{msiPath}\" /passive",
                    UseShellExecute = true,
                    Verb = VerbRunAs
                };

                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSI install failed: " + ex.Message);
            }
        }
    }
}
