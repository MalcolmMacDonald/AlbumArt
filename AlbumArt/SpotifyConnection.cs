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
using Newtonsoft.Json;
using System.IO;
namespace AlbumArt
{
    public class SpotifyConnection
    {


        SpotifyAPI.Web.SpotifyWebAPI _spotify;
        MainForm currentForm;
        ConnectionData data;
        public SpotifyConnection(MainForm newForm)
        {
            currentForm = newForm;

            string thisFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            thisFolder = thisFolder.Substring(0, thisFolder.LastIndexOf("AlbumArt"));

            string jsonPath = thisFolder + "\\SpotifyAuthData.json";
            if (File.Exists(jsonPath))
            {
                data = JsonConvert.DeserializeObject<ConnectionData>(File.ReadAllText(jsonPath));
            }
            else
            {
                StreamWriter writer = File.CreateText(jsonPath);
                writer.Write(JsonConvert.SerializeObject(data));
                writer.Close();
            }


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
                data._clientId,
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
        public async Task<List<SimpleAlbum>> GetAlbumsFromArtist(FullArtist artist)
        {
            Paging<SimpleAlbum> albumCollection = await _spotify.GetArtistsAlbumsAsync(artist.Id, AlbumType.Album, 50, 50);
            return albumCollection.Items;

        }
        struct ConnectionData
        {
            public string _clientId;
            public string _secretId;
        }
    }
}
