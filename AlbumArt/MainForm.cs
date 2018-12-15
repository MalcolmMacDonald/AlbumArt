using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace AlbumArt
{
    public delegate void ThreadCallback();

    public partial class MainForm : Form
    {
        public ArtRetrieval artRetiever;
        public SpotifyConnection spotifyConnection;
        AlbumList currentAlbumList;
        public string currentSaveFolder;
        public string currentReadout;

        Thread readoutThread;
        Thread heatmapDisplayThread;
        int currentYearIndex = 0;
        int currentYear
        {
            get
            {
                if(artRetiever == null)
                {
                    return 1999;
                }
                if(artRetiever.years == null)
                {
                    return 1999;
                }
                if(artRetiever.years.Count <= currentYearIndex)
                {
                    return 1999;
                }
                return artRetiever.years[currentYearIndex];
            }
        }

        public MainForm()
        {

            InitializeComponent();
            artRetiever = new ArtRetrieval(this);
            currentAlbumList = new AlbumList(this);



            if (Properties.Settings.Default.FolderPath != "")
            {
                currentSaveFolder = Properties.Settings.Default.FolderPath;

            }

            spotifyConnection = new SpotifyConnection(this);

            spotifyConnection.ConnectToAPI();

            readoutLabel.Text = "";


        }




        private void mainFormLoad(object sender, EventArgs e)
        {

        }



        private void folderSelectButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                currentSaveFolder = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.FolderPath = currentSaveFolder;
                Properties.Settings.Default.Save();
            }
        }


        private void spotifyConnectButton_Click(object sender, EventArgs e)
        {
            spotifyConnection.ConnectToAPI();
        }

        public void HideSpotifyButton()
        {
            spotifyConnectButton.Hide();

        }




        private void previousYearButton_Click(object sender, EventArgs e)
        {

            currentYearIndex--;
            if(currentYearIndex < 0)
            {
                currentYearIndex = 0;
            }


            currentYearLabel.Text = currentYear.ToString();
        }

        private void nextYearButton_Click(object sender, EventArgs e)
        {

            currentYearIndex++;
            if (artRetiever.years != null)
            {
                if (currentYearIndex >= artRetiever.years.Count)
                {
                    currentYearIndex--;
                }
            }
            else
            {
                return;
            }
            currentYearLabel.Text = currentYear.ToString();

        }



        private void startButton_Click(object sender, EventArgs e)
        {
            RunReadoutThread();
            RunHeatmapDiplayThread();
            currentAlbumList.LoadAlbums();
        }

        void RunReadoutThread()
        {
            readoutThread = new Thread(() =>
            {
                while (true)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        readoutLabel.Text = currentReadout;
                    });
                    Thread.Sleep(100);
                }
            });
            readoutThread.Start();
        }

        public void DisplayString(string input)
        {
            currentReadout = input;
        }
        void RunHeatmapDiplayThread()
        {
            heatmapDisplayThread = new Thread(() =>
            {
                while (true)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        heatMapDisplay.Image = artRetiever.GetHeatMap(currentYear);
                    });
                    Thread.Sleep(100);
                }
            });
            heatmapDisplayThread.Start();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (readoutThread != null && readoutThread.IsAlive)
            {
                readoutThread.Abort();
            }
            if (heatmapDisplayThread != null && heatmapDisplayThread.IsAlive)
            {
                heatmapDisplayThread.Abort();
            }

            base.OnFormClosing(e);
        }

    }

}
