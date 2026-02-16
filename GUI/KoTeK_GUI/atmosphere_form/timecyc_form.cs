using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoTeK_GUI.atmosphere_form
{
    public partial class timecyc_form : Form
    {
        public timecyc_form()
        {
            InitializeComponent();
        }

        [DllImport("Tcyc.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool KoTeK_Timecyc(
            string saveDirPath,         // путь к папке для сохранения
            string folderName,          // название создаваемой папки
            string hex_up,                 // hex верх неба
            string hex_down,                 // hex низ неба
            string hex_cloud,                 // hex облаков
            string hex_sun                 // hex солнца
        );

        private const string hex_text = "Введите #hex";


        private void inp_hex_up_Click(object sender, EventArgs e)
        {
            if (inp_hex_up.Text == hex_text)
            {
                inp_hex_up.Text = "";
            }
        }
        private void inp_hex_down_Click(object sender, EventArgs e)
        {
            if (inp_hex_down.Text == hex_text)
            {
                inp_hex_down.Text = "";
            }
        }
        private void inp_hex_cloud_Click(object sender, EventArgs e)
        {
            if (inp_hex_cloud.Text == hex_text)
            {
                inp_hex_cloud.Text = "";
            }
        }
        private void inp_hex_sun_Click(object sender, EventArgs e)
        {
            if (inp_hex_sun.Text == hex_text)
            {
                inp_hex_sun.Text = "";
            }
        }

        private void inp_hex_picker_up_Click(object sender, EventArgs e)
        {
            var popup = new ColorPickerPopup();
            popup.ColorSelected += (color) =>
            {
                inp_hex_up.Text = ColorTranslator.ToHtml(color);
            };
            popup.ShowAt(inp_hex_picker_up);
        }

        private void inp_hex_picker_down_Click(object sender, EventArgs e)
        {
            var popup = new ColorPickerPopup();
            popup.ColorSelected += (color) =>
            {
                inp_hex_down.Text = ColorTranslator.ToHtml(color);
            };
            popup.ShowAt(inp_hex_picker_down);
        }

        private void inp_hex_picker_cloud_Click(object sender, EventArgs e)
        {
            var popup = new ColorPickerPopup();
            popup.ColorSelected += (color) =>
            {
                inp_hex_cloud.Text = ColorTranslator.ToHtml(color);
            };
            popup.ShowAt(inp_hex_picker_cloud);
        }

        private void inp_hex_picker_sun_Click(object sender, EventArgs e)
        {
            var popup = new ColorPickerPopup();
            popup.ColorSelected += (color) =>
            {
                inp_hex_sun.Text = ColorTranslator.ToHtml(color);
            };
            popup.ShowAt(inp_hex_picker_sun);
        }

        private async void btn_ready_Click(object sender, EventArgs e)
        {
            string hex_up = inp_hex_up.Text;
            string hex_down = inp_hex_down.Text;
            string hex_cloud = inp_hex_cloud.Text;
            string hex_sun = inp_hex_sun.Text;

            string root = settings_form.actual_path();
            string FolderName = "Timecyc";

            bool result = await Task.Run(() =>
            {
                return KoTeK_Timecyc(
                    root,
                    FolderName,
                    hex_up,
                    hex_down,
                    hex_cloud,
                    hex_sun
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
                out_path.Text = "Не удалось создать timecyc";
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
