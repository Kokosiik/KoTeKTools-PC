using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoTeK_GUI.atmosphere_form
{
    public partial class colorcycle_form : Form
    {
        public colorcycle_form()
        {
            InitializeComponent();
        }

        [DllImport("Ccyc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool KoTeK_Colorcycle(
            string saveDirPath,         // путь к папке для сохранения
            string folderName,          // название создаваемой папки
            string hex_up                 // hex
        );

        private const string hex_text = "Введите #hex";

        private void inp_hex_Click(object sender, EventArgs e)
        {
            if(inp_hex.Text == hex_text)
            {
                inp_hex.Text = "";
            }
        }

        private void inp_hex_picker_Click(object sender, EventArgs e)
        {
            var popup = new ColorPickerPopup();
            popup.ColorSelected += (color) =>
            {
                inp_hex.Text = ColorTranslator.ToHtml(color);
            };
            popup.ShowAt(inp_hex_picker);
        }

        private async void inp_ready_Click(object sender, EventArgs e)
        {
            string hex = inp_hex.Text;

            string root = settings_form.actual_path();
            string FolderName = "Colorcycle";

            bool result = await Task.Run(() =>
            {
                return KoTeK_Colorcycle(
                    root,
                    FolderName,
                    hex
                );
            });
            if (result)
            {
                string folderPath = Path.Combine(root, FolderName);
                out_path.Text = "Путь: " + folderPath;
                Add_profile();
            }
            else
            {
                out_path.Text = "Не удалось создать colorcycle";
            }
        }

        private void Add_profile()
        {
            string configDir = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(configDir, "config.txt");

            var lines = File.ReadAllLines(configPath).ToList();

            string keyToFind = "atmos";
            bool found = false;

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i].Trim();
                if (line.StartsWith(keyToFind + " = ", StringComparison.Ordinal))
                {
                    string[] parts = line.Split(new[] { " = " }, StringSplitOptions.None);
                    if (parts.Length == 2 && int.TryParse(parts[1], out int currentValue))
                    {
                        lines[i] = $"{keyToFind} = {currentValue + 1}";
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                lines.Add($"{keyToFind} = 1");
            }

            File.WriteAllLines(configPath, lines);
        }
    }
}
