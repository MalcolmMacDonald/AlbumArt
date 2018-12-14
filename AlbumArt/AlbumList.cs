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
        List<string> artistNames;

        string thisFolder;

        string albumDataJsonPath;
        string grammyDataPath;

        string currentArtistNamesJson;


        int totalArtistCount = int.MaxValue;
        public AlbumList(MainForm newForm)
        {
            currentForm = newForm;

            thisFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            thisFolder = thisFolder.Substring(0, thisFolder.LastIndexOf("AlbumArt"));

            albumDataJsonPath = thisFolder + "SavedAlbumData.json";
            grammyDataPath = thisFolder + "GrammyData.json";

            Console.WriteLine(thisFolder);

            currentArtistNamesJson = File.ReadAllText(grammyDataPath);


            artistNames = GetArtistsFromJson();


        }
        List<string> GetArtistsFromJson()
        {
            GrammyObject[] allObjects = JsonConvert.DeserializeObject<GrammyObject[]>(currentArtistNamesJson);
            allObjects = allObjects.Where(s => s.awardType != "Individual").ToArray();
            List<string> artistNames = new List<string>();
            int currentArtistCount = 0;
            int i = 0;
            while (currentArtistCount < totalArtistCount && i < allObjects.Length)
            {
                if (!artistNames.Contains(allObjects[i].name))
                {

                    artistNames.Add(allObjects[i].name);
                    currentArtistCount++;
                }
                i++;

            }
            return artistNames;
        }

        public void LoadAlbums( )
        {
            Task.Run(() => GetArtists());

           // getArtistsTask = getArtistsTask.ContinueWith(task => GetAlbumsFromArtists());
        }



        public async Task GetArtists( )
        {
            foundArtists = new List<FullArtist>();
            albumsByArtist = new Dictionary<FullArtist, List<SimpleAlbum>>();
            for (int i = 0; i < artistNames.Count; i++)
            {
                FullArtist artistFromName = await currentForm.spotifyConnection.GetArtistFromName(artistNames[i]);
                if (artistFromName != null)
                {
                    albumsByArtist.Add(artistFromName, new List<SimpleAlbum>());
                    foundArtists.Add(artistFromName);
                    currentForm.testString =string.Format("Found artist {0} from name {1}",artistFromName.Name,artistNames[i]);
        }
                else
                {
                    Console.WriteLine("Could not find artist {0} on spotify",artistNames[i]);
                }
            }

            Console.WriteLine("Done finding artists on spotify");

            for (int i = 0; i < artistNames.Count; i++)
            {
                
                Console.WriteLine("Finding text from artist {0}", foundArtists[i].Name);
                await GetAlbumsFromArtist(i);
               
            }
            Console.WriteLine("FOUND ALL HEATMAPS");
        }



        async Task GetAlbumsFromArtist(int artistIndex)
        {

                List<SimpleAlbum> foundAlbums = await currentForm.spotifyConnection.GetAlbumsFromArtist(foundArtists[artistIndex]);

                albumsByArtist[foundArtists[artistIndex]] = foundAlbums;

                currentForm.artRetiever.GetAlbumArt(albumsByArtist[foundArtists[artistIndex]]);
                currentForm.artRetiever.GetHeatMapsFromCurrentFiles();
            
            
        }
        void CompleteGettingAlbumsForArtist()
        {
            Console.WriteLine("Done getting heatmaps from artist" + foundArtists[0]);
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
