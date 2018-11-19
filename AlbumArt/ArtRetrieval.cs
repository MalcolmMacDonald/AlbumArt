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
    class ArtRetrieval
    {

        MainForm currentForm;


        public ArtRetrieval(MainForm form)
        {
            currentForm = form;


            


        }

        public void GetAlbumArt(string folder)
        {
            Paging<SavedAlbum> albums = currentForm.spotifyConnection.GetSavedAlbums();
            WebClient webclient = new WebClient();
            string imageFolderPath = Properties.Settings.Default.FolderPath +  "\\";

            for (int i = 0; i < Math.Min(albums.Limit,albums.Total); i++)
            {
                string albumName = albums.Items[i].Album.Name;
                
                webclient.DownloadFile(albums.Items[i].Album.Images[1].Url, imageFolderPath + albumName + ".bmp");

            }

            webclient.Dispose();
        }

    }
}
