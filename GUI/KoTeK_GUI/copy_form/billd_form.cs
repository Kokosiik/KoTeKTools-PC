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

namespace KoTeK_GUI
{
    public partial class billd_form : Form
    {
        public billd_form()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += billd_form_DragEnter;
            this.DragDrop += billd_form_DragDrop;
        }

        [DllImport("CopyFile.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool KoTeK_CopyAndPack(
            string sourceFilePath,      // путь к исходному файлу (который копируем)
            string saveDirPath,         // путь к папке для сохранения
            string folderName,          // название создаваемой папки
            string[] fileNames,         // массив новых имен файлов
            int fileCount               // количество файлов
        );

        private void billd_form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void billd_form_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                string droppedFile = files[0];

                if (Path.GetExtension(droppedFile).Equals(".btx", StringComparison.OrdinalIgnoreCase))
                {
                    string root = settings_form.actual_path();

                    string[] newFileNames = {
                        "logobr12.btx",
                        "logobrgey.btx",
                        "logobrsilver.btx",
                        "logobrgold.btx"
                    };

                    string folderName = "billd";

                    bool result = KoTeK_CopyAndPack(
                        droppedFile,
                        root,
                        folderName,
                        newFileNames,
                        newFileNames.Length
                    );
                    if (result)
                    {
                        out_path.Text = "Путь: " + Path.Combine(root, folderName, folderName + ".zip");
                        Add_profile();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при копировании и упаковке файлов",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Перетащите файл с расширением .btx",
                        "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_choice_Click(object sender, EventArgs e)
        {
            string root = settings_form.actual_path();

            string selectedFilePath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "btx файлы (*.btx)|*.btx";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Выберите файл";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;

                    string[] newFileNames = new string[] {
                        "logobr12.btx",
                        "logobrgey.btx",
                        "logobrsilver.btx",
                        "logobrgold.btx"
                    };

                    string folderName = "billd";

                    bool result = KoTeK_CopyAndPack(
                        selectedFilePath,  // исходный файл
                        root,             // папка для сохранения
                        folderName,       // название папки
                        newFileNames,     // массив новых имен
                        newFileNames.Length // количество файлов
                    );

                    if (result)
                    {
                        out_path.Text = "Путь: " + Path.Combine(root, folderName, folderName + ".zip");
                        Add_profile();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при копировании и упаковке файлов",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Файл не выбран",
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void Add_profile()
        {
            string configDir = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(configDir, "config.txt");

            var lines = File.ReadAllLines(configPath).ToList();

            string keyToFind = "copy";
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
