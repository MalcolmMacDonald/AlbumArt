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
        public string testString;

        Thread uiThread;

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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (uiThread != null && uiThread.IsAlive)
            {
                uiThread.Join();
            }


            base.OnFormClosing(e);
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

        }



        private void startButton_Click(object sender, EventArgs e)
        {
            RunUIThread();
            currentAlbumList.LoadAlbums();
        }

        void RunUIThread()
        {
            uiThread = new Thread(() =>
            {
                while(true)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        readoutLabel.Text = testString;
                    });
                    Thread.Sleep(100);
                }
            });
            uiThread.Start();
        }
    }
}
