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

namespace KoTeK_GUI
{
    public partial class colorImage_form : Form
    {
        public colorImage_form()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += colorimage_form_DragEnter;
        }

        private int convertMode = 0;
        private string[] imagePaths = new string[0];
        private const string PlaceholderText = "Введите #hex";

        [DllImport("ColorImage.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool KoTeK_ColorAndPack(
            string[] imagePaths,      // путь к исходному файлу(ам)
            string saveDirPath,         // путь к папке для сохранения
            string folderName,          // название создаваемой папки
            string hex,                 // hex пользователя
            int fileCount,               // количество файлов
            bool zip_yes_no
        );

        private Image LoadImageFromDisk(string path)
        {
            if (!File.Exists(path)) return null;

            try
            {
                byte[] bytes = File.ReadAllBytes(path);
                using (var ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить изображение:\n{ex.Message}");
                return null;
            }
        }

        private void listImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listImage.SelectedIndex;
            if (index < 0 || index >= imagePaths.Length) return;

            string fullPath = imagePaths[index];

            if (convertMode == 0)
            {
                preview_image.Image?.Dispose();
                preview_image.Image = Image.FromFile(fullPath);
                preview_image.SizeMode = PictureBoxSizeMode.Zoom;
                preview_image.Visible = true;
                beforeAfterViewer.Visible = false;
                label4.Visible = false;
            }
            else if (convertMode == 1)
            {
                string fileName = Path.GetFileName(fullPath);
                string root = settings_form.actual_path();
                string processedPath = Path.Combine(root, "Image", fileName);

                if (!File.Exists(processedPath))
                {
                    MessageBox.Show($"Обработанное изображение не найдено:\n{processedPath}");
                    return;
                }

                Image original = Image.FromFile(fullPath);
                Image processed = Image.FromFile(processedPath);
                beforeAfterViewer.BackColor = ColorTranslator.FromHtml("#0c2129");
                beforeAfterViewer.BeforeImage?.Dispose();
                beforeAfterViewer.AfterImage?.Dispose();
                beforeAfterViewer.BeforeImage = LoadImageFromDisk(fullPath);
                beforeAfterViewer.AfterImage = LoadImageFromDisk(processedPath);
                beforeAfterViewer.Visible = true;
                preview_image.Visible = false;
                label4.Visible = false;
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
                    string fullPath = openFileDialog.FileName;
                    Array.Resize(ref imagePaths, imagePaths.Length + 1);
                    imagePaths[imagePaths.Length - 1] = fullPath;
                    listImage.Items.Add(Path.GetFileName(fullPath));
                }
            }
        }

        private void colorimage_form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void colorimage_form_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {
                    string ext = Path.GetExtension(filePath).ToLowerInvariant();

                    if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                    {
                        Array.Resize(ref imagePaths, imagePaths.Length + 1);
                        imagePaths[imagePaths.Length - 1] = filePath;
                        listImage.Items.Add(Path.GetFileName(filePath));
                    }
                    else
                    {
                        MessageBox.Show("Перетащите файл с расширением .png/.jpg",
                            "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void choice_hex_btn_Click(object sender, EventArgs e)
        {
            var popup = new ColorPickerPopup();
            popup.ColorSelected += (color) =>
            {
                inp_hex.Text = ColorTranslator.ToHtml(color);
            };
            popup.ShowAt(choice_hex_btn);
        }

        private async void color_image_Click(object sender, EventArgs e)
        {
            string root = settings_form.actual_path();
            string FolderName = "Image";
            bool checked_zip = check_zip.Checked;
            string hex = inp_hex.Text;
            out_path.Text = "";

            bool result = await Task.Run(() =>
            {
                return KoTeK_ColorAndPack(
                    imagePaths,
                    root,
                    FolderName,
                    hex,
                    imagePaths.Length,
                    checked_zip
                );
            });
            if (result)
            {
                if (checked_zip)
                {
                    string zipPath = Path.Combine(root, FolderName, FolderName + ".zip");
                    out_path.Text = "Путь: " + zipPath;
                    convertMode = 1;
                    Add_profile();
                }
                else
                {
                    string folderPath = Path.Combine(root, FolderName);
                    out_path.Text = "Путь: " + folderPath;
                    convertMode = 1;
                    Add_profile();
                }
            }
            else
            {
                out_path.Text = "Не удалось обработать изображения";
            }
        }

        private void inp_hex_Click(object sender, EventArgs e)
        {
            if(inp_hex.Text == PlaceholderText)
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