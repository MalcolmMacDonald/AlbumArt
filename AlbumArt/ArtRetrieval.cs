using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Drawing;
using System.IO;
using SpotifyAPI.Web.Models;


namespace AlbumArt
{
    public class ArtRetrieval
    {

        MainForm currentForm;

        const int imageSize = 300;
        Dictionary<int, Bitmap> heatMaps;
        public List<int> years;
        TextDetection textDetector;
        string currentImageFolder
        {
            get
            {
                return Properties.Settings.Default.FolderPath + "\\";
            }
        }

        public ArtRetrieval(MainForm form)
        {
            currentForm = form;
            textDetector = new TextDetection();
            heatMaps = new Dictionary<int, Bitmap>();
            years = new List<int>();
        }

        public void GetAlbumArt(List<SimpleAlbum> artistAlbums = null)
        {

            //Paging<SavedAlbum> albums = currentForm.spotifyConnection.GetSavedAlbums();
            WebClient webclient = new WebClient();

            EmptyFolder(currentImageFolder);
            currentForm.DisplayString("Downloading Images");

            for (int i = 0; i < artistAlbums.Count; i++)
            {
                string albumName = artistAlbums[i].Name;
                albumName = GetLegalAlbumName(albumName);
                string albumYear = artistAlbums[i].ReleaseDate;
                if (albumYear.Contains('-'))
                {
                    albumYear = albumYear.Substring(0, albumYear.IndexOf('-'));
                }
                if (albumName != "" && artistAlbums[i].Images.Count() > 1)
                {
                    string yearFolder = currentImageFolder  + albumYear;

                    Directory.CreateDirectory(yearFolder);

                    if (!years.Contains(int.Parse(albumYear)))
                    {
                        years.Insert(0,int.Parse(albumYear));
                    }
                    
                    if(File.Exists(yearFolder + "\\" + albumName + ".bmp"))
                    {
                        continue;
                    }

                    try
                    {
                        webclient.DownloadFile(artistAlbums[i].Images[1].Url, yearFolder + "\\" + albumName + ".bmp");
                    }
                    catch (Exception ex)
                    {
                         Console.WriteLine("Could not download image: " + albumName + " " + ex);
                    }

                }
            }

            webclient.Dispose();
        }


        void EmptyFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                return;
            }
            DirectoryInfo di = new DirectoryInfo(folderPath);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

        }

        string GetLegalAlbumName(string input)
        {
            StringBuilder newBuilder = new StringBuilder(input);
            foreach(char c in Path.GetInvalidFileNameChars())
            {
                newBuilder.Replace(c, '_');
            }
            return newBuilder.ToString();
        }


        public void GetHeatMapsFromCurrentFiles()
        {
            DirectoryInfo info = new DirectoryInfo(currentImageFolder);
            DirectoryInfo[] yearFolders = info.GetDirectories();
            Random randomizer = new Random();

            SolidBrush heatMapBrush = new SolidBrush(Color.FromArgb(10, Color.Red));
            foreach(DirectoryInfo yearFolder in yearFolders)
            {
                int thisYear = int.Parse(yearFolder.Name);
                currentForm.DisplayString(string.Format("Finding text in year {0}",thisYear));


                heatMaps.Add(thisYear, new Bitmap(imageSize,imageSize));
                FileInfo[] albumImages = yearFolder.GetFiles();
                foreach(FileInfo file in albumImages)
                {
                    Bitmap fileImage = new Bitmap(Bitmap.FromFile(file.FullName));
                    List<Rectangle> imageRects = textDetector.GetTextRects(fileImage);

                    Graphics imageGraphics = Graphics.FromImage(heatMaps[thisYear]);

                    for(int i = 0; i < imageRects.Count; i++)
                    {
                        imageGraphics.FillRectangle(heatMapBrush,imageRects[i]);
                    }
                }


          }

            Console.WriteLine("Got heat maps");
        }
        public void ClearFolder()
        {

            DirectoryInfo info = new DirectoryInfo(currentImageFolder);
            FileInfo[] foundFiles = info.GetFiles();
            foreach (FileInfo file in foundFiles)
            {
                file.Delete();
            }
        }
        public Bitmap GetHeatMap(int year)
        {
            if (!heatMaps.ContainsKey(year))
            {
                return null;
            }
            if (!years.Contains(year))
            {
                return null;
            }

            Bitmap imageToReturn = heatMaps[year];
            return imageToReturn;

        }


    }
}
