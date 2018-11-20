using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using Newtonsoft.Json;
using System.IO;

namespace AlbumArt
{
    class AlbumList
    {
        MainForm currentForm;
        Dictionary<int, List<SimpleAlbum>> albumsByYear;
        Dictionary<FullArtist, List<SimpleAlbum>> albumsByArtist;
        List<FullArtist> foundArtists;


        string albumDataJsonPath;

        public AlbumList(MainForm newForm)
        {
            currentForm = newForm;
            string thisFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            thisFolder = thisFolder.Substring(0, thisFolder.LastIndexOf("AlbumArt"));
            albumDataJsonPath = thisFolder + "SavedAlbumData.json";
            string grammyDataPath = thisFolder + "grammyData.json";

            Console.WriteLine(thisFolder);

            string currentJson = File.ReadAllText(grammyDataPath);

            foundArtists = new List<FullArtist>();
            List<string> artistNames = GetArtistsFromJson(currentJson);
            Task getArtistsTask = GetArtists(artistNames);
            getArtistsTask.ContinueWith(task => GetAllAlbums());

        }

        List<string> GetArtistsFromJson(string json)
        {
            GrammyObject[] allObjects = JsonConvert.DeserializeObject<GrammyObject[]>(json);
            allObjects = allObjects.Where(s => s.awardType != "Individual").ToArray();
            List<string> artistNames = new List<string>();
            for (int i = 0; i < Math.Min(10,allObjects.Length); i++)
            {
                if (!artistNames.Contains(allObjects[i].name))
                {
                    artistNames.Add(allObjects[i].name);
                }
            }
            return artistNames;
        }

        public async Task GetArtists(List<string> artistNames)
        {
            albumsByArtist = new Dictionary<FullArtist, List<SimpleAlbum>>();
            for (int i = 0; i < artistNames.Count; i++)
            {
                FullArtist artistFromName = await currentForm.spotifyConnection.GetArtistFromName(artistNames[i]);
                if (artistFromName != null)
                {
                    albumsByArtist.Add(artistFromName, new List<SimpleAlbum>());
                    foundArtists.Add(artistFromName);
                    Console.WriteLine(artistFromName.Name);
                }
            }
            Console.WriteLine("DONE");


 

        }
        
    

        async Task GetAllAlbums()
        {
            for (int i = 0; i < foundArtists.Count(); i++)
            {
               List<SimpleAlbum> foundAlbums = await currentForm.spotifyConnection.GetAlbumsFromArtist(foundArtists[i]);

                albumsByArtist[foundArtists[i]] = foundAlbums;
                currentForm.artRetiever.GetAlbumArt(currentForm.currentSaveFolder, albumsByArtist[foundArtists[i]]);
            }
        }
    }
    struct GrammyObject
    {
        public string category;
        public int annualGrammy;
        public string awardType;
        public string name;
        public string awardFor;

    }
    struct ArtistData
    {
        public string artistName;
        public AlbumData[] albums;
        public ArtistData(string name, AlbumData[] _albums)
        {
            artistName = name;
            albums = _albums;
        }
    }

    struct AlbumData
    {
        public string albumName;
        public string albumArtPath;
        public int year;

    }
}
