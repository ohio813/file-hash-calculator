using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

namespace FileHashCalculator
{
    public partial class MainForm : Form
    {
        private string[] _algoList = new string[] { "MD5", "SHA1", "SHA256", "SHA384", "SHA512" };
        private FileStream _file;
        private Thread _hashThread;
        private bool _started;

        const int BUFFER_SIZE = 4096;

        public MainForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "All files (*.*)|*.*";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _file = (FileStream)openFile.OpenFile();
                        fileTextBox.Text = openFile.FileName;
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void generateHashesButton_Click(object sender, EventArgs e)
        {
            hashListView.Items.Clear();

            if (_file == null)
                return;

            if (_hashThread == null || _hashThread.IsAlive == false)
                _hashThread = new Thread(new ThreadStart(HashThreadProc));

            if (_started)
                return;

            _hashThread.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void HashThreadProc()
        {
            _started = true;

            foreach (string hashAlgoName in _algoList)
            {
                // create a new hash object for the algorithm
                HashAlgorithm hashAlgoObject = HashAlgorithm.Create(hashAlgoName);
                // updates form with progress updates and returns hash
                byte[] hash = CalculateHashWithProgress(_file, hashAlgoObject);
                // just to make this look a little cleaner
                string hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();
                // thread safe call to add it to the list.
                AddHashToList(hashAlgoName, hashString);
            }

            _started = false;
        }

        private byte[] CalculateHashWithProgress(Stream input, HashAlgorithm algorithm)
        {
            byte[] buffer = new byte[BUFFER_SIZE];
            int readCount;
            long streamSize = input.Length;
            long totalBytesRead = 0;

            input.Position = 0; // reset position to beginning of the file.

            while ((readCount = input.Read(buffer, 0, BUFFER_SIZE)) > 0)
            {
                algorithm.TransformBlock(buffer, 0, readCount, buffer, 0);
                totalBytesRead += readCount;
                UpdateProgress((int)((double)totalBytesRead * 100 / streamSize));
            }

            algorithm.TransformFinalBlock(buffer, 0, readCount);
            UpdateProgress((int)((double)totalBytesRead * 100 / streamSize));

            return algorithm.Hash;
        }

        private void UpdateProgress(int progress)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                hashProgressBar.Value = progress;
                hashPercentageLabel.Text = String.Format("{0}%", progress);
            }));
        }

        private void AddHashToList(string algo, string hash)
        {
            this.Invoke(new MethodInvoker(delegate {
                ListViewItem lvi = new ListViewItem(algo);
                lvi.SubItems.Add(hash);
                hashListView.Items.Add(lvi);
            }));
        }
    }
}
