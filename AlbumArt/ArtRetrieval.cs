using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System.Net;
using System.IO;
namespace AlbumArt
{
    class ArtRetrieval
    {
        string _clientId = "ff4babd3faad4128abc7910b5525c06d";
        string _secretId = "089de4c878314c6aae67ea2d1a451d4b";
        MainForm currentForm;
        SpotifyAPI.Web.SpotifyWebAPI _spotify;

        public ArtRetrieval(MainForm form)
        {
            currentForm = form;
            _spotify = new SpotifyWebAPI()
            {
                UseAuth = false,
            };
        }
        public async void ConnectToAPI() {

            WebAPIFactory webApiFactory = new WebAPIFactory(
                "http://localhost",
                8000,
                _clientId,
                Scope.UserReadPrivate,
                TimeSpan.FromSeconds(20)
                );
            try
            {
                //This will open the user's browser and returns once
                //the user is authorized.
                _spotify = await webApiFactory.GetWebApi();
            }
            catch (Exception ex)
            {
                currentForm.PrintString(ex.Message);
            }

            if (_spotify == null)
            {
                return;
            }
            else
            {
                currentForm.HideSpotifyButton();
                currentForm.ShowRetrieveButton();
                currentForm.PrintString("Connected.");
            }

            

        }
        public void GetAlbumArt(string folder)
        {
            Paging<SavedAlbum> albums = _spotify.GetSavedAlbums();
            WebClient webclient = new WebClient();

            for (int i = 0; i < Math.Min(albums.Limit,albums.Total); i++)
            {
                string albumName = albums.Items[i].Album.Name;

                webclient.DownloadFile(albums.Items[i].Album.Images[1].Url, "D:\\Malcolm MacDonald\\Pictures\\AlbumArt\\" + albumName + ".bmp");

            }

            webclient.Dispose();
        }

    }
}
