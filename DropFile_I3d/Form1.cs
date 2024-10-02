
using System.Diagnostics;
using System.Text;

namespace DropFile_I3d
{
    public partial class Form1 : Form
    {
        //private string dropboxAccessToken = "YOUR_DROPBOX_ACCESS_TOKEN";
        //private string filePathInDropbox = "/path/to/your/file.txt";
        private string iCamSerialNo = "";
        private IniFile iniFile;

        public Form1()
        {
            InitializeComponent();
            // Specify the path to your INI file
            iniFile = new IniFile(string.Format("{0}\\config.ini", Application.StartupPath));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LoadConfigButton_Click(object sender, EventArgs e)
        {
            // Example: Load configuration values from the INI file
            //string filePathInDropbox = iniFile.Read("Settings", "FilePathInDropbox");
            string iCamSerialNo = iniFile.Read("Settings", "ICamSerialNo");
            //string dropboxAccessToken = iniFile.Read("Settings", "DropboxAccessToken");

        }
        private void buttonGetFile_Click(object sender, EventArgs e)
        {

            try
            {

                string copytofolder = string.Format("C:\\I3D_Systems\\{0} ICamBody Library\\ICamRef\\{1}", textBoxCustomerID.Text, textBoxName.Text.Trim());

                if (string.IsNullOrEmpty(textBoxCustomerID.Text))
                {
                    labelMessage.Text = copytofolder;
                    MessageBox.Show($"No ICam Serial : {textBoxCustomerID.Text}");
                    return;
                }
                iniFile.Write("Settings", "ICamSerialNo", textBoxCustomerID.Text);

                if (string.IsNullOrEmpty(textBoxName.Text))
                {
                    labelMessage.Text = copytofolder;
                    MessageBox.Show($"No File Name : {textBoxName.Text}");
                    return;
                }

                //if (string.IsNullOrEmpty(textBoxPasteFile.Text))
                //{
                //    MessageBox.Show($"No Paste Line Data : {textBoxPasteFile.Text}");
                //    return;
                //}

                //await DownloadFileFromDropbox();
                //labelProgress.Text = "File downloaded successfully.";
                //string destinationFilePath = Path.Combine(localFilePath, filePathInDropbox);
                string filetoCopy = string.Format("{0}\\{1}", Application.StartupPath, textBoxName.Text);
                if (!File.Exists(filetoCopy))
                {
                    labelMessage.Text = filetoCopy;
                    MessageBox.Show($"No file: {textBoxName.Text}");
                    return;
                }

                File.Copy(filetoCopy, copytofolder, true);
                string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                // Specify the path to your CSV file
                string cvsFile = string.Format("C:\\I3D_Systems\\{0} ICamBody Library\\ICamRef\\{1}", textBoxCustomerID, "ICamBody Library.csv");

                if (!File.Exists(cvsFile))
                {
                    labelMessage.Text = cvsFile;
                    MessageBox.Show($"No CVS file: {"ICamBody Library.csv"}");
                    return;
                }

                //// Append the new line to the CSV file
                //AddLineToCsv(cvsFile, textBoxPasteFile.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        static void AddLineToCsv(string filePath, string newData)
        {
            // Use StreamWriter to append the new line to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // Write the new line to the CSV file
                writer.WriteLine(newData);
            }
        }

        private void buttonInstallDriver_Click(object sender, EventArgs e)
        {
            string batFilePath = @"C:\I3D_Software\Drivers\Camera Flir\Flir_1.23.0.27_Driver\Install.bat";
            installbat(batFilePath);

            string batFilePath1 = @"C:\I3D_Software\Drivers\Projector Imetric4D 9\cyusb3.inf";
            installInf(batFilePath1);
        }

        private void buttonIScan3d_Click(object sender, EventArgs e)
        {
            string batFilePath = @"C:\I3D_Software\Imetric4D Software\IScan3D Dental\IScan3D_Dental_v9.1.112_2024-03-07_64bit.msi";
            install(batFilePath);
        }

        private void buttonInstallZip7_Click(object sender, EventArgs e)
        {
            string batFilePath = @"C:\I3D_Software\General\7zip\7z1900-x64.exe";
            install(batFilePath);

        }
        private void buttonCyUsb_Click(object sender, EventArgs e)
        {

        }
        private void installInf(string batFilePath)
        {

            try
            {
                // Run PowerShell to install the INF file using pnputil.exe
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"Start-Process pnputil.exe -ArgumentList '/add-driver `\"{batFilePath}`\" /install' -Verb RunAs\"",

                    // Ensure that the process is running as an Administrator
                    UseShellExecute = false,
                    CreateNoWindow = true,  // Do not show the PowerShell window
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (Process process = Process.Start(processInfo))
                {
                    // Capture and read the output from PowerShell
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    // Display output or error messages
                    if (!string.IsNullOrEmpty(output))
                    {
                        MessageBox.Show($"Output: {output}");
                    }

                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show($"Error: {error}");
                    }

                    MessageBox.Show("Driver installation complete.");
                }
            }
            catch (Exception ex)
            {
                // Handle any errors during the process
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void installbat(string batFilePath)
        {
            // Create a new process to run the batch file
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = batFilePath,
                Verb = "runas",  // Run the process as an Administrator
                UseShellExecute = true,
                CreateNoWindow = true
            };

            try
            {
                using (Process process = Process.Start(processInfo))
                {
                    process.WaitForExit();
                    MessageBox.Show("Installation complete.");
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the execution
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void install(string batFilePath)
        {
            // Create a new process to run PowerShell
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"& '{batFilePath}'\"",


                // Force the process to run as Administrator
                Verb = "runas",


                // Prevents the PowerShell window from appearing
                CreateNoWindow = true,
                UseShellExecute = false,

                // Redirect output if you need to capture the output
                RedirectStandardOutput = true,
                RedirectStandardError = true

            };

            try
            {
                using (Process process = Process.Start(processInfo))
                {
                    // Optionally capture output and errors from the PowerShell process
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    // Show output or error in message box or log it
                    if (!string.IsNullOrWhiteSpace(output))
                    {
                        MessageBox.Show("Output: " + output);
                    }

                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the execution
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
//private async Task DownloadFileFromDropbox()
//{
//    using (var dbx = new DropboxClient(dropboxAccessToken))
//    {
//        var response = await dbx.Files.DownloadAsync(filePathInDropbox);
//        var content = await response.GetContentAsStreamAsync();

//        using (var fileStream = File.Create(localFilePath))
//        {
//            content.CopyTo(fileStream);
//            fileStream.Close();
//        }
//    }
//}
