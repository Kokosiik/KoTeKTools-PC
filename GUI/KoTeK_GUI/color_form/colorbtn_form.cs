using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoTeK_GUI.color_form
{
    public partial class colorbtn_form : Form
    {
        public colorbtn_form()
        {
            InitializeComponent();
        }

        private const string PlaceholderText = "Введите #hex";
        private static readonly string[] imageNames =
            {
                "hud_arrow_left.png",
                "hud_arrow_right.png",
                "hud_boat.png",
                "hud_car.png",
                "hud_circle.png",
                "hud_daily_case_active.png",
                "hud_lockon.png",
                "hud_monstertruck.png",
                "leftshoot.png",
                "accelerate.png",
                "brake.png",
                "Brown.png",
                "cam-toggle.png",
                "crane_top.png",
                "handbrake.png",
                "horn.png",
                "hud_bike.png",
                "hud_chopper.png",
                "hud_daily_case.png",
                "hud_dildo2.png",
                "hud_nitro.png",
                "hud_swim.png",
                "punch.png",
                "radio_widget.png",
                "shoot.png",
                "crane_down.png",
                "sprint.png",
                "WidgetGetIn.png"
            };

        [DllImport("ColorButton.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool KoTeK_ColorBTNAndPack(
            string saveDirPath,         // путь к папке для сохранения
            string folderName,          // название создаваемой папки
            string hex,                 // hex пользователя
            bool zip_yes_no            // название говрит само за себя
        );

        private void choice_hex_btn_Click(object sender, EventArgs e)
        {
            var popup = new ColorPickerPopup();
            popup.ColorSelected += (color) =>
            {
                inp_hex.Text = ColorTranslator.ToHtml(color);
            };
            popup.ShowAt(choice_hex_btn);
        }

        private void listImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listImage.SelectedIndex;
            if (index < 0 || index >= imageNames.Length)
                return;

            string buttonFolder = settings_form.actual_path() + "\\button";
            string fileName = imageNames[index];
            string fullPath = Path.Combine(buttonFolder, fileName);

            preview_image.Image?.Dispose();
            preview_image.Image = null;

            if (File.Exists(fullPath))
            {
                using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                {
                    preview_image.Image = Image.FromStream(fs);
                }
                preview_image.SizeMode = PictureBoxSizeMode.Zoom;
                preview_image.Visible = true;
            }
            else
            {
                preview_image.Visible = false;
                MessageBox.Show($"Изображение не найдено:\n{fullPath}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void color_button_Click(object sender, EventArgs e)
        {
            string root = settings_form.actual_path();
            string FolderName = "button";
            bool checked_zip = check_zip.Checked;
            string hex = inp_hex.Text;

            bool result = await Task.Run(() =>
            {
                return KoTeK_ColorBTNAndPack(
                    root,
                    FolderName,
                    hex,
                    checked_zip
                );
            });

            if (result)
            {
                if (checked_zip)
                {
                    string zipPath = Path.Combine(root, FolderName, FolderName + ".zip");
                    out_path.Text = "Путь: " + zipPath;
                }
                else
                {
                    listImage.Items.Clear();
                    foreach (var name in imageNames)
                    {
                        listImage.Items.Add(Path.GetFileName(name));
                    }
                    if (listImage.Items.Count > 0)
                    {
                        listImage.SelectedIndex = 0;
                    }

                    string folderPath = Path.Combine(root, FolderName);
                    out_path.Text = "Путь: " + folderPath;
                }

                Add_profile();
            }
        }

        private void inp_hex_Click(object sender, EventArgs e)
        {
            if (inp_hex.Text == PlaceholderText)
            {
                inp_hex.Text = "";
            }
        }

        private void Add_profile()
        {
            string configDir = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(configDir, "config.txt");

            var lines = File.ReadAllLines(configPath).ToList();

            string keyToFind = "color";
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
