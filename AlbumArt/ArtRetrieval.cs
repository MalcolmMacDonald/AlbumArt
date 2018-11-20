using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web;
using System.Net;

using System.IO;


namespace AlbumArt
{
    public class ArtRetrieval
    {

        MainForm currentForm;


        public ArtRetrieval(MainForm form)
        {
            currentForm = form;


        }

        public void GetAlbumArt(string folder, List<SimpleAlbum> artistAlbums = null)
        {

            //Paging<SavedAlbum> albums = currentForm.spotifyConnection.GetSavedAlbums();
            WebClient webclient = new WebClient();
            string imageFolderPath = Properties.Settings.Default.FolderPath +  "\\";

            for (int i = 0; i < artistAlbums.Count(); i++)
            {
                string albumName = artistAlbums[i].Name;
                string albumYear = artistAlbums[i].ReleaseDate;
                albumYear = albumYear.Substring(0, albumYear.IndexOf('-'));
                if (albumName != "" && artistAlbums[i].Images.Count() > 1)
                {
                    Console.WriteLine(albumName);
                    try
                    {
                        webclient.DownloadFile(artistAlbums[i].Images[1].Url, imageFolderPath + albumYear + " " + albumName + ".bmp");
                    }
                    catch (Exception ex)
                    {
                      //  Console.WriteLine("Could not download image: " + albumName + " " + ex);
                    }
                    
                }
            }

            webclient.Dispose();
        }

    }
}
