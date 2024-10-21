using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrewSX1280TestBenchApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static string GetFormattedDateTime()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public static void AppendText(TextBox textBox, string text)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action(() => AppendText(textBox, text)));
            }
            else
            {
                textBox.AppendText(text + Environment.NewLine);
                textBox.SelectionStart = textBox.Text.Length;
                textBox.ScrollToCaret();
            }
        }

        public static void Log(string txt)
        {
            AppendText(LogTextBox, "[" + Program.GetFormattedDateTime() + "]: " + txt);
        }

        public static TextBox LogTextBox
        {
            get; set;
        }

        public static void EnsureFileFromResource(string filePath, byte[] resourceContent)
        {
            if (!File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    Log($"unpacking file / 解压缩文件 \"{filePath}\"");
                    fileStream.Write(resourceContent, 0, resourceContent.Length);
                }
            }
        }
    }
}
