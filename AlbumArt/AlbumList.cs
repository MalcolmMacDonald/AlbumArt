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
        Dictionary<int, List<FullAlbum>> albumsByYear;
        Dictionary<FullArtist, List<FullAlbum>> albumsByArtist;
        List<string> names;
        ArtistData[] savedArtistData;


        string albumDataJsonPath;

        public AlbumList(MainForm newForm)
        {
            currentForm = newForm;
            string thisFolder= System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            thisFolder = thisFolder.Substring(0, thisFolder.LastIndexOf("AlbumArt"));
            albumDataJsonPath = thisFolder + "SavedAlbumData.json";
            string grammyDataPath = thisFolder + "grammyData.json";

            Console.WriteLine(thisFolder);

            string currentJson = File.ReadAllText(grammyDataPath);

            if (File.Exists(albumDataJsonPath))
            {
                savedArtistData = JsonConvert.DeserializeObject<ArtistData[]>(File.ReadAllText(albumDataJsonPath));
            }
            else
            {
                List<string> artistNames = GetArtistsFromJson(currentJson);
                Task getArtistsTask = GetArtists(artistNames);
            }





            

        }

        List<string> GetArtistsFromJson(string json)
        {
            GrammyObject[] allObjects = JsonConvert.DeserializeObject<GrammyObject[]>(json);
            allObjects = allObjects.Where(s => s.awardType != "Individual").ToArray();
            List<string> artistNames = new List<string>();
            for (int i = 0; i < allObjects.Length; i++)
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
            albumsByArtist = new Dictionary<FullArtist, List<FullAlbum>>();
            names = new List<string>();
            for (int i = 0; i < artistNames.Count; i++)
            {
                FullArtist artistFromName = await currentForm.spotifyConnection.GetArtistFromName(artistNames[i]);
                if (artistFromName != null)
                {
                    albumsByArtist.Add(artistFromName, new List<FullAlbum>());
                    names.Add(artistFromName.Name);
                    Console.WriteLine(artistFromName.Name);
                }
            }
            Console.WriteLine("DONE");
            WriteToJson();

        }

        void WriteToJson()
        {
            if (File.Exists(albumDataJsonPath))
            {
                File.Delete(albumDataJsonPath);
            }

            ArtistData[] allArtists = new ArtistData[names.Count];
            for (int i = 0; i < allArtists.Length; i++)
            {
                allArtists[i] = new ArtistData(names[i], null);
            }

            StreamWriter writer = File.CreateText(albumDataJsonPath);
            string JsonData = JsonConvert.SerializeObject(allArtists);
            writer.Write(JsonData);
            writer.Close();
        }

        void ReadFromJson()
        {

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
