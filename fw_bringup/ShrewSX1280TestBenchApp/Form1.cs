using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Management;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Threading;
using System.Collections.Concurrent;

namespace ShrewSX1280TestBenchApp
{
    public partial class Form1 : Form
    {
        private string lastSelectedPort = null;
        public Form1()
        {
            InitializeComponent();

            groupBox1.Text += "/串口";
            groupBox2.Text += "/笔记";
            tabPage1.Text += "/固件";
            tabPage2.Text += "/测试";
            btnLoadTestFirmware.Text += "\n写闪存实验固件";
            btnLoadProdFirmware.Text += "\n写闪存产品固件";
            btnToneStart.Text += "\n开始";
            btnToneStop.Text += "\n停止";
            lblFrequency.Text += "\n射频:";
            lblPower.Text += "\n力量:";
            lblMode.Text += "\n模式:";
            lblPacketRate.Text += "\n数据包率:";
            lblPacketsPerSecond.Text += "\r\n数据包每秒";

            dropTestMode.Items.Add("Continuous Wave/连续波");
            dropTestMode.Items.Add("Random Hop/随机频道跳");
            dropTestMode.Items.Add("Sequencial Hop/顺序频道跳");
            dropTestMode.Items.Add("Spacing Hop (2 channels)/两个频道跳");
            dropTestMode.SelectedIndex = 0;

            Program.LogTextBox = txtLog;
            this.Text = Application.ProductName;
            PopulateSerialPorts();
            Program.Log("program launched/软件开始");

            Program.EnsureFileFromResource("esptool.exe", Resource1.esptool);
            Program.EnsureFileFromResource("shrew_firmware_test.bin", Resource1.shrew_firmware_test);
            Program.EnsureFileFromResource("shrew_firmware_product.bin", Resource1.shrew_firmware_product);
            Program.EnsureFileFromResource("boot_app0.bin", Resource1.boot_app0);
            Program.EnsureFileFromResource("bootloader.bin", Resource1.bootloader);
            Program.EnsureFileFromResource("partitions.bin", Resource1.partitions);
        }

        private void PopulateSerialPorts()
        {
            if (dropSerialPorts.Items.Count > 0)
            {
                string oldItem = (string)dropSerialPorts.SelectedItem;
                if (string.IsNullOrWhiteSpace(oldItem) == false)
                {
                    lastSelectedPort = oldItem;
                }
            }
            dropSerialPorts.Items.Clear();

            foreach (string port in SerialPort.GetPortNames())
            {
                string portInfo = GetPortInformation(port);
                dropSerialPorts.Items.Add(portInfo);
            }
            if (string.IsNullOrWhiteSpace(lastSelectedPort) == false)
            {
                if (lastSelectedPort.Length > 0)
                {
                    SelectClosestMatch(dropSerialPorts, lastSelectedPort);
                }
            }
            else if (dropSerialPorts.Items.Count > 0)
            {
                dropSerialPorts.SelectedIndex = 0;
            }
        }

        private void SelectClosestMatch(ComboBox comboBox, string searchText)
        {
            // Initialize variables to store the closest match and minimum distance
            string closestMatch = null;
            int minDistance = int.MaxValue;

            // Iterate through the ComboBox items
            foreach (string item in comboBox.Items)
            {
                // Calculate the Levenshtein distance
                int distance = LevenshteinDistance(item, searchText);

                // Update the closest match if a closer one is found
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestMatch = item;
                }
            }

            // Select the closest match in the ComboBox
            if (closestMatch != null)
            {
                comboBox.SelectedItem = closestMatch;
            }

        }
        private string GetPortInformation(string portName)
        {
            string info = portName;
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%({portName}%'"))
                {
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        string t = $" - {queryObj["Caption"]} ({queryObj["Description"]})";
                        string pattern = $@"{Regex.Escape(portName)}([^a-zA-Z0-9]*|$)";
                        if (Regex.IsMatch(t, pattern))
                        {
                            info += t;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                info += " - info not available";
            }

            return info;
        }


        private void dropSerialPorts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PopulateSerialPorts();
        }

        private int LevenshteinDistance(string s1, string s2)
        {
            int[,] d = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
                d[i, 0] = i;

            for (int j = 0; j <= s2.Length; j++)
                d[0, j] = j;

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    int cost = (s2[j - 1] == s1[i - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            return d[s1.Length, s2.Length];
        }

        private string GetCurrentSerialPort()
        {
            if (dropSerialPorts.SelectedIndex < 0)
            {
                return null;
            }
            string s = (string)dropSerialPorts.SelectedItem;
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            if (s.Contains('-'))
            {
                string[] parts = s.Split('-');
                s = parts[0];
            }
            s = s.Trim();
            if (s.Length <= 0)
            {
                return null;
            }
            return s;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dropSerialPorts.Items.Count == 0)
            {
                PopulateSerialPorts();
            }
        }

        private void btnToneStart_Click(object sender, EventArgs e)
        {
            string port = GetCurrentSerialPort();
            if (string.IsNullOrWhiteSpace(port))
            {
                Program.Log("ERROR/错误: no serial port selected / 没有串口");
                return;
            }
            int testMode = dropTestMode.SelectedIndex;
            if (testMode < 0)
            {
                Program.Log("ERROR/错误: no mode selected / 没有选择模式");
                return;
            }
            Program.Log("starting test / 开始");
            int freq = Convert.ToInt32(numFrequency.Value * 10);
            int pwr = Convert.ToInt32(numRfPower.Value);
            int rate = Convert.ToInt32(numPacketRate.Value);
            if (SendSerialMessage($"teststart 4 {pwr} {testMode} {freq} {rate}", "teststart command success"))
            {
                btnToneStart.Enabled = false;
            }
        }

        private void btnToneStop_Click(object sender, EventArgs e)
        {
            Program.Log("stopping test / 停止");
            btnToneStart.Enabled = true;
            string port = GetCurrentSerialPort();
            if (string.IsNullOrWhiteSpace(port))
            {
                Program.Log("ERROR/错误: no serial port selected / 没有串口");
                return;
            }
            SendSerialMessage("reboot", "ESP32 rebooting...");
        }

        private void dropSerialPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropSerialPorts.Items.Count > 0)
            {
                string oldItem = (string)dropSerialPorts.SelectedItem;
                if (string.IsNullOrWhiteSpace(oldItem) == false)
                {
                    lastSelectedPort = oldItem;
                }
            }
        }

        private void LoadFirmware(string firmware)
        {
            if (string.IsNullOrWhiteSpace(GetCurrentSerialPort()))
            {
                Program.Log("ERROR/错误: no serial port selected / 没有串口");
                return;
            }

            string command = $"esptool.exe --chip esp32 --port {GetCurrentSerialPort()} --baud 921600 write_flash --erase-all -z --flash_mode dio --flash_freq 40m --flash_size detect 0x1000 bootloader.bin 0x8000 partitions.bin 0xE000 boot_app0.bin 0x10000 {firmware}";
            //string command = "esptool.exe";

            // Create a new process
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/K \"{command}\"";
            process.StartInfo.UseShellExecute = false;
            //process.StartInfo.RedirectStandardOutput = true;
            //process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = false;

            // Start the process
            Program.Log("running CMD / 运行命令: " + command);
            process.Start();
            process.WaitForExit();
        }

        private void btnLoadTestFirmware_Click(object sender, EventArgs e)
        {
            LoadFirmware("shrew_firmware_test.bin");
        }

        private void btnLoadProdFirmware_Click(object sender, EventArgs e)
        {
            LoadFirmware("shrew_firmware_product.bin");
        }

        private bool SendSerialMessage(string message, string confirm)
        {
            bool success = false;
            if (string.IsNullOrWhiteSpace(GetCurrentSerialPort()))
            {
                Program.Log("ERROR/错误: no serial port selected / 没有串口");
                return false;
            }
            SerialPort port = null;
            try
            {
                port = new SerialPort(GetCurrentSerialPort(), 115200);
                port.Open();
                port.DiscardInBuffer();
                port.Write("\n" + message + "\n");
                Program.Log("serial sent (写): " + message);
                string reply = "";
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    reply += port.ReadExisting();
                    if (reply.Contains(confirm))
                    {
                        success = true;
                        break;
                    }
                }
                if (success)
                {
                    Program.Log("command success / 命令成功");
                }
                else
                {
                    Program.Log("command got no reply / 命令没有回复");
                }
            }
            catch (Exception ex)
            {
                Program.Log("ERROR/错误 during serial send: " + ex.Message);
            }
            finally
            {
                if (port != null)
                {
                    try
                    {
                        port.Close();
                    }
                    catch
                    {
                    }
                }
            }
            return success;
        }

        private void dropTestMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = dropTestMode.SelectedIndex;
            if (i == 1 || i == 2)
            {
                lblFrequency.Visible = false;
                lblMhz.Visible = false;
                numFrequency.Visible = false;
            }
            else
            {
                lblFrequency.Visible = true;
                lblMhz.Visible = true;
                numFrequency.Visible = true;
            }
            if (i == 0)
            {
                lblPacketRate.Visible = false;
                lblPacketsPerSecond.Visible = false;
                numPacketRate.Visible = false;
            }
            else
            {
                lblPacketRate.Visible = true;
                lblPacketsPerSecond.Visible = true;
                numPacketRate.Visible = true;
            }
        }
    }
}
