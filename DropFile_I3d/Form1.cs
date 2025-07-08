using AutoUpdaterDotNET;
using ICam4DSetup;
using ICam4DSetup.bin;
using ImplantPositionEditor;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace DropFile_I3d
{
    public partial class Form1 : Form
    {
        private const string V = "runas";
        private string iCamSerialNo = "";
        private IniFile iniFile;


        public Form1()
        {
            InitializeComponent();
            iniFile = new IniFile(Path.Combine(Application.StartupPath, "config.ini"));
            labelVersion.Text = "V" + Assembly.GetExecutingAssembly()
                                     .GetName().Version?.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e) => Application.Exit();

        private void LoadConfigButton_Click(object sender, EventArgs e)
        {
            string iCamSerialNo = iniFile.Read("Settings", "ICamSerialNo");
        }



        static void AddLineToCsv(string filePath, string newData)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(newData);
            }
        }

        private void buttonInstallDriver_Click(object sender, EventArgs e)
        {
            installbat("C:\\I3D_Software\\Drivers\\Camera Flir\\Flir_1.23.0.27_Driver\\install.bat");
            installInf("C:\\I3D_Software\\Drivers\\Projector Imetric4D 9\\cyusb3.inf");
        }

        private void buttonIScan3d_Click(object sender, EventArgs e)
        {
            var popup = new OptionPopupForm();

            if (popup.ShowDialog() == DialogResult.OK)
            {
                string selected = popup.SelectedOption;
                string sourceCsvPath = selected switch
                {
                    "Default" => "C:\\I3D_Software\\General\\CSV's\\Default.csv",
                    "Nobel" => "C:\\I3D_Software\\General\\CSV's\\Nobel.csv",
                    "Straumann" => "C:\\I3D_Software\\General\\CSV's\\Straumann.csv",
                    _ => ""
                };

                string destinationDir = "C:\\I3D_Systems\\I221301 ICamBody Library";
                string destinationCsvPath = Path.Combine(destinationDir, "ICamBody Library.csv");

                try
                {
                    if (!File.Exists(sourceCsvPath))
                    {
                        MessageBox.Show("Source CSV file not found: " + sourceCsvPath);
                        return;
                    }

                    if (!Directory.Exists(destinationDir))
                    {
                        Directory.CreateDirectory(destinationDir);
                    }

                    File.Copy(sourceCsvPath, destinationCsvPath, overwrite: true);
                    MessageBox.Show($"Copied {selected} CSV to: {destinationCsvPath}");

                    install("C:\\I3D_Software\\Imetric4D Software\\IScan3D Dental\\IScan3D_Dental_v9.1.113_2025-04-01_64bit.msi");

                    string exePath = "C:\\Program Files (x86)\\ICamSetup\\Manuals\\CreateShortcut.exe"; // Adjust path as needed
                    if (File.Exists(exePath))
                    {
                        System.Diagnostics.Process.Start(exePath);
                    }
                    else
                    {
                        MessageBox.Show("Could not find: " + exePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error copying CSV or running install: " + ex.Message);
                }
            }
        }

        private void installMsi(string msiPath)
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
                    Verb = "runas"
                };

                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSI install failed: " + ex.Message);
            }
        }

        private void buttonInstallOffice_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("explorer.exe", "https://www.libreoffice.org/download/download-libreoffice"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void buttonInstallZip7_Click(object sender, EventArgs e)
        {
            install("C:\\I3D_Software\\General\\7zip\\7z1900-x64.exe");
        }

        private void buttonNotePadPlus_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("explorer.exe", "https://notepad-plus-plus.org/downloads/"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }





        private void buttonAddComponents_Click(object sender, EventArgs e)
        {
            var form = new CsvSelectionForm("https://raw.githubusercontent.com/TayloJClo/Imetric-Installer/refs/heads/main/ICamBody%20Library%20Master%20(test).csv");
            form.ShowDialog();
        }

        private void installbat(string batFilePath)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = batFilePath,
                    Verb = V,
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

        private void installInf(string batFilePath)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"Start-Process pnputil.exe -ArgumentList '/add-driver `{batFilePath}` /install' -Verb RunAs\"",
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

        private void install(string batFilePath)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"& '{batFilePath}'\"",
                    Verb = V,
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

        private void buttonEditor_Click(object sender, EventArgs e)
        {
            // If the popup should be shown
            if (!Properties.Settings.Default.HideImplantHowTo)
            {
                var howToForm = new ImplantHowTo();
                var result = howToForm.ShowDialog();

                // If the user clicked OK, check for "Don't show again"
                if (result == DialogResult.OK)
                {
                    if (howToForm.DontShowAgain)
                    {
                        Properties.Settings.Default.HideImplantHowTo = true;
                        Properties.Settings.Default.Save();
                    }

                    // Open the editor only if they confirmed
                    ImplantEditor editorForm = new ImplantEditor();
                    editorForm.ShowDialog();
                }
                // If they clicked Cancel or closed the popup, do nothing
            }
            else
            {
                // If "Don't show again" was previously checked, just open the editor
                ImplantEditor editorForm = new ImplantEditor();
                editorForm.ShowDialog();
            }
        }


        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var removeForm = new CsvRemoveForm();
            removeForm.ShowDialog();
        }

        private void textBoxCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelVersion_Click(object sender, EventArgs e)
        {

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://raw.githubusercontent.com/TayloJClo/Imetric-Installer/main/Version.xml");
        }

    }
}
