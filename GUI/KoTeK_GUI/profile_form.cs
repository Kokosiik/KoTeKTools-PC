using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoTeK_GUI
{
    public partial class profile_form : Form
    {
        public profile_form()
        {
            InitializeComponent();
            ViewStats();
        }

        private void ViewStats()
        {
            string configDir = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(configDir, "config.txt");

            var lines = File.ReadAllLines(configPath);
            var config = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in lines)
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("#"))
                    continue;

                var parts = trimmed.Split(new[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    config[key] = value;
                }
            }

            string GetConfigValue(string key, string defaultValue = "0")
            {
                return config.TryGetValue(key, out string value) ? value : defaultValue;
            }

            convert.Text = GetConfigValue("convert");
            copy.Text = GetConfigValue("copy");
            cut.Text = GetConfigValue("cut");
            color.Text = GetConfigValue("color");
            atmos.Text = GetConfigValue("atmos");
        }
    }
}
