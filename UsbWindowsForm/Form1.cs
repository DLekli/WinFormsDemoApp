
using System;
using System.IO.Ports;
using System.Management;
using System.Windows.Forms;
namespace UsbWindowsForm
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        public Form1()
        {
            InitializeComponent();
            InitializeSerialPort();
        }

        /*private void InitializeSerialPort()
        {
            SerialPort serialPort= new SerialPort();
            serialPort.BaudRate = 9600; // Set the baud rate according to your device specifications
            serialPort.DataReceived += SerialPort_DataReceived;

            // Set the COM port to the correct port where your USB scale is connected
            serialPort.PortName = "COM3"; // Change this to your actual COM port

            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening serial port: {ex.Message}");
            }
        }*/

        /*private void InitializeSerialPort()
        {
            string[] ports = SerialPort.GetPortNames();

            if (ports.Length == 0)
            {
                MessageBox.Show("No COM ports found. Make sure your USB scale is connected.");
                return;
            }

            // Assume the first port is the one you want to use. You might need to adjust this logic.
            string comPort = ports[0];

            serialPort = new SerialPort(comPort);
            serialPort.BaudRate = 9600; // Set the baud rate according to your device specifications
            serialPort.DataReceived += SerialPort_DataReceived;

            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening serial port: {ex.Message}");
            }
        }

        private string FindCOMPort()
        {
            string comPort = null;

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    object caption = queryObj["Caption"];
                    if (caption != null && caption.ToString().Contains("(COM"))
                    {
                        comPort = caption.ToString().Substring(caption.ToString().IndexOf("(COM")).Split(' ')[0];
                        break;
                    }
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show($"Error finding COM port: {e.Message}");
            }

            return comPort;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine();
                UpdateUI(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading data from serial port: {ex.Message}");
            }
        }

        private void UpdateUI(string data)
        {
            lblWeight.Invoke((MethodInvoker)delegate
            {
                lblWeight.Text = $"Weight: {data}"; // Assuming data is the weight value
            });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }*/

        private void InitializeSerialPort()
        {
            string[] ports = SerialPort.GetPortNames();

            if (ports.Length == 0)
            {
                MessageBox.Show("No COM ports found. Make sure your USB scale is connected.");
                return;
            }

            // Assume the first port is the one you want to use. You might need to adjust this logic.
            string comPort = ports[0];

            serialPort = new SerialPort(comPort);
            serialPort.BaudRate = 9600; // Set the baud rate according to your device specifications
            serialPort.DataReceived += SerialPort_DataReceived;

            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening serial port: {ex.Message}");
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine();
                UpdateUI(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading data from serial port: {ex.Message}");
            }
        }

        private void UpdateUI(string data)
        {
            lblWeight.Invoke((MethodInvoker)delegate
            {
                lblWeight.Text = $"Weight: {data}"; // Assuming data is the weight value
            });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }
}