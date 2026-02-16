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

namespace KoTeK_GUI.convert_form
{
    public partial class btxpng_form : Form
    {
        public btxpng_form()
        {
            InitializeComponent();

            this.AllowDrop = true;

            this.DragEnter += btxpng_form_DragEnter;
            this.DragDrop += btxpng_form_DragDrop;

            foreach (Control control in this.Controls)
            {
                if (control.AllowDrop)
                    control.AllowDrop = false;
            }
        }

        private string _selectedCompression = "Среднее";
        private string _selectedQuality = "Максимальное";
        private string[] imagePaths = new string[0];

        string parser_compress(string compress)
        {
            if (compress == "Сильное") return "8x8";
            if (compress == "Среднее") return "6x6";
            if (compress == "Плохое") return "4x4";
            return "6x6";
        }

        string parser_quality(string quality)
        {
            if (quality == "Максимальное") return "exhaustive";
            if (quality == "Хорошее") return "thorough";
            if (quality == "Среднее") return "medium";
            if (quality == "Плохое") return "fast";
            return "medium";
        }

        [DllImport("ConvertBtxPng.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool KoTeK_ConvertBtxAndPack(
            string[] imagePaths,      // путь к исходному файлу(ам)
            string saveDirPath,         // путь к папке для сохранения
            string folderName,          // название создаваемой папки
            string compressing,        // сжатие png to btx
            string qualitysing,        // качество (кол-во поиска наилучшей формулы)
            int fileCount,               // количество файлов
            bool zip_yes_no
        );

        [DllImport("UnPackZip.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr KoTeK_UnPackZip(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] zipFilePaths,
            int fileCount,
            string extractPath,
            [MarshalAs(UnmanagedType.Bool)] bool createSubfolders
        );

        [DllImport("UnPackZip.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void KoTeK_FreeMemory(IntPtr array);

        private string[] GetUnpackedFilesFromDLL(IntPtr nativeResult)
        {
            if (nativeResult == IntPtr.Zero)
                return Array.Empty<string>();

            List<string> fileList = new List<string>();
            IntPtr current = nativeResult;

            try
            {
                IntPtr stringPtr = Marshal.ReadIntPtr(current);
                while (stringPtr != IntPtr.Zero)
                {
                    string filePath = Marshal.PtrToStringAnsi(stringPtr);
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        fileList.Add(filePath);
                    }

                    current += IntPtr.Size;
                    stringPtr = Marshal.ReadIntPtr(current);
                }

                return fileList.ToArray();
            }
            finally
            {
                if (nativeResult != IntPtr.Zero)
                    KoTeK_FreeMemory(nativeResult);
            }
        }

        private void listImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listImage.SelectedIndex;
            if (index < 0 || index >= imagePaths.Length) return;

            string fullPath = imagePaths[index];

            preview_image.Image?.Dispose();

            try
            {
                preview_image.Image = Image.FromFile(fullPath);
                preview_image.SizeMode = PictureBoxSizeMode.Zoom;
                preview_image.Visible = true;
            }
            catch
            {
                preview_image.Visible = false;
            }
        }

        private void btn_choice_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.btx)|*.png;*.jpg;*.jpeg;*.btx|ZIP Archives (*.zip)|*.zip";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Выберите файл";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ProcessSelectedFiles(openFileDialog.FileNames);
                }
            }
        }

        private void ProcessSelectedFiles(string[] files)
        {
            List<string> zipFiles = new List<string>();
            List<string> imageFiles = new List<string>();

            foreach (string filePath in files)
            {
                string ext = Path.GetExtension(filePath).ToLowerInvariant();

                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".btx")
                {
                    imageFiles.Add(filePath);
                }
                else if (ext == ".zip")
                {
                    zipFiles.Add(filePath);
                }
                else
                {
                    MessageBox.Show($"Файл '{Path.GetFileName(filePath)}' имеет неверный формат.\nРазрешены: .png, .jpg, .jpeg, .btx, .zip",
                        "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (zipFiles.Count > 0)
            {
                UnpackAndAddImagesFromZip(zipFiles.ToArray());
            }

            foreach (string filePath in imageFiles)
            {
                AddImageToGrid(filePath);
            }
        }

        private void AddImageToGrid(string filePath)
        {
            if (imagePaths.Contains(filePath))
            {
                return;
            }

            Array.Resize(ref imagePaths, imagePaths.Length + 1);
            imagePaths[imagePaths.Length - 1] = filePath;
            listImage.Items.Add(Path.GetFileName(filePath));
        }

        private void UnpackAndAddImagesFromZip(string[] zipFiles)
        {
            if (zipFiles == null || zipFiles.Length == 0)
                return;

            string root = AppDomain.CurrentDomain.BaseDirectory;
            string folderName = "unpackzip";
            string extractPath = Path.Combine(root, folderName);

            if (Directory.Exists(extractPath))
            {
                Directory.Delete(extractPath, true);
            }
            Directory.CreateDirectory(extractPath);

            bool createSubfolders = (zipFiles.Length > 1);

            IntPtr nativeResult = KoTeK_UnPackZip(zipFiles, zipFiles.Length, extractPath, createSubfolders);

            string[] unpackedFiles = GetUnpackedFilesFromDLL(nativeResult);

            int addedCount = 0;

            foreach (string filePath in unpackedFiles)
            {
                string ext = Path.GetExtension(filePath).ToLowerInvariant();
                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".btx")
                {
                    if (!imagePaths.Contains(filePath))
                    {
                        AddImageToGrid(filePath);
                        addedCount++;
                    }
                }
            }
        }

        private void btxpng_form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private bool _isProcessingDragDrop = false;

        private void btxpng_form_DragDrop(object sender, DragEventArgs e)
        {
            if (_isProcessingDragDrop) return;

            try
            {
                _isProcessingDragDrop = true;

                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    files = files.Distinct().ToArray();

                    ProcessSelectedFiles(files);
                }
            }
            finally
            {
                _isProcessingDragDrop = false;
            }
        }

        private async void convert_btn_ready()
        {
            if (imagePaths.Length == 0)
            {
                MessageBox.Show("Добавьте хотя бы одно изображение для конвертации",
                    "Нет изображений", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string root = settings_form.actual_path();
            string FolderName = "convert";
            bool checked_zip = check_zip.Checked;
            out_path.Text = "Подождите...";

            string compress = parser_compress(_selectedCompression);
            string quality = parser_quality(_selectedQuality);

            bool result = await Task.Run(() =>
            {
                return KoTeK_ConvertBtxAndPack(
                    imagePaths,
                    root,
                    FolderName,
                    compress,
                    quality,
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
                    Add_profile();
                }
                else
                {
                    string folderPath = Path.Combine(root, FolderName);
                    out_path.Text = "Путь: " + folderPath;
                    Add_profile();
                }

                MessageBox.Show("Конвертация завершена успешно!",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                out_path.Text = "Не удалось обработать изображения";
                MessageBox.Show("Произошла ошибка при конвертации изображений",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_profile()
        {
            string configDir = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(configDir, "config.txt");

            List<string> lines = File.Exists(configPath)
                ? File.ReadAllLines(configPath).ToList()
                : new List<string>();

            string keyToFind = "convert";
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

        private void CQ_Click(object sender, EventArgs e)
        {
            var popup = new CompressionQualityPopup();
            popup.ChoiceConfirmed += (compression, quality) =>
            {
                _selectedCompression = compression;
                _selectedQuality = quality;
                convert_btn_ready();
            };
            popup.ShowAt(convert_btn);
        }
    }
}