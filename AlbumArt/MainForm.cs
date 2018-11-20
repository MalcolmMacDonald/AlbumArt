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
using Tesseract;
namespace AlbumArt
{
    public partial class MainForm : Form
    {
        public ArtRetrieval artRetiever;
        public SpotifyConnection spotifyConnection;
        AlbumList currentAlbumList;
        public string currentSaveFolder;
        Image currentImage;
        string[] imageFiles;

        Rect[] currentRects;
        
        public MainForm()
        {

            InitializeComponent();
            spotifyConnection = new SpotifyConnection(this);

            spotifyConnection.ConnectToAPI();

            currentRects = new Rect[0];
            pictureBox1.Paint += PictureBox1_Paint;
            artRetiever = new ArtRetrieval(this);
            currentAlbumList = new AlbumList(this);

            if (Properties.Settings.Default.FolderPath != "")
            {
                currentSaveFolder = Properties.Settings.Default.FolderPath;
                PrintString("Folder found: " + currentSaveFolder);

            }

        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen outlinePen = new Pen(new System.Drawing.SolidBrush(Color.Red));
            Brush fillBrush = new System.Drawing.SolidBrush(Color.FromArgb(200, 255, 0, 0));

            for (int i = 0; i < currentRects.Length; i++)
            {
                if (currentRects[i] != null)
                {
                    Rect currentRect = currentRects[i];
                    //Size sizestep1 = Size.Subtract(new Size(pictureBox1.Image.Size.Width / 2, pictureBox1.Image.Size.Height / 2), pictureBox1.Size);

                    // Convert to point.
                    //Point BottomRightCoords = new Point(sizestep1.Width, sizestep1.Height);

                    //float xScale = (float)pictureBox1.Width / currentImage.Width;
                    int xPos = currentRect.X1;
                    int yPos = currentRect.Y1;
                    int rectWidth = currentRect.X2 - currentRect.X1;
                    int rectHeight = currentRect.Y2 - currentRect.Y1;

                    e.Graphics.DrawRectangle(outlinePen, xPos, yPos, rectWidth, rectHeight);
                    e.Graphics.FillRectangle(fillBrush, xPos, yPos, rectWidth, rectHeight);
                }
            }
            outlinePen.Dispose();
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
            LoadImages();
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
            imageFiles = Directory.GetFiles(currentSaveFolder);


            retrieveButton.Hide();
            imageSelector.Visible = true;
            imageSelector.Maximum = imageFiles.Length - 1;

            currentImage = Image.FromFile(imageFiles[0]);
            pictureBox1.Image = currentImage;

            DetectText();
        }


        void DetectText()
        {
            string tessPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +"\\tessdata";
            TesseractEngine tess = new TesseractEngine(tessPath, "eng");

            Page newPage = tess.Process(new Bitmap(currentImage), PageSegMode.AutoOsd);

            ResultIterator iterator = newPage.GetIterator();
            string totalText = newPage.GetText();
            currentRects = new Rect[totalText.Length];
            for (int i = 0; i < totalText.Length; i++)
            {
                Rect foundRect = new Rect();
                string symbolText = iterator.GetText(PageIteratorLevel.Symbol);
                bool hasText = symbolText != "" && symbolText != null;
                bool onlyLetters = false;
                if (hasText)
                {
                    onlyLetters = symbolText.ToCharArray().All(s => char.IsLetter(s));
                }

                bool gotBoundingBox = iterator.TryGetBoundingBox(PageIteratorLevel.Symbol, out foundRect);
                if (hasText && onlyLetters && gotBoundingBox)
                {
                    currentRects[i] = foundRect;
                }
                iterator.Next(PageIteratorLevel.Symbol);
            }
            pictureBox1.Refresh();
            tess.Dispose();
            iterator.Dispose();
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
                DetectText();
            }
        }
    }
}
