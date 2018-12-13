using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        Image currentImage;
        string[] imageFiles;
        
        public MainForm()
        {

            InitializeComponent();
            artRetiever = new ArtRetrieval(this);
            currentAlbumList = new AlbumList(this);

            

            if (Properties.Settings.Default.FolderPath != "")
            {
                currentSaveFolder = Properties.Settings.Default.FolderPath;
                PrintString("Folder found: " + currentSaveFolder);

            }

            spotifyConnection = new SpotifyConnection(this);

            spotifyConnection.ConnectToAPI();

            currentAlbumList.LoadAlbums();

            ShowRetrieveButton();
            pictureBox1.Paint += PictureBox1_Paint;




        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }





        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void folderSelectButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                currentSaveFolder = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.FolderPath = currentSaveFolder;
                Properties.Settings.Default.Save();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
        }
        public void PrintString(string value)
        {
            mainTextBox.Text += value + Environment.NewLine;
        }

        private void retrieveButton_Click(object sender, EventArgs e)
        {
            if (currentSaveFolder == "")
            {
                PrintString("Folder not set.");
                return;
            }

            pictureBox1.Image = artRetiever.GetHeatMap();
           // LoadImages();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        public void HideSpotifyButton()
        {
            connectButton.Hide();

        }
        public void ShowRetrieveButton()
        {
            retrieveButton.Visible = true;
        }

        void LoadImages()
        {
            imageFiles = Directory.GetFiles(currentSaveFolder + "\\1959");


            retrieveButton.Hide();
            imageSelector.Visible = true;
            imageSelector.Maximum = imageFiles.Length - 1;

            currentImage = Image.FromFile(imageFiles[0]);
            pictureBox1.Image = currentImage;

        }




        private void imageSelector_ValueChanged(object sender, EventArgs e)
        {
            int index = (int)imageSelector.Value;
            if(index < 0)
            {
                index = 0;
            }
            if (imageFiles.Length > index)
            {
                currentImage = Image.FromFile(imageFiles[index]);
                pictureBox1.Image = currentImage;
            }
        }
    }
}
