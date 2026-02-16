using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace KoTeK_GUI
{
    public partial class settings_form : Form
    {
        private KoTeK mainForm;

        public settings_form(KoTeK owner)
        {
            InitializeComponent();
            mainForm = owner;
            StartSettings();
        }

        string path;
        public int snow_choice = 0;

        public void StartSettings()
        {
            string configDir = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(configDir, "config.txt");

            if (!Directory.Exists(configDir))
                Directory.CreateDirectory(configDir);

            if (!File.Exists(configPath))
            {
                string defaultContent = configDir + Environment.NewLine + "snow = 0";
                File.WriteAllText(configPath, defaultContent);
                label2.Text = configDir;
                path = configDir;
                snow_no.Visible = true;
                snow_yes.Visible = false;
                return;
            }

            var lines = File.ReadAllLines(configPath).ToList();

            string firstLine = lines.Count > 0 ? lines[0].Trim() : configDir;
            if (string.IsNullOrWhiteSpace(firstLine)) firstLine = configDir;

            label2.Text = firstLine;
            path = firstLine;

            bool foundSnow = false;
            foreach (var line in lines)
            {
                if (line == "snow = 1")
                {
                    snow_no.Visible = false;
                    snow_yes.Visible = true;
                    foundSnow = true;
                    break;
                }
                else if (line == "snow = 0")
                {
                    snow_no.Visible = true;
                    snow_yes.Visible = false;
                    foundSnow = true;
                    break;
                }
            }

            if (!foundSnow)
            {
                File.AppendAllText(configPath, Environment.NewLine + "snow = 0");
                snow_no.Visible = true;
                snow_yes.Visible = false;
            }
        }

        public static string actual_path()
        {
            string configDir = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(configDir, "config.txt");

            if (!File.Exists(configPath))
                return configDir;

            string firstLine = File.ReadLines(configPath).FirstOrDefault();
            return firstLine?.Trim() ?? configDir;
        }

        private async void Folder_path_Click(object sender, EventArgs e)
        {
            string path_info = "config.txt";
            string configDir = AppDomain.CurrentDomain.BaseDirectory;
            string idinaxyu = configDir + path_info;

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Выберите папку для сохранения файлов";
                folderDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    path = folderDialog.SelectedPath;

                    label2.Text = path;

                    System.IO.File.WriteAllText(Path.Combine(configDir, path_info), path);

                    using (StreamWriter write = new StreamWriter(idinaxyu, true))
                    {
                        write.WriteLineAsync("\nsnow = 0");
                    }

                    MessageBox.Show($"Путь сохранен: {path}", "Успешно",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void choice_snow_Click(object sender, EventArgs e)
        {
            string configDir = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(configDir, "config.txt");

            if (snow_no.Visible)
            {
                snow_yes.Visible = true;
                snow_no.Visible = false;

                mainForm?.ShowSnowEffect();

                await ReplaceLineInFileAsync(configPath, "snow = 0", "snow = 1");
            }
            else if (snow_yes.Visible)
            {
                snow_no.Visible = true;
                snow_yes.Visible = false;

                mainForm?.HideSnowEffect();

                await ReplaceLineInFileAsync(configPath, "snow = 1", "snow = 0");
            }
        }

        private async Task ReplaceLineInFileAsync(string filePath, string oldLine, string newLine)
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (line == oldLine)
                    {
                        lines.Add(newLine);
                    }
                    else
                    {
                        lines.Add(line);
                    }
                }
            }

            using (var writer = new StreamWriter(filePath, append: false))
            {
                foreach (var line in lines)
                {
                    await writer.WriteLineAsync(line);
                }
            }
        }

        public string snow_check()
        {
            string configDir = AppDomain.CurrentDomain.BaseDirectory; ;
            string configPath = Path.Combine(configDir, "config.txt");

            string result = "error";

            using (var reader = new StreamReader(configPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "snow = 1")
                    {
                        snow_no.Visible = false;
                        snow_yes.Visible = true;
                        result = "1";
                        break;
                    }
                    else if (line == "snow = 0")
                    {
                        snow_no.Visible = true;
                        snow_yes.Visible = false;
                        result = "0";
                        break;
                    }
                }
            }

            return result;
        }
        public static string GetSnowSetting()
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "config.txt";
            if (!File.Exists(configPath)) return "0";

            foreach (var line in File.ReadLines(configPath))
            {
                if (line == "snow = 1") return "1";
                if (line == "snow = 0") return "0";
            }
            return "0";
        }
    }
}