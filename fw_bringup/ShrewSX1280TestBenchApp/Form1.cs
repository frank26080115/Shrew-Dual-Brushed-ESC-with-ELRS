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

namespace ShrewSX1280TestBenchApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = Application.ProductName;
            PopulateSerialPorts();
        }

        private void PopulateSerialPorts()
        {
            string oldItem = string.Empty;
            if (dropSerialPorts.Items.Count > 0)
            {
                oldItem = (string)dropSerialPorts.SelectedItem;
            }
            dropSerialPorts.Items.Clear();

            foreach (string port in SerialPort.GetPortNames())
            {
                string portInfo = GetPortInformation(port);
                dropSerialPorts.Items.Add(portInfo);
            }
            if (oldItem.Length > 0)
            {
                SelectClosestMatch(dropSerialPorts, oldItem);
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

        private void btnLoadFirmware_Click(object sender, EventArgs e)
        {

        }
    }
}
