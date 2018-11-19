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
namespace AlbumArt
{
    public class SpotifyConnection
    {
        string _clientId = "ff4babd3faad4128abc7910b5525c06d";
        string _secretId = "089de4c878314c6aae67ea2d1a451d4b";

        SpotifyAPI.Web.SpotifyWebAPI _spotify;
        MainForm currentForm;
        public SpotifyConnection(MainForm newForm)
        {
            currentForm = newForm;
            _spotify = new SpotifyWebAPI()
            {
                UseAuth = false,
            };
        }

        public async void ConnectToAPI()
        {

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
        public Paging<SavedAlbum> GetSavedAlbums()
        {
          return _spotify.GetSavedAlbums();
        }
        public async Task<FullArtist> GetArtistFromName(string artistName)
        {
            SearchItem foundArtists = await _spotify.SearchItemsAsync(artistName, SearchType.Artist);
            
            if (foundArtists != null && foundArtists.Artists.Items.Count > 0)
            {
                return foundArtists.Artists.Items[0];
            }

            return null;
        }
    }
}
