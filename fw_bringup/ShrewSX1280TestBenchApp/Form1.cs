﻿using System;
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

namespace ShrewSX1280TestBenchApp
{
    public partial class Form1 : Form
    {
        private string lastSelectedPort = null;
        public Form1()
        {
            InitializeComponent();
            Program.LogTextBox = txtLog;
            this.Text = Application.ProductName;
            PopulateSerialPorts();
            Program.Log("program launched");
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
                info += " - Info not available";
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
                Program.Log("error: no serial port selected");
                return;
            }
            Program.Log("starting continuous wave test");
            int freq = Convert.ToInt32(numFrequency.Value);
            //Program.Log($"freq: {freq} ; port: \"{port}\"");
            //btnToneStart.Enabled = false;
            //btnToneStop.Enabled = true;
            //numFrequency.Enabled = false;
            SendSerialMessage($"testtone 4 {freq}");
        }

        private void btnToneStop_Click(object sender, EventArgs e)
        {
            Program.Log("stopping continuous wave test");
            //btnToneStart.Enabled = true;
            //btnToneStop.Enabled = false;
            //numFrequency.Enabled = true;
            string port = GetCurrentSerialPort();
            if (string.IsNullOrWhiteSpace(port))
            {
                Program.Log("error: no serial port selected");
                return;
            }
            SendSerialMessage("reboot");
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
                Program.Log("ERROR: no serial port selected");
                return;
            }

            string command = $"esptool.exe --chip esp32 --port {GetCurrentSerialPort()} --baud 921600 write_flash -z 0x1000 {firmware}";
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
            Program.Log("running CMD: " + command);
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

        private void SendSerialMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(GetCurrentSerialPort()))
            {
                Program.Log("ERROR: no serial port selected");
                return;
            }
            SerialPort port = null;
            try
            {
                port = new SerialPort(GetCurrentSerialPort(), 115200);
                port.Open();
                port.Write("\n" + message + "\n");
                Program.Log("serial sent: " + message);
            }
            catch (Exception ex)
            {
                Program.Log("ERROR during serial send: " + ex.Message);
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
        }
    }
}