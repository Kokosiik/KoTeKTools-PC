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

namespace KoTeK_GUI.sliced_form
{
    public partial class map_form : Form
    {
        public map_form()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += cutmap_form_DragEnter;
        }

        string fullPath;

        [DllImport("CutMap.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool KoTeK_CutMap(
            string imagePaths,      // путь к исходному файлу(ам)
            string saveDirPath,         // путь к папке для сохранения
            string folderName,          // название создаваемой папки
            bool zip_yes_no          // запаковывать ли в zip
        );

        private void cutmap_form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void cutmap_form_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {
                    string ext = Path.GetExtension(filePath).ToLowerInvariant();

                    if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                    {
                        fullPath = filePath;

                        preview_image.Image?.Dispose();
                        preview_image.Image = Image.FromFile(fullPath);
                        preview_image.SizeMode = PictureBoxSizeMode.Zoom;

                        btn_choice_image.Visible = false;
                        btn_choice_image2.Visible = true;
                        check_zip.Visible = true;
                        preview_image.Visible = true;
                        ready_cut.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Перетащите файл с расширением .png/.jpg",
                            "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btn_choice_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Выберите файл";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fullPath = openFileDialog.FileName;
                    preview_image.Image?.Dispose();
                    preview_image.Image = Image.FromFile(fullPath);
                    preview_image.SizeMode = PictureBoxSizeMode.Zoom;

                    btn_choice_image.Visible = false;
                    btn_choice_image2.Visible = true;
                    check_zip.Visible = true;
                    preview_image.Visible = true;
                    ready_cut.Visible = true;
                }
            }
        }

        private async void ready_cut_Click(object sender, EventArgs e)
        {
            string root = settings_form.actual_path();
            string FolderName = "map";
            bool checked_zip = check_zip.Checked;

            bool result = await Task.Run(() =>
            {
                return KoTeK_CutMap(
                    fullPath,
                    root,
                    FolderName,
                    checked_zip
                );
            });
            if (result)
            {
                if (checked_zip)
                {
                    string zipPath = Path.Combine(root, FolderName, "kotek_" + FolderName + ".zip");
                    out_path.Text = "Путь: " + zipPath;
                    Add_profile();
                }
                else
                {
                    string folderPath = Path.Combine(root, FolderName);
                    out_path.Text = "Путь: " + folderPath;
                    Add_profile();
                }
            }
            else
            {
                out_path.Text = "Не удалось обработать изображения";
            }
        }

        private void Add_profile()
        {
            string configDir = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(configDir, "config.txt");

            var lines = File.ReadAllLines(configPath).ToList();

            string keyToFind = "cut";
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
